using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Npgsql;
using System.IO;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Film film = new Film();
        List<Film> films = new List<Film>();
        List<Film> filmCart = new List<Film>();


        public MainWindow()
        {
            InitializeComponent();
            FilmList.ItemsSource = film.FillTheList(films);
            FilmList.Background = new SolidColorBrush(Color.FromRgb(94, 94, 94));
            Console.WriteLine(Directory.GetCurrentDirectory());
            this.Icon = new BitmapImage( new Uri( System.IO.Path.Combine(Directory.GetCurrentDirectory(), "icon.png")));
            Logo.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "netflux.jpg")));
        }

        private void validationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void Button_Click_Add_To_Cart(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;
            if (!filmCart.Contains(button.Tag as Film))
            {
                FilmCart.Text = "";
                filmCart.Add(button.Tag as Film);
                foreach (Film f in filmCart)
                {
                    FilmCart.Text += f.Title + "\n";
                }
            }
        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (Decimal.TryParse(PriceTextBoxFiltering.Text, out minimumPrice))
            {    
                ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(FilmList.ItemsSource);
                view.Filter = null;
                if (view != null)
                {
                    FilmByPriceFilter filter = new FilmByPriceFilter(minimumPrice);
                    view.Filter = filter.FilterItem;
                }
            }
        }

        private void Button_Click_Delete_Filter(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(FilmList.ItemsSource);
            PriceTextBoxFiltering.Text = "";
            view.Filter = null;
        }

        private void Button_Click_Sort_By_Title(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(FilmList.ItemsSource);
            view.CustomSort = null;
            view.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
        }

        private void Button_Click_Sort_By_Price(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(FilmList.ItemsSource);
            view.CustomSort = null;
            view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Descending));
        }
        private void Button_Click_Delete_Sorting(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(FilmList.ItemsSource);
            view.CustomSort = null;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            Film film = new Film();
            film = (Film)FilmList.SelectedItem;
            DataTable dataTable = new DataTable();
            PriceConverter priceConverter = new PriceConverter();
            PriceValidation priceValidation = new PriceValidation();
            Console.WriteLine(priceValidation.Validate(PriceTextBox.Text, CultureInfo.CurrentCulture).IsValid);
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(String.Format("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=dotNETlab; Include Error Detail=true"));
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("UPDATE films SET \"title\" = :Title, \"director\" = :Director, " +
                    "\"production_country\" = :ProductionCountry, \"genre\" = :Genre, \"production_year\" = :ProductionYear, \"price\" = :Price WHERE \"id\" = '" + film.ID + "' ;", connection);
                command.Parameters.Add(new NpgsqlParameter("Title", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("Director", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("ProductionCountry", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("Genre", NpgsqlTypes.NpgsqlDbType.Text));
                command.Parameters.Add(new NpgsqlParameter("ProductionYear", NpgsqlTypes.NpgsqlDbType.Integer));
                command.Parameters.Add(new NpgsqlParameter("Price", NpgsqlTypes.NpgsqlDbType.Double));
                command.Parameters[0].Value = TitleTextBox.Text;
                command.Parameters[1].Value = DirectorTextBox.Text;
                command.Parameters[2].Value = CountryTextBox.Text;
                command.Parameters[3].Value = GenreTextBox.Text;
                command.Parameters[4].Value = Convert.ToInt16(YearTextBox.Text);
                command.Parameters[5].Value = Convert.ToDouble(priceConverter.ConvertBack(PriceTextBox.Text, typeof(Double), ".", CultureInfo.CurrentCulture));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (PostgresException exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        private void Button_Click_Empty_Cart(object sender, RoutedEventArgs e)
        {
            filmCart.Clear();
            FilmCart.Text = "";
        }
    }

    public class Film
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Director { get; set; }
        public String ProductionCountry { get; set; }
        public String Genre { get; set; }
        public String ImagePath { get; set; }
        public int ProductionYear { get; set; }
        public decimal Price { get; set; }

        public Film() { }

        public Film(String title, String director, String productionCountry, String genre, int productionYear, String imagePath, int id, decimal price)
        {
            ID = id;
            Title = title;
            Director = director;
            ProductionCountry = productionCountry;
            Genre = genre;
            ProductionYear = productionYear;
            ImagePath = imagePath;
            Price = price;
        }


        public override string ToString()
        {
            return Title + " " + Director + " " + ProductionCountry + " " + Genre + " " + ProductionYear + " " + Price;
        }

        public List<Film> FillTheList(List<Film> films)
        {
            DataTable dataTable = new DataTable();
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(String.Format("Server=localhost;Port=5432;User Id=postgres;Password=password;Database=dotNETlab"));
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM films", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    films.Add(new Film(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), Convert.ToInt16(dataReader[4]), dataReader[5].ToString(), Convert.ToInt16(dataReader[6]), Convert.ToDecimal(dataReader[7])));
                }
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return films;
        }
    }

    public class ImagePathConverter : IValueConverter
    {
        private String imageDirectory = Directory.GetCurrentDirectory();
        public String ImageDirectory
        {
            get { return imageDirectory; }
            set { imageDirectory = value; }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String imagePath = System.IO.Path.Combine(ImageDirectory, (string)value);
            return new BitmapImage(new Uri(imagePath));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            return price.ToString("C", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String price = value.ToString();
            decimal result;
            if (Decimal.TryParse(price, NumberStyles.Any, culture, out result))
            {
                return result;
            }
            return value;
        }
    }

    public class PriceValidation : ValidationRule
    {
        private decimal min = 0;
        private decimal max = 100;
        public decimal Min
        {
            get { return min; }
            set { min = value; }
        }

        public decimal Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;
            try
            {
                if (((string)value).Length > 0)
                {
                    price = Decimal.Parse((string)value, NumberStyles.Any, cultureInfo);
                }
            }
            catch
            {
                return new ValidationResult(false, "Nieprawidłowe znaki");
            }
            if ((price < Min) || (price > Max))
            {
                return new ValidationResult(false, "Cena nie mieści się w przedziale od " + Min + " do " + Max + "zł");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

    public class FilmByPriceFilter
    {
        public decimal MinimumPrice { get; set; }

        public FilmByPriceFilter(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }

        public bool FilterItem(Object item)
        {
            Film film = (Film)item;
            if (film != null)
            {
                return film.Price > MinimumPrice;
            }
            return false;
        }
    }

    public class PriceToBackgroundConverter : IValueConverter
    {
        public decimal MaxPrice { get; set; }
        public Brush HighlightBrush { get; set; }
        public Brush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if(price <= MaxPrice)
            {
                return HighlightBrush;
            }
            else
            {
                return DefaultBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
