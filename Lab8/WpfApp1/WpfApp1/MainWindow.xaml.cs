using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private MarkType[] mResoults;
        private bool mPlayer1Turn;
        private bool mGameEnded;

        private int[] playersPoints;

        private String file = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "ranking.txt");

        private List<Button> buttonList = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            buttonList.Add(Button0_0);
            buttonList.Add(Button0_1);
            buttonList.Add(Button0_2);
            buttonList.Add(Button1_0);
            buttonList.Add(Button1_1);
            buttonList.Add(Button1_2);
            buttonList.Add(Button2_0);
            buttonList.Add(Button2_1);
            buttonList.Add(Button2_2);
            playersPoints = new int[2] { 0, 0 };
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            SaveResoults();
            this.Close();
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Ranking.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Ranking(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(file))
            {
                var myFile = File.Create(file);
                myFile.Close();
            }
            Ranking.Visibility = Visibility.Visible;
            buttonList.ForEach(button => { button.Visibility = Visibility.Hidden; });
            GoBack.IsEnabled = true;
            int i = 0;
            int[] temp = new int[2];
            foreach (String line in File.ReadLines(file))
            {
                temp[i] = Int32.Parse(line) + playersPoints[i];
                i++;
            }
            Player1.Content = "Player 1: " + temp[0].ToString();
            Player2.Content = "Player 2: " + temp[1].ToString();
        }



        private void NewGame()
        {
            Ranking.Visibility = Visibility.Hidden;
            mResoults = new MarkType[9];
            for(var i = 0; i< playersPoints.Length; i++)
            {
                playersPoints[i] = 0;
            }

            for (var i = 0; i < mResoults.Length; i++)
            {
                mResoults[i] = MarkType.Free;
            }

            mPlayer1Turn = true;
            buttonList.ForEach(button =>
            {
                button.Visibility = Visibility.Visible;
                button.Content = string.Empty;
                button.Foreground = new SolidColorBrush(Color.FromRgb(128, 128, 255));
                button.Background = new SolidColorBrush(Color.FromRgb(7, 7, 7));
            });

            mGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);
            if (mResoults[index] != MarkType.Free)
            {
                return;
            }
            mResoults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "X" : "O";

            if (!mPlayer1Turn)
            {
                button.Foreground = new SolidColorBrush(Color.FromRgb(240, 40, 125));
            }

            mPlayer1Turn ^= true;

            ChechForWinner();
        }

        private void GameEnded()
        {
            for (var i = 0; i < playersPoints.Length; i++)
            {
                playersPoints[i] = 0;
            }
            buttonList.ForEach(button => { button.Visibility = Visibility.Hidden; });
        }

        private void CheckWhoWon()
        {
            if (mGameEnded)
            {
                if (!mPlayer1Turn)
                {
                    playersPoints[0]++;
                    var result = MessageBox.Show("Wygrał gracz pierwszy!\n Czy chcesz grać dalej?", "Wynik gry", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveResoults();
                        NewGame();
                    }
                    else
                    {
                        SaveResoults();
                        GameEnded();
                    }
                }
                else
                {
                    playersPoints[1]++;
                    var result = MessageBox.Show("Wygrał gracz drugi!\n Czy chcesz grać dalej?", "Wynik gry", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveResoults();
                        NewGame();
                    }
                    else
                    {
                        SaveResoults();
                        GameEnded();
                    }
                }
            }
        }

        private void GetPoints()
        {
            int i = 0;
            foreach (String line in File.ReadLines(file))
            {
                playersPoints[i] += Int32.Parse(line);
                i++;
            }
        }


        private void Tie()
        {
            var result = MessageBox.Show("Remis.\n Czy chcesz zagrać ponownie?", "Wynik gry", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SaveResoults();
                NewGame();
            }
            else
            {
                SaveResoults();
                GameEnded();
            }
        }

        private void SaveResoults()
        {
            if (!File.Exists(file))
            {
                var myFile = File.Create(file);
                myFile.Close();
            }
            GetPoints();
            String[] resoults = { playersPoints[0].ToString(), playersPoints[1].ToString() };
            File.WriteAllLines(file, resoults);
        }


        private void ChechForWinner()
        {
            Brush brush = new SolidColorBrush(Color.FromRgb(70, 128, 0));
            /*
             * Row 0
             */
            if (mResoults[0] != MarkType.Free && (mResoults[0] & mResoults[1] & mResoults[2]) == mResoults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = brush;
                CheckWhoWon();
            }
            /*
             * Row 1
             */
            if (mResoults[3] != MarkType.Free && (mResoults[3] & mResoults[4] & mResoults[5]) == mResoults[3])
            {
                mGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = brush;
                CheckWhoWon();
            }
            /*
             * Row 2
             */
            if (mResoults[6] != MarkType.Free && (mResoults[6] & mResoults[7] & mResoults[8]) == mResoults[6])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = brush;
                CheckWhoWon();
            }


            /*
             * Column 0
             */
            if (mResoults[0] != MarkType.Free && (mResoults[0] & mResoults[3] & mResoults[6]) == mResoults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = brush;
                CheckWhoWon();
            }
            /*
             * Column 1
             */
            if (mResoults[1] != MarkType.Free && (mResoults[1] & mResoults[4] & mResoults[7]) == mResoults[1])
            {
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = brush;
                CheckWhoWon();
            }
            /*
             * Column 2
             */
            if (mResoults[2] != MarkType.Free && (mResoults[2] & mResoults[5] & mResoults[8]) == mResoults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = brush;
                CheckWhoWon();
            }


            /*
             * Diagonal 0
             */
            if (mResoults[0] != MarkType.Free && (mResoults[0] & mResoults[4] & mResoults[8]) == mResoults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = brush;
                CheckWhoWon();
            }

            /*
             * Diagonal 1
             */
            if (mResoults[2] != MarkType.Free && (mResoults[2] & mResoults[4] & mResoults[6]) == mResoults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = brush;
                CheckWhoWon();
            }


            if (!mResoults.Any(result => result == MarkType.Free))
            {
                mGameEnded = true;
                buttonList.ForEach(button =>
                {
                    button.Background = new SolidColorBrush(Color.FromRgb(0,125,250));
                });
                Tie();
            }
        }
    }

    public enum MarkType
    {
        Free,
        Nought,
        Cross
    }
}
