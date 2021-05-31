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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public double width = 216;
        public double height = 126;

        public MainWindow()
        {
            InitializeComponent();
            SetPolndFlag();
            SetItalyFlag();
            SetJapanFlag();
            SetNorwayFlag();
            SetUKFlag();
            SetTurkeyFlag();
            SetIsraelFlag();
        }

        private void SetPolndFlag()
        {
            Poland.Height = height;
            Poland.Width = width;

            PolRec1.Height = height / 2;
            PolRec1.Width = width;
            PolRec1.Fill = new SolidColorBrush(Color.FromRgb(233, 232, 231));

            PolRec2.Height = height / 2;
            PolRec2.Width = width;
            PolRec2.Fill = new SolidColorBrush(Color.FromRgb(212, 33, 61));

            Canvas.SetTop(PolRec2, height / 2);
        }

        private void SetItalyFlag()
        {
            Italy.Height = height;
            Italy.Width = width;

            ItRec1.Height = height;
            ItRec1.Width = width / 3;
            ItRec1.Fill = new SolidColorBrush(Color.FromRgb(0, 140, 69));

            ItRec2.Height = height;
            ItRec2.Width = width / 3;
            ItRec2.Fill = new SolidColorBrush(Color.FromRgb(244, 245, 240));

            ItRec3.Height = height;
            ItRec3.Width = width / 3;
            ItRec3.Fill = new SolidColorBrush(Color.FromRgb(205, 33, 42));

            Canvas.SetLeft(ItRec2, width / 3);
            Canvas.SetLeft(ItRec3, width / 3 * 2);
        }

        private void SetJapanFlag()
        {
            Japan.Height = height;
            Japan.Width = width;

            double d = height * 3 / 5;

            JapRec1.Height = height;
            JapRec1.Width = width;
            JapRec1.Fill = new SolidColorBrush(Color.FromRgb(244, 244, 244));

            JapEll1.Height = d;
            JapEll1.Width = d;
            JapEll1.Fill = new SolidColorBrush(Color.FromRgb(176, 0, 15));

            Canvas.SetLeft(JapEll1, width / 2 - d / 2);
            Canvas.SetTop(JapEll1, height * 1 / 5);
        }

        private void SetNorwayFlag()
        {
            List<Rectangle> whites = new List<Rectangle>();
            List<Rectangle> reds = new List<Rectangle>();
            whites.Add(NorRec2);
            whites.Add(NorRec3);
            whites.Add(NorRec4);
            whites.Add(NorRec5);

            reds.Add(NorRec6);
            reds.Add(NorRec7);
            reds.Add(NorRec8);
            reds.Add(NorRec9);

            NorRec1.Height = Norway.Height = height;
            NorRec1.Width = Norway.Width = width;
            NorRec1.Fill = new SolidColorBrush(Color.FromRgb(0, 32, 91));


            foreach (Rectangle white in whites)
            {
                white.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                if (whites.IndexOf(white) >= 2)
                {
                    white.Width = width * 13 / 22;
                    white.Height = height * 7 / 16;
                }
                else
                {
                    white.Width = width * 7 / 22;
                    white.Height = height * 7 / 16;
                }
            }

            Canvas.SetTop(NorRec3, height * 9 / 16);

            Canvas.SetLeft(NorRec4, width * 9 / 22);

            Canvas.SetTop(NorRec5, height * 9 / 16);
            Canvas.SetLeft(NorRec5, width * 9 / 22);

            foreach (Rectangle red in reds)
            {
                red.Fill = new SolidColorBrush(Color.FromRgb(186, 12, 47));
                if (reds.IndexOf(red) >= 2)
                {
                    red.Width = width * 12 / 22;
                    red.Height = height * 6 / 16;
                }
                else
                {
                    red.Width = width * 6 / 22;
                    red.Height = height * 6 / 16;
                }
            }
            Canvas.SetTop(NorRec7, height * 10 / 16);

            Canvas.SetLeft(NorRec8, width * 10 / 22);

            Canvas.SetTop(NorRec9, height * 10 / 16);
            Canvas.SetLeft(NorRec9, width * 10 / 22);

        }

        private void SetUKFlag()
        {
            PointCollection wPointsPol1 = new PointCollection();
            PointCollection wPointsPol2 = new PointCollection();

            PointCollection rPointsPol3 = new PointCollection();
            PointCollection rPointsPol4 = new PointCollection();
            PointCollection rPointsPol5 = new PointCollection();
            PointCollection rPointsPol6 = new PointCollection();

            UK.Width = width;
            UK.Height = height;
            UK.ClipToBounds = true;

            UKRec1.Width = width;
            UKRec1.Height = height;
            UKRec1.Fill = new SolidColorBrush(Color.FromRgb(1, 33, 105));

            UKPol1.Stroke = UKPol2.Stroke = UKRec2.Fill = UKRec3.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            UKPol1.StrokeThickness = UKPol2.StrokeThickness = height * 3 / 30 + width * 3 / 60;

            UKPol3.Stroke = UKPol4.Stroke = UKPol5.Stroke = UKPol6.Stroke = UKRec4.Fill = UKRec5.Fill = new SolidColorBrush(Color.FromRgb(200, 16, 46));
            UKPol3.StrokeThickness = UKPol4.StrokeThickness = UKPol5.StrokeThickness = UKPol6.StrokeThickness = width * 2 / 60;

            wPointsPol1.Add(new Point(0, 0));
            wPointsPol1.Add(new Point(width, height));
            UKPol1.Points = wPointsPol1;

            wPointsPol2.Add(new Point(0, height));
            wPointsPol2.Add(new Point(width, 0));
            UKPol2.Points = wPointsPol2;

            rPointsPol3.Add(new Point(0, 0));
            rPointsPol3.Add(new Point(width * 20 / 60, height * 10 / 30));
            UKPol3.Points = rPointsPol3;
            Canvas.SetTop(UKPol3, height * 1 / 30);

            rPointsPol4.Add(new Point(0, height));
            rPointsPol4.Add(new Point(width * 20 / 60, height * 20 / 30));
            UKPol4.Points = rPointsPol4;
            Canvas.SetTop(UKPol4, height * 1 / 30);

            rPointsPol5.Add(new Point(width, height));
            rPointsPol5.Add(new Point(width * 40 / 60, height * 20 / 30));
            UKPol5.Points = rPointsPol5;
            Canvas.SetTop(UKPol5, height * -1 / 30);

            rPointsPol6.Add(new Point(width, 0));
            rPointsPol6.Add(new Point(width * 40 / 60, height * 10 / 30));
            UKPol6.Points = rPointsPol6;
            Canvas.SetTop(UKPol6, height * -1 / 30);

            UKRec2.Height = height * 10 / 30;
            UKRec2.Width = width;
            Canvas.SetTop(UKRec2, height * 10 / 30);

            UKRec3.Height = height;
            UKRec3.Width = width * 10 / 60;
            Canvas.SetLeft(UKRec3, width * 25 / 60);

            UKRec4.Height = height * 6 / 30;
            UKRec4.Width = width;
            Canvas.SetTop(UKRec4, height * 12 / 30);

            UKRec5.Height = height;
            UKRec5.Width = width *6/60;
            Canvas.SetLeft(UKRec5, width * 27 / 60);
        }

        private void SetTurkeyFlag()
        {
            double tHeight = height;
            double tWidth = height * 1.5;
            double m = tHeight * 1 / 30;
            double d = tHeight * 1 / 4;
            double firstPoint = (tHeight * 1 / 2) + (tHeight * 1 / 16) - tHeight * 1 / 5 + m + tHeight * 1 / 3;
            PointCollection points = new PointCollection();

            Turkey.Height = tHeight;
            Turkey.Width = tWidth + m;

            TurRec1.Height = tHeight;
            TurRec1.Width = tWidth + m;
            TurRec1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            TurRec2.Width = tWidth;
            TurRec2.Height = tHeight;
            TurRec2.Fill = new SolidColorBrush(Color.FromRgb(227, 10, 23));
            Canvas.SetLeft(TurRec2, m);

            TurEll1.Height = tHeight * 0.5;
            TurEll1.Width = tHeight * 0.5;
            TurEll1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Canvas.SetLeft(TurEll1, tHeight * 0.5 - ((tHeight * 0.5) / 2) + m);
            Canvas.SetTop(TurEll1, tHeight * 0.25);

            TurEll2.Height = tHeight * 2 / 5;
            TurEll2.Width = tHeight * 2 / 5;
            TurEll2.Fill = new SolidColorBrush(Color.FromRgb(227, 10, 23));
            Canvas.SetLeft(TurEll2, (tHeight * 1 / 2) + (tHeight * 1 / 16) - tHeight * 1 / 5 + m);
            Canvas.SetTop(TurEll2, tHeight * 3 / 5 / 2);

            TurPol1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            TurPol1.FillRule = FillRule.Nonzero;

            points.Add(new Point(firstPoint, tHeight / 2));
            points.Add(new Point(firstPoint + d * 1 / 3, tHeight / 2 - d * 1 / 5));
            points.Add(new Point(firstPoint + d * 1 / 3, tHeight / 2 - d * 1 / 2));

            points.Add(new Point(firstPoint + d * 1 / 3, tHeight / 2 + d * 1 / 5));
            points.Add(new Point(firstPoint + d * 1 / 3, tHeight / 2 + d * 1 / 2));

            points.Add(new Point(firstPoint + d * 2 / 3, tHeight / 2 + d * 1 / 4));
            points.Add(new Point(firstPoint + d * 2 / 3, tHeight / 2 - d * 1 / 4));
            Rectangle temp = new Rectangle() { Height = d, Width = d, RadiusX = firstPoint, RadiusY = tHeight / 2 - d / 2 };
            TurPol1.Points = StarPoints(temp);

        }

        private void SetIsraelFlag()
        {
            PointCollection isPol1 = new PointCollection();
            PointCollection isPol2 = new PointCollection();
            PointCollection isPol3 = new PointCollection();
            PointCollection isPol4 = new PointCollection();
            PointCollection isPol5 = new PointCollection();
            PointCollection isPol6 = new PointCollection();
            PointCollection isPol7 = new PointCollection();
            PointCollection isPol8 = new PointCollection();
            PointCollection isPol9 = new PointCollection();
            Israel.Width = width;
            Israel.Height = height;

            IsRec1.Width = width;
            IsRec1.Height = height;
            IsRec1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            IsRec2.Width = IsRec3.Width = width;
            IsRec2.Height = IsRec3.Height = height * 5 / 32;
            IsRec2.Fill = IsRec3.Fill = new SolidColorBrush(Color.FromRgb(0, 56, 184));
            Canvas.SetTop(IsRec2, height * 3 / 32);
            Canvas.SetTop(IsRec3, height * 24 / 32);

            IsPol1.Fill = IsPol2.Fill = new SolidColorBrush(Color.FromRgb(0, 56, 184));
            isPol1.Add(new Point(width * 17.05 / 44, height * 12.7 / 32));
            isPol1.Add(new Point(width * 26.95 / 44, height * 12.7 / 32));
            isPol1.Add(new Point(width * 22 / 44, height * 22.6 / 32));
            IsPol1.Points = isPol1;

            isPol2.Add(new Point(width * 22 / 44, height * 9.4 / 32));
            isPol2.Add(new Point(width * 17.05 / 44, height * 19.3 / 32));
            isPol2.Add(new Point(width * 26.95 / 44, height * 19.3 / 32));
            IsPol2.Points = isPol2;

            IsPol3.Fill = IsPol4.Fill = IsPol5.Fill = IsPol6.Fill = IsPol7.Fill = IsPol8.Fill = IsPol9.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            isPol3.Add(new Point(width * 22 / 44, height * 11.6 / 32));
            isPol3.Add(new Point(width * 22.55 / 44, height * 12.7 / 32));
            isPol3.Add(new Point(width * 21.45 / 44, height * 12.7 / 32));
            IsPol3.Points = isPol3;

            isPol4.Add(new Point(width * 19.25 / 44, height * 14.9 / 32));
            isPol4.Add(new Point(width * 18.7 / 44, height * 13.8 / 32));
            isPol4.Add(new Point(width * 19.8 / 44, height * 13.8 / 32));
            IsPol4.Points = isPol4;

            isPol5.Add(new Point(width * 19.25 / 44, height * 17.1 / 32));
            isPol5.Add(new Point(width * 18.7 / 44, height * 18.2 / 32));
            isPol5.Add(new Point(width * 19.8 / 44, height * 18.2 / 32));
            IsPol5.Points = isPol5;

            isPol6.Add(new Point(width * 22 / 44, height * 20.4 / 32));
            isPol6.Add(new Point(width * 22.55 / 44, height * 19.3 / 32));
            isPol6.Add(new Point(width * 21.45 / 44, height * 19.3 / 32));
            IsPol6.Points = isPol6;

            isPol7.Add(new Point(width * 24.74 / 44, height * 17.1 / 32));
            isPol7.Add(new Point(width * 25.3 / 44, height * 18.2 / 32));
            isPol7.Add(new Point(width * 24.15 / 44, height * 18.2 / 32));
            IsPol7.Points = isPol7;

            isPol8.Add(new Point(width * 24.74 / 44, height * 14.9 / 32));
            isPol8.Add(new Point(width * 25.3 / 44, height * 13.8 / 32));
            isPol8.Add(new Point(width * 24.15 / 44, height * 13.8 / 32));
            IsPol8.Points = isPol8;

            isPol9.Add(new Point(width * 20.9 / 44, height * 13.9 / 32));
            isPol9.Add(new Point(width * 23.1 / 44, height * 13.9 / 32));
            isPol9.Add(new Point(width * 24.2 / 44, height * 16.1 / 32));
            isPol9.Add(new Point(width * 23.1 / 44, height * 18.3 / 32));
            isPol9.Add(new Point(width * 20.9 / 44, height * 18.3 / 32));
            isPol9.Add(new Point(width * 19.8 / 44, height * 16.1 / 32));
            IsPol9.Points = isPol9;
        }

        private PointCollection StarPoints(Rectangle bounds)
        {
            PointCollection points = new PointCollection();
            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.RadiusX + rx;
            double cy = bounds.RadiusY + ry;

            // Start at the top.
            double theta = -Math.PI / 5;
            double dtheta = 4 * Math.PI / 5;
            for (int i = 0; i < 5; i++)
            {
                points.Add(new Point(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta))));
                theta += dtheta;
            }

            return points;
        }
    }
}
