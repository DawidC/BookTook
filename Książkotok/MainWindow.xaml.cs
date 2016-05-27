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
using Finisar.SQLite;

namespace BookTook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// SingletonSecured.Instance.DoSomething();
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            wyswietl();

        }
       
        public void wyswietl()
        {
            List<Book> items = new List<Book>();
            string tabl = "";
            SingletonWithoutLocks.Instance.DBDataReaderBooks(items);
            
            lvBooks.ItemsSource = items;

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddBook okno = new AddBook();
            okno.Show();
            
        }

        private void button_odswiez_Click(object sender, RoutedEventArgs e)
        {
            wyswietl();
        }

        private void button_szukaj_Click(object sender, RoutedEventArgs e)
        {
            string ciag = textBox_Copy.Text;
            if (ciag == ""||ciag == "Szukaj")
            {
                wyswietl();
            }
            else
            {
                List<Book> items = new List<Book>();
                SingletonWithoutLocks.Instance.DBSearch(ciag, items);
                lvBooks.ItemsSource = items;
            }
            
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_Copy.Text == "")
            {
                wyswietl();
            }
            else
            {
                List<Book> items = new List<Book>();
                SingletonWithoutLocks.Instance.DBSearch(textBox_Copy.Text, items);
                lvBooks.ItemsSource = items;
            }
        }

        int x =0;
        private void TextBox_Copy_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (x == 0)
            {
                textBox_Copy.Text = string.Empty;
                x++;
            }
            
            
        }

        private void LvBooks_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvBooks.SelectedItem != null)
            {
                int n = lvBooks.SelectedIndex;

                EditBook aa = new EditBook(n);

                aa.Show();
            }
        }
        void window_Deactivated(object sender, EventArgs e)
        {
            wyswietl();
            
        }

        void window_Activated(object sender, EventArgs e)
        {
            wyswietl();

        }
    }
}
