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
    /// Interaction logic for KartaUzytkownika.xaml
    /// </summary>
    public partial class KartaUzytkownika : Window
    {
        public KartaUzytkownika()
        {
            InitializeComponent();
        }
        public string tmpn = "";
        string index;
        public KartaUzytkownika(int n, TextBox a)
        {
            InitializeComponent();
            string[] ciag = new string[n + 1];
            int licznik = 0;
            SingletonWithoutLocks.Instance.DBCounter(n, ref ciag, ref licznik, "Uzytkownicy", 7);
            tmpn = n.ToString();


            if (a.Text == "" || a.Text == "Szukaj")
            {
                index = ciag[n];
            }
            else
            {
                index = SingletonWithoutLocks.Instance.listId2[n];
            }
            // MessageBox.Show(index);
            List<ClassKU> items = new List<ClassKU>();
            SingletonWithoutLocks.Instance.DBKUQuery(index, items);
            listView.ItemsSource = items;
        }
    }
}
