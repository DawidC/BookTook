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
    public partial class AddBook : Window
    {

        public AddBook()
        {
            InitializeComponent();

        }
        private bool IsNumeric(object ValueToCheck)
        {
            double Dummy = 0;
            return double.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
        }
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            string wej = "";
            string przerwa = "', '";
            string pocz = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi, Flaga) VALUES ('";
            string koniec = "');";
            int rokwyd;
            bool result = Int32.TryParse(textBox_rokwyd.Text,out rokwyd);
            DateTime date1 = DateTime.Now;

            if (textBox_autor.Text == "" || textBox_tytul.Text == "" || textBox_isbn.Text == "" ||
                textBox_rokwyd.Text == "" || comboBox.Text == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            } else if (!result)
            {
                label_zladata.Content = "Zły rok!";
            } else if (rokwyd > date1.Year)
            {
                label_zladata.Content = "Zły rok!";
            }
            else
            {
                wej = pocz + textBox_autor.Text + przerwa + textBox_tytul.Text + przerwa + textBox_isbn.Text + przerwa +
                      comboBox.Text + przerwa + textBox_rokwyd.Text + przerwa +
                      textBox_uwagi.Text + przerwa + "1" +koniec;

                SingletonWithoutLocks.Instance.DBCommand(wej);
                string id = "";
                SingletonWithoutLocks.Instance.DBLastElement(ref id, "Ksiazki");
                int intid = Convert.ToInt32(id);
                string booklp = "1";
                SingletonWithoutLocks.Instance.DBCommand("INSERT INTO KartaKsiazki (BookId, BookLp, DataWyp, DataOdd, UId) VALUES ('"+intid+"', '"+booklp +"', '1','1','0');");
                MessageBox.Show("Wpis dodany !");
                textBox_autor.Text = "";
                textBox_tytul.Text = "";
                textBox_isbn.Text = "";
                textBox_rokwyd.Text = "";
                comboBox.Text = "";
                textBox_uwagi.Text = "";
                label_zladata.Content = "";
            }
            
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
