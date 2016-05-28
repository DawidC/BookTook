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
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void buttondodaj_Click(object sender, RoutedEventArgs e)
        {
            string wej = "";
            string przerwa = "', '";
            string pocz = "INSERT INTO Uzytkownicy (Imie, Nazwisko, Email, Telefon, Typkonta, IloscKsiazek, Flaga) VALUES ('";
            string koniec = "');";
            DateTime date1 = DateTime.Now;

            if (textBoximie.Text == "" || textBoxnazwisko.Text ==
                    "" || textBoxemail.Text == "" || textBoxtelefon.Text == "" || comboBoxtypkonta.Text == "") 
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
            else
            {
                wej = pocz + textBoximie.Text + przerwa + textBoxnazwisko.Text + przerwa + textBoxemail.Text + przerwa +
                     textBoxtelefon.Text + przerwa + comboBoxtypkonta.Text + przerwa + "0" + przerwa + "1" + koniec;

                SingletonWithoutLocks.Instance.DBCommand(wej);

                MessageBox.Show("Wpis dodany !");
                textBoximie.Text = "";
                textBoxnazwisko.Text = "";
                textBoxemail.Text = "";
                textBoxtelefon.Text = "";
                comboBoxtypkonta.Text = "";
            }
        }
    }
}
