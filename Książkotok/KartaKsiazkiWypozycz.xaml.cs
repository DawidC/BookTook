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
            /*if (textBox.Text == "")
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
            }*/
        }

        DateTime date1 = DateTime.Now;
        string index2="";
        string index3 = "a";
        private void button_wypozycz_Click(object sender, RoutedEventArgs e)
        {
            string data = date1.Day + "." + date1.Month + "." + date1.Year;
            string lp = "";
            // MessageBox.Show(index);
            int fl = 0;
            SingletonWithoutLocks.Instance.DBLastLp(ref lp, "KartaKsiazki", index, "BookId", ref fl);
            int booklp = Convert.ToInt32(lp);
            booklp++;
            //SingletonWithoutLocks.Instance.DBCounter(, ref ciag, ref licznik, "Uzytkownicy", 7);
            if (fl == 2)
            {
                if (index3 == "a")
                {
                    
                }
                if (listView.SelectedItem == null)
                {
                    MessageBox.Show("Wybierz osobę z listy!");
                }
                else
                {
                    int l = listView.SelectedIndex;
                    
                    string[] ciag = new string[l + 1];
                    int licznik = 0;
                    //MessageBox.Show(l.ToString());
                    SingletonWithoutLocks.Instance.DBCounter(l, ref ciag, ref licznik, "Uzytkownicy", 7);
                    // MessageBox.Show(l.ToString());
                    
                    if (textBox.Text == "" || textBox.Text == "Szukaj")
                    {
                        index2 = ciag[l];
                    }
                    else
                    {
                        index2 = SingletonWithoutLocks.Instance.listId2[l];
                    }
                    //MessageBox.Show(index2);
                    //index <- index książki
                    //index2 <- index usera

                    // MessageBox.Show(fl.ToString());
                    SingletonWithoutLocks.Instance.DBCommand(
                        "INSERT INTO KartaKsiazki(BookId, BookLp, DataWyp, DataOdd, UId) VALUES('" + index + "', '" +
                        booklp + "', '" + data + "', '0', '" + index2 + "'); ");
                    MessageBox.Show("Wypożyczono!");
                    Close();
                }
            }
            else
            {
               // MessageBox.Show(index3);
                MessageBox.Show("Musisz najpierw zwrócić książkę!");
            }
            //MessageBox.Show(fl.ToString());
            }

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (textBox.Text == "")
                {
                    List<User> items = new List<User>();
                    SingletonWithoutLocks.Instance.DBDataReaderUsers(items);
                    listView.ItemsSource = items;
                }
                else
                {
                    int n = listView.SelectedIndex;
                    index3 = n.ToString();
                    List<User> items = new List<User>();
                    SingletonWithoutLocks.Instance.DBSearchUser2(textBox.Text, items);
                    listView.ItemsSource = items;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                List<User> items = new List<User>();
                SingletonWithoutLocks.Instance.DBDataReaderUsers(items);
                listView.ItemsSource = items;
            }
            else
            {
                int n = listView.SelectedIndex;
                index3 = n.ToString();
                List<User> items = new List<User>();
                SingletonWithoutLocks.Instance.DBSearchUser2(textBox.Text, items);
                listView.ItemsSource = items;
            }
        }
    }
}


