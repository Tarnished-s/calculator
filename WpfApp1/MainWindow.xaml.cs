using System;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in MainGrid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = (string)((Button)e.OriginalSource).Content;

                if (str == "AC")
                    textLabel.Text = string.Empty;
                else if (str == "x")
                    textLabel.Text = textLabel.Text.Substring(textLabel.Text.Length - 1);
                else if (str == "+/-")
                {
                    int a = int.Parse(textLabel.Text);
                    if (a > 0)
                        textLabel.Text = textLabel.Text.Insert(0, "-");
                    else
                        textLabel.Text = textLabel.Text.Substring(1);
                }
                else if (str == "=")
                {
                    textLabel.Text = new DataTable().Compute(textLabel.Text, null).ToString();

                }
                else if (str == "BackSpace")
                    textLabel.Text = textLabel.Text.Remove(textLabel.Text.Length - 1);
                else
                    textLabel.Text += str;



            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

     
    }
}
  
