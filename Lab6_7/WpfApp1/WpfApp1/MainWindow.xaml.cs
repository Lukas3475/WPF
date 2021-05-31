using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        bool isItalic = false;
        bool isBold = false;
        RichTextBox richHolder;
        String fileName;

        public MainWindow()
        {
            InitializeComponent();
            RichTextEditor.Focus();
            SetImages();
        }

        private TextRange getTextFromRichTextBox(RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        }

        private TextRange getSelectedText()
        {
            return RichTextEditor.Selection;
        }

        private void SetImages()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Cut.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "cut.png")));
            Copy.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "copy.png")));
            Paste.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "paste.png")));
            Bold.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "bold.png")));
            Italic.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "italic.png")));
            Alight_Center.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "align_center.png")));
            Alight_Left.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "align_left.png")));
            Alight_Right.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, "align_right.png")));
        }

        private void Button_Click_Italic(object sender, RoutedEventArgs e)
        {
            TextRange textSel = getSelectedText();
            if (textSel.Text == "")
            {
                textSel.Text = " ";
            }
            if (isItalic)
            {
                textSel.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
                isItalic = false;
            }
            else
            {
                textSel.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                isItalic = true;
            }
        }

        private void Bold_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextRange textSel = getSelectedText();
            if (textSel.Text == "")
            {
                textSel.Text = " ";
            }
            if (isBold)
            {
                textSel.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
                isBold = false;
            }
            else
            {
                textSel.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                isBold = true;
            }
        }


        private void Button_Click_Align_Left(object sender, RoutedEventArgs e)
        {
            RichTextEditor.Document.TextAlignment = TextAlignment.Left;
        }

        private void Button_Click_Align_Center(object sender, RoutedEventArgs e)
        {
            RichTextEditor.Document.TextAlignment = TextAlignment.Center;
        }

        private void Button_Click_Align_Right(object sender, RoutedEventArgs e)
        {
            RichTextEditor.Document.TextAlignment = TextAlignment.Right;
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var result = MessageBox.Show("Potrzebujesz pomocy?", "Pomoc", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://docs.microsoft.com/en-us/dotnet/");
            }
        }

        private void About_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var result = MessageBox.Show("O programie", "O programie", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (richHolder != null)
            {
                if (getTextFromRichTextBox(richHolder) != getTextFromRichTextBox(RichTextEditor))
                {
                    if (File.Exists(fileName))
                    {
                        FileStream fileStream = new FileStream(fileName, FileMode.Truncate);
                        TextRange range = getTextFromRichTextBox(RichTextEditor);
                        range.Save(fileStream, DataFormats.Rtf);
                        richHolder = RichTextEditor;
                    }
                    else
                    {
                        Save_As_Executed(sender, e);
                    }
                }
            }
            else
            {
                Save_As_Executed(sender, e);
            }
        }

        private void Save_As_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                TextRange range = getTextFromRichTextBox(RichTextEditor);
                range.Save(fileStream, DataFormats.Rtf);
                richHolder = RichTextEditor;
                fileName = saveFileDialog.FileName;
            }
        }

        private void open(OpenFileDialog openFileDialog)
        {
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                TextRange range = getTextFromRichTextBox(RichTextEditor);
                range.Load(fileStream, DataFormats.Rtf);
                richHolder = RichTextEditor;
                fileName = openFileDialog.FileName;
            }
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (richHolder != null)
            {
                if (getTextFromRichTextBox(richHolder) != getTextFromRichTextBox(RichTextEditor))
                {
                    var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz zmiany", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Save_Executed(sender, e);
                        richHolder = RichTextEditor;
                    }
                    open(openFileDialog);
                }
                else
                {
                    open(openFileDialog);
                }
            }
            else
            {
                if (getTextFromRichTextBox(RichTextEditor).Text.Contains("\r\n"))
                {
                    open(openFileDialog);
                }
                else
                {
                    var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz zmiany", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Save_Executed(sender, e);
                        richHolder = RichTextEditor;
                    }
                }

            }

        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (richHolder != null)
            {
                if (getTextFromRichTextBox(richHolder) != getTextFromRichTextBox(RichTextEditor))
                {
                    var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz zmiany", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Save_Executed(sender, e);
                        richHolder = RichTextEditor;
                    }
                    RichTextEditor.Document.Blocks.Clear();
                    isBold = false;
                    isItalic = false;
                    if (richHolder != null) richHolder.Document.Blocks.Clear();
                    fileName = null;
                }
            }
            else
            {
                if (!(getTextFromRichTextBox(RichTextEditor).Text == "\r\n"))
                {
                    var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz zmiany", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Save_Executed(sender, e);
                    }
                    RichTextEditor.Document.Blocks.Clear();
                    isBold = false;
                    isItalic = false;
                    if (richHolder != null) richHolder.Document.Blocks.Clear();
                    fileName = null;
                }
            }
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(getTextFromRichTextBox(RichTextEditor).Text == "\r\n"))
            {
                if (richHolder != null)
                {
                    if (getTextFromRichTextBox(richHolder) != getTextFromRichTextBox(RichTextEditor))
                    {
                        var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz zmiany", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            Save_Executed(sender, e);
                            this.Close();
                        }
                    }
                    this.Close();
                }
                else
                {
                    var result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapisz zmiany", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Save_Executed(sender, e);
                        this.Close();
                    }
                }
            }
            this.Close();
        }
    }
    public static class CustomCommands
    {
        private static RoutedUICommand bold;
        private static RoutedUICommand save;
        private static RoutedUICommand saveAs;
        private static RoutedUICommand open;
        private static RoutedUICommand newFile;
        private static RoutedUICommand close;
        private static RoutedUICommand help;
        private static RoutedUICommand about;



        static CustomCommands()
        {
            bold = new RoutedUICommand("Bold", "Bold", typeof(CustomCommands));

            save = new RoutedUICommand("Save", "Save", typeof(CustomCommands));
            save.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));

            open = new RoutedUICommand("Open", "Open", typeof(CustomCommands));
            open.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));

            newFile = new RoutedUICommand("New", "New", typeof(CustomCommands));
            newFile.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));

            saveAs = new RoutedUICommand("Save As", "Save As", typeof(CustomCommands));

            close = new RoutedUICommand("Close", "Close", typeof(CustomCommands));
            close.InputGestures.Add(new KeyGesture(Key.Escape));

            help = new RoutedUICommand("Help", "Help", typeof(CustomCommands));
            help.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));

            about = new RoutedUICommand("About", "About", typeof(CustomCommands));

        }

        public static RoutedUICommand Bold
        {
            get { return bold; }
        }

        public static RoutedUICommand Save
        {
            get { return save; }
        }

        public static RoutedUICommand Open
        {
            get { return open; }
        }

        public static RoutedUICommand NewFile
        {
            get { return newFile; }
        }

        public static RoutedUICommand SaveAs
        {
            get { return saveAs; }
        }

        public static RoutedUICommand Close
        {
            get { return close; }
        }

        public static RoutedUICommand Help
        {
            get { return help; }
        }

        public static RoutedUICommand About
        {
            get { return about; }
        }
    }
}
