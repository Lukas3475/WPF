using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        private Point point;
        private Point newPoint;

        public MainWindow()
        {
            InitializeComponent();
            LoadTextures();

        }

        private void LoadTextures()
        {
            String currentDirectory = Directory.GetCurrentDirectory();
            ImageBrush imageBrush1 = new ImageBrush();
            ImageBrush imageBrush2 = new ImageBrush();
            imageBrush1.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "table_leg.jpg")));
            Leg1.Brush = Leg2.Brush = Leg3.Brush = Leg4.Brush = imageBrush1;
            imageBrush2.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "table_top.jpg")));
            TableTop.Brush = imageBrush2;
        }

        private void Viewport3D_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
            {
                Viewport3D viewport3D = (Viewport3D)sender;
                newPoint = e.GetPosition(viewport3D);
                if((newPoint.X - point.X) > 0)
                {
                    Rotate.Angle += 1;
                }
                else
                {
                    Rotate.Angle -= 1;
                }
                point = newPoint;
            }
        }
    }
}
