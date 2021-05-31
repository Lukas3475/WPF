using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Dictionary<string, double> pizzaPrizes = new Dictionary<string, double>();
        Dictionary<string, double> pizzaToppings = new Dictionary<string, double>();
        Dictionary<string, double> pizzaSizes = new Dictionary<string, double>();
        bool onePizzaTopping = true;
        bool isPizzaToppingsSelected = false;
        bool isSizeSelected = false;
        bool isPizzaSelected = false;
        bool addedDeliveryCost = false;
        double finalOrder = 0;
        double pizzaPrize = 0;
        string oldPizzaSize = "";

        public MainWindow()
        {
            pizzaPrizes.Add("Hawajska", 10);
            pizzaPrizes.Add("Wegetariańska", 11);
            pizzaPrizes.Add("Al capone", 14);
            pizzaPrizes.Add("Americana", 15);
            pizzaPrizes.Add("Broccoli", 13);

            pizzaToppings.Add("Ciasto grube", 1);
            pizzaToppings.Add("Ananas", 2);
            pizzaToppings.Add("Bekon", 2);
            pizzaToppings.Add("Brokuły", 2);
            pizzaToppings.Add("Kukurydza", 2);
            pizzaToppings.Add("Kurczak grilowany", 2);
            pizzaToppings.Add("Pomidor suszony", 2);

            pizzaSizes.Add("Mały", 5);
            pizzaSizes.Add("Średni", 10);
            pizzaSizes.Add("Duży", 15);

            InitializeComponent();
            topping1.IsEnabled = false;
            topping2.IsEnabled = false;
            topping3.IsEnabled = false;
            topping4.IsEnabled = false;
            topping5.IsEnabled = false;
            topping6.IsEnabled = false;
            topping7.IsEnabled = false;
            Cancel.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "cancel_button.png")));
            Order.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "order_button.jpg")));
        }

        private void changePizzaImage(string pizzaSelected)
        {
            BitmapImage bitPizza = new BitmapImage();
            string directory = Directory.GetCurrentDirectory();
            switch (pizzaSelected)
            {
                case "Americana":
                    bitPizza.BeginInit();
                    bitPizza.UriSource = new Uri(System.IO.Path.Combine(directory, "americana.png"));
                    bitPizza.EndInit();
                    pizzaDisplay.Background = Brushes.White;
                    pizzaImage.Source = bitPizza;
                    pizzaName.Content = pizzaSelected;
                    pizzaDesc.Text = "Skład pizzy: ser, kurczak grillowany, mięso kebab, cebula biała, sos BBQ, oregano";
                    break;
                case "Hawajska":
                    bitPizza.BeginInit();
                    bitPizza.UriSource = new Uri(System.IO.Path.Combine(directory, "hawajska.png"));
                    bitPizza.EndInit();
                    pizzaDisplay.Background = Brushes.White;
                    pizzaImage.Source = bitPizza;
                    pizzaName.Content = pizzaSelected;
                    pizzaDesc.Text = "Skład pizzy: ser, szynka, ananas, sos pomidorowy, oregano";
                    break;
                case "Wegetariańska":
                    bitPizza.BeginInit();
                    bitPizza.UriSource = new Uri(System.IO.Path.Combine(directory,"wegetarianska.png"));
                    bitPizza.EndInit();
                    pizzaDisplay.Background = Brushes.White;
                    pizzaImage.Source = bitPizza;
                    pizzaName.Content = pizzaSelected;
                    pizzaDesc.Text = "Skład pizzy: ser, sos pomidorowy, oregano";
                    break;
                case "Al capone":
                    bitPizza.BeginInit();
                    bitPizza.UriSource = new Uri(System.IO.Path.Combine(directory, "al_capone.png"));
                    bitPizza.EndInit();
                    pizzaDisplay.Background = Brushes.White;
                    pizzaImage.Source = bitPizza;
                    pizzaName.Content = pizzaSelected;
                    pizzaDesc.Text = "Skład pizzy: ser, sos czosnkowy, bekon, salami, kurczak grillowany, kabanos, cebula biała, oregano";
                    break;
                case "Broccoli":
                    bitPizza.BeginInit();
                    bitPizza.UriSource = new Uri(System.IO.Path.Combine(directory, "americana.png"));
                    bitPizza.EndInit();
                    pizzaDisplay.Background = Brushes.White;
                    pizzaImage.Source = bitPizza;
                    pizzaName.Content = pizzaSelected;
                    pizzaDesc.Text = "Skład pizzy: ser, kurczak grillowany, brokuły, sos czosnkowo-serowy, oregano";
                    break;
            }
            
        }


        private void PizzasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isPizzaSelected)
            {
                FreeDelivery.Value = 0;
                ComboBoxItem pizzaSelected = (ComboBoxItem)pizzasList.SelectedItem;
                if (pizzaSelected == null)
                {
                }
                else
                {
                    foreach (var pizzaPrize in pizzaPrizes)
                    {
                        if (pizzaPrize.Key.Equals(pizzaSelected.Content))
                        {
                            finalOrder += pizzaPrize.Value;
                            Wynik.Content = "Koszt: " + finalOrder.ToString();
                            changePizzaImage(pizzaSelected.Content.ToString());
                            if (FreeDelivery.Value <= 30)
                            {
                                FreeDelivery.Value += finalOrder;
                            }
                        }
                    }
                    freeDeliveryCheck();
                    isPizzaSelected = true;
                    isSizeSelected = false;
                    isPizzaToppingsSelected = false;
                    onePizzaTopping = true;
                    if (isPizzaSelected)
                    {
                        topping1.IsEnabled = true;
                        topping2.IsEnabled = true;
                        topping3.IsEnabled = true;
                        topping4.IsEnabled = true;
                        topping5.IsEnabled = true;
                        topping6.IsEnabled = true;
                        topping7.IsEnabled = true;
                    }
                    Ordered.Text = Ordered.Text + " pizze:  " + pizzaSelected.Content;
                }
                pizzasList.IsEnabled = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (isPizzaSelected)
            {
                if (!Ordered.Text.Contains(checkbox.Content.ToString()))
                {
                    FreeDelivery.Value = 0;
                    foreach (var pizzaTopping in pizzaToppings)
                    {
                        if (pizzaTopping.Key.Equals(checkbox.Content))
                        {

                            finalOrder += pizzaTopping.Value;
                            Wynik.Content = "Koszt: " + finalOrder.ToString();
                            if (FreeDelivery.Value <= 30)
                            {
                                FreeDelivery.Value += finalOrder;
                            }
                        }
                    }
                    freeDeliveryCheck();
                    if (onePizzaTopping)
                    {
                        Ordered.Text = Ordered.Text + ", z dodatkami " + checkbox.Content;
                        onePizzaTopping = false;
                    }
                    else
                    {
                        Ordered.Text = Ordered.Text + ", " + checkbox.Content;
                    }
                    isPizzaToppingsSelected = true;
                }
            }
        }


        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (isPizzaSelected)
            {
                if (!isSizeSelected)
                {
                    FreeDelivery.Value = 0;
                    foreach (var pizzSize in pizzaSizes)
                    {
                        if (pizzSize.Key.Equals(radioButton.Content))
                        {
                            oldPizzaSize = radioButton.Content.ToString();
                            pizzaPrize = pizzSize.Value;
                            finalOrder += pizzaPrize;
                            Wynik.Content = "Koszt: " + finalOrder.ToString();
                            if (FreeDelivery.Value <= 30)
                            {
                                FreeDelivery.Value += finalOrder;
                            }
                        }
                    }
                    freeDeliveryCheck();
                    Ordered.Text = Ordered.Text + ", o rozmiarze: " + radioButton.Content;
                    isSizeSelected = true;
                }
                else
                {
                    FreeDelivery.Value = 0;
                    finalOrder -= pizzaPrize;
                    Ordered.Text = Regex.Replace(Ordered.Text, ", o rozmiarze: " + oldPizzaSize, ", o rozmiarze: " + radioButton.Content);
                    foreach (var pizzSize in pizzaSizes)
                    {
                        if (pizzSize.Key.Equals(radioButton.Content))
                        {
                            oldPizzaSize = radioButton.Content.ToString();
                            pizzaPrize = pizzSize.Value;
                            finalOrder += pizzSize.Value;
                            Wynik.Content = "Koszt: " + finalOrder.ToString();
                            if (FreeDelivery.Value <= 30)
                            {
                                FreeDelivery.Value += finalOrder;
                            }
                        }
                    }
                    freeDeliveryCheck();
                    
                }
            }
            else
            {
                radioButton.IsChecked = false;
            }
        }


        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (Ordered.Text.Contains(", z dodatkami " + checkBox.Content.ToString()))
            {
                Ordered.Text = Regex.Replace(Ordered.Text, ", z dodatkami " + checkBox.Content.ToString(), "");
                onePizzaTopping = true;
            }
            Ordered.Text = Regex.Replace(Ordered.Text, ", " + checkBox.Content.ToString(), "");
            foreach (var pizzaTopping in pizzaToppings)
            {
                if (pizzaTopping.Key.Equals(checkBox.Content))
                {
                    finalOrder -= pizzaTopping.Value;
                    FreeDelivery.Value -= pizzaTopping.Value;
                }
            }
            freeDeliveryCheck();
        }

        private void freeDeliveryCheck()
        {
            if (!addedDeliveryCost)
            {
                finalOrder += 5;
                Wynik.Content = "Koszt: " + finalOrder.ToString() + " zł (doliczono cenę dostawy)";
                addedDeliveryCost = true;
            }
            else
            {
                if (finalOrder >= 35)
                {
                    FreeDeliveryInformation.Foreground = Brushes.Green;
                    FreeDeliveryInformation.Content = "Dostawa będzie darmowa!";
                    Wynik.Content = "Koszt: " + (finalOrder - 5).ToString() + " zł (dostawa gratis)";
                }
                else
                {
                    FreeDeliveryInformation.Foreground = Brushes.White;
                    FreeDeliveryInformation.Content = "Brakująca wartość zamówienia do darmowej dostawy";
                    Wynik.Content = "Koszt: " + finalOrder.ToString() + " zł (doliczono cenę dostawy)";
                }
            }

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            if (isPizzaToppingsSelected & isPizzaSelected & isSizeSelected)
            {
                SauseLabel.Content = "Ostrość sosu: " + slider.Value + "%";
                if (!Ordered.Text.Contains("o ostrości sosu:"))
                {
                    Ordered.Text += " o ostrości sosu: " + slider.Value + "%";
                }
                Ordered.Text = Regex.Replace(Ordered.Text, @"(o ostrości sosu: .*%)", $"o ostrości sosu: {slider.Value}%");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            Comments.Content = "Uwagi: " + text.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (isPizzaSelected & isSizeSelected)
            {
                var result = MessageBox.Show("Czy jesteś pewien swojego zamówienia?", "Akceptacja zamówienia", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Dziękujemy za zamówienie!", "Akceptacja zamówienia", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano pizzy oraz jej rozmiaru", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            topping1.IsChecked = false;
            topping2.IsChecked = false;
            topping3.IsChecked = false;
            topping4.IsChecked = false;
            topping5.IsChecked = false;
            topping6.IsChecked = false;
            topping7.IsChecked = false;
            topping1.IsEnabled = false;
            topping2.IsEnabled = false;
            topping3.IsEnabled = false;
            topping4.IsEnabled = false;
            topping5.IsEnabled = false;
            topping6.IsEnabled = false;
            topping7.IsEnabled = false;
            size1.IsChecked = false;
            size2.IsChecked = false;
            size3.IsChecked = false;
            addedDeliveryCost = false;
            onePizzaTopping = false;
            isSizeSelected = false;
            isPizzaToppingsSelected = false;
            isPizzaSelected = false;
            pizzaName.Content = "";
            pizzaDesc.Text = "";
            pizzaImage.Source = null;
            pizzaDisplay.Background = new SolidColorBrush(Color.FromRgb(42, 50, 60));
            Ordered.Text = "Wybrałeś: ";
            pizzasList.Text = "";
            FreeDelivery.Value = 0;
            FreeDeliveryInformation.Foreground = Brushes.White;
            FreeDeliveryInformation.Content = "Brakująca wartość zamówienia do darmowej dostawy";
            Wynik.Content = "Koszt: ";
            SauseLabel.Content = "Ostrość sosu";
            Comments.Content = "Uwagi:";
            CommentsTyped.Clear();
            Sause.Value = 0;
            finalOrder = 0;
            pizzasList.IsEnabled = true;
        }
    }
}
