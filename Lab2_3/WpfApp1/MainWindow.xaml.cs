using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        double number1, number2;
        bool enteredValue = false;
        String givenOperation = "";
        bool dividedZero = false;

        //liczby
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            enterValue((String)button.Content);
            textBox1.Focus();
        }

        //CE
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "0";
            textBox1.Focus();

        }

        //C
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            delete();
            textBox1.Focus();

        }

        //Backspace
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            backspace();
            textBox1.Focus();
        }

        //operacje
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (number1 != 0)
            {
                giveResult();
                givenOperation = (String)button.Content;
                enteredValue = true;
                label1.Content = number1 + "  " + givenOperation;
            }
            else
            {
                givenOperation = (String)button.Content;
                number1 = Double.Parse(textBox1.Text);
                enteredValue = true;
                label1.Content = number1 + "  " + givenOperation;
            }
        }

        //equals
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            giveResult();
        }

        private void enterValue(String buttonContent)
        {
            if (textBox1.Text.Length < 15)
            {
                if (textBox1.Text == "0" & buttonContent == ",")
                {
                    textBox1.Text = "0,";
                }
                if (textBox1.Text == "0" | enteredValue | dividedZero)
                {
                    textBox2.Clear();
                    textBox1.Clear();
                    dividedZero = false;
                }
                enteredValue = false;
                if ((String)buttonContent == ",")
                {
                    if (!textBox1.Text.Contains(","))
                    {
                        textBox1.Text = textBox1.Text + ",";
                    }
                    if (textBox1.Text == "0")
                    {
                        textBox1.Text = "0,";
                    }
                }
                else
                {
                    textBox1.Text = textBox1.Text + buttonContent;
                }

            }
            else
            {
                if (enteredValue)
                {
                    textBox1.Clear();
                }
                enteredValue = false;
            }
        }

        private void takeOperation(String operation)
        {
            if (number1 != 0)
            {
                //if (result.ToString() == textBox1.Text)
                //{
                //    enteredValue = true;
                //    label1.Content = result + "  " + givenOperation;
                //}
                enteredValue = true;
                giveResult();
                givenOperation = operation;
                label1.Content = number1 + "  " + givenOperation;
            }
            else
            {
                givenOperation = operation;
                number1 = Double.Parse(textBox1.Text);
                enteredValue = true;
                label1.Content = number1 + "  " + givenOperation;
            }
        }

        private void giveResult()
        {
            label1.Content = "";
            switch (givenOperation)
            {
                case "+":
                    number2 = Double.Parse(textBox1.Text);
                    label1.Content = number1 + " + " + number2 + " = ";
                    textBox1.Text = (number1 + number2).ToString();
                    break;
                case "-":
                    number2 = Double.Parse(textBox1.Text);
                    label1.Content = number1 + " - " + number2 + " = ";
                    textBox1.Text = (number1 - number2).ToString();
                    break;
                case "×":
                    number2 = Double.Parse(textBox1.Text);
                    label1.Content = number1 + " × " + number2 + " = ";
                    textBox1.Text = (number1 * number2).ToString();
                    break;
                case "÷":
                    number2 = Double.Parse(textBox1.Text);
                    if (number2 == 0)
                    {
                        dividedZero = true;
                        break;
                    }
                    else
                    {
                        label1.Content = number1 + " ÷ " + number2 + " = ";
                        textBox1.Text = (number1 / number2).ToString();
                        break;
                    }
            }
            if (textBox1.Text == "0" & !dividedZero)
            {
                label1.Content = number1 + " "  + givenOperation +  "0 =";
            }
            if (dividedZero)
            {
                textBox2.Text = "Nie można dzielić przez zero";
                givenOperation = "";
                number1 = 0;
            }
            else
            {
                number1 = Double.Parse(textBox1.Text);
                givenOperation = "";
            }
        }

        private void backspace()
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void delete()
        {
            label1.Content = "";
            textBox1.Text = "0";
            number1 = 0;
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Length < 15 | enteredValue | !dividedZero)
            {
                if (e.Key == Key.NumPad0 | e.Key == Key.D0)
                {
                    enterValue("0");
                }
                if (e.Key == Key.NumPad1 | e.Key == Key.D1)
                {
                    enterValue("1");
                }
                if (e.Key == Key.NumPad2 | e.Key == Key.D2)
                {
                    enterValue("2");
                }
                if (e.Key == Key.NumPad3 | e.Key == Key.D3)
                {
                    enterValue("3");
                }
                if (e.Key == Key.NumPad4 | e.Key == Key.D4)
                {
                    enterValue("4");
                }
                if (e.Key == Key.NumPad5 | e.Key == Key.D5)
                {
                    enterValue("5");
                }
                if (e.Key == Key.NumPad6 | e.Key == Key.D6)
                {
                    enterValue("6");
                }
                if (e.Key == Key.NumPad7 | e.Key == Key.D7)
                {
                    enterValue("7");
                }
                if (e.Key == Key.NumPad8 | e.Key == Key.D8)
                {
                    enterValue("8");
                }
                if (e.Key == Key.NumPad9 | e.Key == Key.D9)
                {
                    enterValue("9");
                }
                if (e.Key == Key.Decimal)
                {
                    enterValue(",");
                }
            }
            if (e.Key == Key.Add)
            {
                givenOperation = "+";
                takeOperation(givenOperation);
            }
            if (e.Key == Key.Subtract)
            {
                givenOperation = "-";
                takeOperation(givenOperation);
            }
            if (e.Key == Key.Multiply)
            {
                givenOperation = "×";
                takeOperation(givenOperation);
            }
            if (e.Key == Key.Divide)
            {
                givenOperation = "÷";
                takeOperation(givenOperation);
            }
            if (e.Key == Key.Return)
            {
                giveResult();
            }
            if (e.Key == Key.Delete | e.Key == Key.D)
            {
                delete();
            }
            if (e.Key == Key.Back | e.Key == Key.B)
            {
                backspace();
            }
        }
    }
}
