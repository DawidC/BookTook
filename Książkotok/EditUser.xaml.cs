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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
        }

        public string tmpn = "";
        string index="";
        public EditUser(int n, TextBox a)
        {
            InitializeComponent();
            string[] ciag = new string[n + 1];
            int licznik = 0;
            SingletonWithoutLocks.Instance.DBCounter(n, ref ciag, ref licznik, "Uzytkownicy",7);
            tmpn = n.ToString();
            if (a.Text == "" || a.Text == "Szukaj")
            {
                index = ciag[n];
            }
            else
            {
                index = SingletonWithoutLocks.Instance.listId[n];
            }

            string imie = "";
            string nazwisko = "";
            string email = "";
            string telefon = "";
            string typkonta = "";
            string iloscksiazek = "";
            string flaga = "";
            SingletonWithoutLocks.Instance.DBEditUser(index,ref imie,ref nazwisko,ref email, ref telefon, ref typkonta, ref iloscksiazek, ref flaga);
            textBoximie.Text = imie;
            textBoxnazwisko.Text = nazwisko;
            textBoxemail.Text = email;
            textBoxtelefon.Text = telefon;
            comboBoxtypkonta.Text = typkonta;
            //iloscksiazek;
            //flaga;
        }

        private void button_usun_Click(object sender, RoutedEventArgs e)
        {
            string wej = "UPDATE Uzytkownicy SET Flaga = '0' WHERE Id = " + index + ";";

            SingletonWithoutLocks.Instance.DBCommand(wej);

            MessageBox.Show("Usunięto!");
            textBoximie.Text = "";
            textBoxnazwisko.Text = "";
            textBoxemail.Text = "";
            textBoxtelefon.Text = "";
            comboBoxtypkonta.Text = "";
        }

        private void button_zapisz_Click(object sender, RoutedEventArgs e)
        {
            string wej = "";
            string pocz = "UPDATE Uzytkownicy SET ";

            if (textBoximie.Text == "" || textBoxnazwisko.Text ==
                    "" || textBoxemail.Text == "" || textBoxtelefon.Text == "" || comboBoxtypkonta.Text == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
            else
            {
                wej = pocz + "Imie = '" + textBoximie.Text + "', Nazwisko = '" + textBoxnazwisko.Text + "', Email = '" +
                      textBoxemail.Text + "', Telefon = '" +
                      textBoxtelefon.Text + "', TypKonta = '" + comboBoxtypkonta.Text + "' WHERE Id = " + index + ";";

                SingletonWithoutLocks.Instance.DBCommand(wej);

                MessageBox.Show("Zapisano!");
                textBoximie.Text = "";
                textBoxnazwisko.Text = "";
                textBoxemail.Text = "";
                textBoxtelefon.Text = "";
                comboBoxtypkonta.Text = "";
            }
        }
    }
}
