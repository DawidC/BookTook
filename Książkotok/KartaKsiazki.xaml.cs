using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KartaKsiazki.xaml
    /// </summary>
    public partial class KartaKsiazki : Window
    {
        public string tmpn = "";
        string index;
        int GlobalN;
        TextBox Globaltmp;
        public KartaKsiazki(int n, TextBox tmp)
        {
            InitializeComponent();
            GlobalN = n;
            Globaltmp = tmp;
            string bookid = "";
            string bookautor = "";
            string userid = "";
            string datawyp = "";
            string dataodd = "";
            string booklp = "";
            string booktytul = "";
            string bookisbn = "";
            string bookgatunek = "";
            string bookrokwyd = "";
            string bookuwagi = "";

            
            string[] ciag = new string[n + 1];
            int licznik = 0;
            
            SingletonWithoutLocks.Instance.DBCounter(n, ref ciag, ref licznik, "Ksiazki", 10);
           
            tmpn = n.ToString();
            
            if (tmp.Text == "" || tmp.Text == "Szukaj")
             {
                 index = ciag[n];
             }
             else
             {
                  index = SingletonWithoutLocks.Instance.listId[n];
             }

            int x = Convert.ToInt32(index);
            List<ClassKK> items = new List<ClassKK>();
            SingletonWithoutLocks.Instance.DBKK(x, ref bookid, ref bookautor,ref userid, ref booklp, ref datawyp, ref dataodd, ref booktytul, ref bookisbn, ref bookgatunek, 
                ref bookrokwyd, ref bookuwagi, items);

            listView.ItemsSource = items;
            

            label_id.Content = bookid;
            label_autor.Content = bookautor;
            label_tytul.Content = booktytul;
            label_isbn.Content = bookisbn;
            label_gatunek.Content = bookgatunek;
            label_rokwyd.Content = bookrokwyd;


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Lp", ListSortDirection.Ascending));
        }

        private void button_wypozycz_Click(object sender, RoutedEventArgs e)
        {
            KartaKsiazkiWypozycz a = new KartaKsiazkiWypozycz(index);
            a.Show();

        }

        private void KartaKsiazki_OnDeactivated(object sender, EventArgs e)
        {
            string bookid = "";
            string bookautor = "";
            string userid = "";
            string datawyp = "";
            string dataodd = "";
            string booklp = "";
            string booktytul = "";
            string bookisbn = "";
            string bookgatunek = "";
            string bookrokwyd = "";
            string bookuwagi = "";


            string[] ciag = new string[GlobalN + 1];
            int licznik = 0;

            SingletonWithoutLocks.Instance.DBCounter(GlobalN, ref ciag, ref licznik, "Ksiazki", 10);

            tmpn = GlobalN.ToString();

            if (Globaltmp.Text == "" || Globaltmp.Text == "Szukaj")
            {
                index = ciag[GlobalN];
            }
            else
            {
                index = SingletonWithoutLocks.Instance.listId[GlobalN];
            }

            int x = Convert.ToInt32(index);
            List<ClassKK> items = new List<ClassKK>();
            SingletonWithoutLocks.Instance.DBKK(x, ref bookid, ref bookautor, ref userid, ref booklp, ref datawyp, ref dataodd, ref booktytul, ref bookisbn, ref bookgatunek,
                ref bookrokwyd, ref bookuwagi, items);

            listView.ItemsSource = items;


            label_id.Content = bookid;
            label_autor.Content = bookautor;
            label_tytul.Content = booktytul;
            label_isbn.Content = bookisbn;
            label_gatunek.Content = bookgatunek;
            label_rokwyd.Content = bookrokwyd;
        }

        private void KartaKsiazki_OnActivated(object sender, EventArgs e)
        {
            string bookid = "";
            string bookautor = "";
            string userid = "";
            string datawyp = "";
            string dataodd = "";
            string booklp = "";
            string booktytul = "";
            string bookisbn = "";
            string bookgatunek = "";
            string bookrokwyd = "";
            string bookuwagi = "";


            string[] ciag = new string[GlobalN + 1];
            int licznik = 0;

            SingletonWithoutLocks.Instance.DBCounter(GlobalN, ref ciag, ref licznik, "Ksiazki", 10);

            tmpn = GlobalN.ToString();

            if (Globaltmp.Text == "" || Globaltmp.Text == "Szukaj")
            {
                index = ciag[GlobalN];
            }
            else
            {
                index = SingletonWithoutLocks.Instance.listId[GlobalN];
            }

            int x = Convert.ToInt32(index);
            List<ClassKK> items = new List<ClassKK>();
            SingletonWithoutLocks.Instance.DBKK(x, ref bookid, ref bookautor, ref userid, ref booklp, ref datawyp, ref dataodd, ref booktytul, ref bookisbn, ref bookgatunek,
                ref bookrokwyd, ref bookuwagi, items);

            listView.ItemsSource = items;


            label_id.Content = bookid;
            label_autor.Content = bookautor;
            label_tytul.Content = booktytul;
            label_isbn.Content = bookisbn;
            label_gatunek.Content = bookgatunek;
            label_rokwyd.Content = bookrokwyd;
        }

        DateTime date1 = DateTime.Now;
        private void button_zwroc_Click(object sender, RoutedEventArgs e)
        {
            //index <- index książki
            string data = date1.Day + "." + date1.Month + "." + date1.Year;
            string lp = "";
            string column = "BookId";
            SingletonWithoutLocks.Instance.DBLastLp(ref lp, "KartaKsiazki", index, column);
            int booklp = Convert.ToInt32(lp);
            //booklp--;

            SingletonWithoutLocks.Instance.DBCommand("UPDATE KartaKsiazki SET DataOdd = '"+data+ "' WHERE BookId = " + index + " AND BookLp = "+booklp+";");
            MessageBox.Show("Zwrócono pomyślnie.");
        }
    }
}
