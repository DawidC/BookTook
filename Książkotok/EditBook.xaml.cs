using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
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
using Finisar.SQLite;

namespace BookTook
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        public EditBook()
        {
            InitializeComponent();

        }

        string index;
        public EditBook(int n)
        {
            InitializeComponent();
            string[] ciag= new string[n+1];
            int licznik = 0;
            SingletonWithoutLocks.Instance.DBCounter(n, ref ciag, ref licznik);
            index = ciag[n];

            string Autor = "";
            string Tytul = "";
            string ISBN = "";
            string Gatunek = "";
            string RokWyd = "";
            string Uwagi = "";
            string Flaga = "";
            SingletonWithoutLocks.Instance.DBEdit(index, ref Autor, ref Tytul, ref ISBN, ref Gatunek, ref RokWyd, ref Uwagi, ref Flaga);
            textBox_autor.Text = Autor;
            textBox_tytul.Text = Tytul;
            textBox_isbn.Text = ISBN;
            comboBox.Text = Gatunek;
            textBox_rokwyd.Text = RokWyd;
            textBox_uwagi.Text = Uwagi;
            

        }
        private bool IsNumeric(object ValueToCheck)
        {
            double Dummy = 0;
            return double.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
        }
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            string wej = "";
            string pocz = "UPDATE Ksiazki SET ";
            int rokwyd;
            bool result = Int32.TryParse(textBox_rokwyd.Text, out rokwyd);
            DateTime date1 = DateTime.Now;

            if (textBox_autor.Text == "" || textBox_tytul.Text == "" || textBox_isbn.Text == "" ||
                textBox_rokwyd.Text == "" || comboBox.Text == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
            else if (!result)
            {
                label_zladata.Content = "Zły rok!";
            }
            else if (rokwyd > date1.Year)
            {
                label_zladata.Content = "Zły rok!";
            }
            else
            {
                wej = pocz + "Autor = '" + textBox_autor.Text + "', Tytul = '" + textBox_tytul.Text + "', ISBN = '" +
                      textBox_isbn.Text + "', Gatunek = '" +
                      comboBox.Text + "', Rokwyd = '" + textBox_rokwyd.Text + "', Uwagi ='" +
                      textBox_uwagi.Text + "' WHERE Id = " + index + ";";

                SingletonWithoutLocks.Instance.DBCommand(wej);

                MessageBox.Show("Zapisano!");
                textBox_autor.Text = "";
                textBox_tytul.Text = "";
                textBox_isbn.Text = "";
                textBox_rokwyd.Text = "";
                comboBox.Text = "";
                textBox_uwagi.Text = "";
                label_zladata.Content = "";
            }
            sender = "o";
        }

        private void button_usun_Click(object sender, RoutedEventArgs e)
        {
            string wej = "UPDATE Ksiazki SET Flaga = '0' WHERE Id = " + index +";";
            
            SingletonWithoutLocks.Instance.DBCommand(wej);

            MessageBox.Show("Usunięto!");
            textBox_autor.Text = "";
            textBox_tytul.Text = "";
            textBox_isbn.Text = "";
            textBox_rokwyd.Text = "";
            comboBox.Text = "";
            textBox_uwagi.Text = "";
            label_zladata.Content = "";
            
        }

        private void textBox_autor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_tytul_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_isbn_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_rokwyd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_uwagi_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
