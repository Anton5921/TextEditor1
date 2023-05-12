using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TextEditor
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(filename);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    filename = saveFileDialog.FileName;
                }
            }
            File.WriteAllText(filename, textBox.Text);
        }

      

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBox.SelectedText);
            textBox.Focus();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            int oldLength = textBox.Text.Length;
            textBox.SelectedText = Clipboard.GetText();
            int newLength = textBox.Text.Length;
            textBox.Select(textBox.SelectionStart + newLength - oldLength, 0);
            textBox.Focus();
            textBox.FontWeight = FontWeights.Normal;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText = "";
        }

        private void Thin_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontWeight = FontWeights.Thin;
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontWeight = FontWeights.Normal;
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontWeight = FontWeights.Bold;
        }
        
         private void TextColor_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string colorName = menuItem.Tag.ToString();
            Color color = (Color)ColorConverter.ConvertFromString(colorName);
            textBox.Foreground = new SolidColorBrush(color);
        }

        private string filename;

    }
}
