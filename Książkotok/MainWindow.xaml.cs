using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            wyswietl();
            wyswietlU();

        }
       
        public void wyswietl()
        {
            List<Book> items = new List<Book>();
            SingletonWithoutLocks.Instance.DBDataReaderBooks(items);
            
            lvBooks.ItemsSource = items;

        }

        public void wyswietlU()
        {
            List<User> items = new List<User>();
            SingletonWithoutLocks.Instance.DBDataReaderUsers(items);

            lvUsers.ItemsSource = items;
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

        int y = 0;
        private void TextBox1_Copy_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (y == 0)
            {
                textBox_Copy1.Text = string.Empty;
                y++;
            }
        }

        private void LvBooks_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int n = lvBooks.SelectedIndex;
            KartaKsiazki aa = new KartaKsiazki(n, textBox_Copy);



            aa.Show();
        }

        

        private void Lvusers_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }



        void window_Deactivated(object sender, EventArgs e)
        {
           //wyswietl();
            
        }

        void window_Activated(object sender, EventArgs e)
        {
           //wyswietl();

        }

        private void button_userAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser a = new AddUser();
            a.Show();
        }

        private void button1_odswiez_Click(object sender, RoutedEventArgs e)
        {
            wyswietlU();
        }

        private void button1_szukaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Copy1.Text == "" || textBox_Copy1.Text == "Szukaj")
            {
                wyswietl();
            }
            else
            {
                List<User> items = new List<User>();
                SingletonWithoutLocks.Instance.DBSearchUser(textBox_Copy1.Text, items);
                lvUsers.ItemsSource = items;
            }
        }

        private void textBox_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_Copy1.Text == "" || textBox_Copy1.Text == "Szukaj")
            {
                wyswietl();
            }
            else
            {
                List<User> items = new List<User>();
                SingletonWithoutLocks.Instance.DBSearchUser(textBox_Copy1.Text, items);
                lvUsers.ItemsSource = items;
            }
        }

        private void button_edytuj_book_Click(object sender, RoutedEventArgs e)
        {
            if (lvBooks.SelectedItem != null)
            {
                int n = lvBooks.SelectedIndex;
                EditBook aa = new EditBook(n, textBox_Copy);

                aa.Show();
            }
        }

        private void button_edytuj_user_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItem != null)
            {
                int n = lvUsers.SelectedIndex;
                EditUser a = new EditUser(n, textBox_Copy1);
                a.Show();

            }
        }
    }
}
