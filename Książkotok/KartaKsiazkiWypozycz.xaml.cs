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
using System.Windows.Shapes;

namespace BookTook
{
    /// <summary>
    /// Interaction logic for KartaKsiazkiWypozycz.xaml
    /// </summary>
    
    
    public partial class KartaKsiazkiWypozycz : Window
    {
        public string tmpn = "";
        string index;
        public KartaKsiazkiWypozycz(string indexksiazki)
        {
            InitializeComponent();


            List<User> items = new List<User>();
            SingletonWithoutLocks.Instance.DBDataReaderUsers(items);
            listView.ItemsSource = items;
            index = indexksiazki;
        }

        int x = 0;
        private void TextBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (x == 0)
            {
                textBox.Text = "";
                x++;
            }
            
            
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text == "")
            {
                List<User> items = new List<User>();
                SingletonWithoutLocks.Instance.DBDataReaderUsers(items);
                listView.ItemsSource = items;
            }
            else
            {
                List<User> items = new List<User>();
                SingletonWithoutLocks.Instance.DBSearchUser(textBox.Text, items);
                listView.ItemsSource = items;
            }
        }

        DateTime date1 = DateTime.Now;
        string index2="";
        private void button_wypozycz_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null)
            {
                MessageBox.Show("Wybierz osobę z listy!");
            }
            else
            {
                int l = listView.SelectedIndex;
                string[] ciag = new string[l + 1];
                int licznik = 0;

                SingletonWithoutLocks.Instance.DBCounter(l, ref ciag, ref licznik, "Uzytkownicy", 7);
                
                if (textBox.Text == "" || textBox.Text == "Szukaj")
                {
                    index2 = ciag[l];
                }
                else
                {
                    index2 = SingletonWithoutLocks.Instance.listId[l];
                }
            }

            //index <- index książki
            //index2 <- index usera
            string data = date1.Day + "." + date1.Month + "." + date1.Year;
            string lp = "";
            SingletonWithoutLocks.Instance.DBLastLpAll(ref lp, "KartaKsiazki",index);
            int booklp = Convert.ToInt32(lp);
            booklp++;
            SingletonWithoutLocks.Instance.DBCommand("INSERT INTO KartaKsiazki(BookId, BookLp, DataWyp, DataOdd, UId) VALUES('"+index+"', '"+booklp +"', '"+data+"', '0', '"+index2+"'); ");

        }
    }
}
