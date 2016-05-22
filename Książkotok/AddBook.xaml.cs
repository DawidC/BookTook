using System;
using System.Collections.Generic;
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

namespace Książkotok
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

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=False;Compress=True;");
            
            sqlite_conn.Open();
            
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            //sqlite_cmd.CommandText = "CREATE TABLE Ksiazki (Id integer primary key, Autor varchar(100), Tytul varchar(100), ISBN varchar(100), Gatunek varchar(100), RokWyd integer, Uwagi varchar(100));";

            // Now lets execute the SQL ;D
            // sqlite_cmd.ExecuteNonQuery();
            
            string wej="";
            string przerwa = "', '";
            string pocz = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi) VALUES ('";
            string koniec = "');";
            wej = pocz + textBox_autor.Text + przerwa + textBox_tytul.Text + przerwa + textBox_isbn.Text + przerwa + textBox_gatunek.Text + przerwa + textBox_rokwyd.Text + przerwa +
                  textBox_uwagi.Text + koniec;


            // sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi) VALUES ('namee', 'Dziady', '123421', 'Wojenne', '2010', 'Brak');";
            sqlite_cmd.CommandText = wej;
            sqlite_cmd.ExecuteNonQuery();

            MessageBox.Show("Wpis dodany !");

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            /*
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=False;Compress=False;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();


            // Lets insert something into our new table:
           // sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi) VALUES ('Mickiewicz', 'Dziady', '123421', 'Wojenne', '2010', 'Brak');";
            sqlite_cmd.CommandText =
                "INSERT INTO 'main'.'Ksiazki' ('Autor','Tytul','ISBN','Gatunek','RokWyd','Uwagi') VALUES ('Mickiewicz', 'Dziady', '123421', 'Wojenne', '2010', 'Brak')";
                                    
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

          
            sqlite_cmd.CommandText = "SELECT * FROM test";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                //System.Console.WriteLine(sqlite_datareader["text"]);
                string data = sqlite_datareader.GetString(1);
                MessageBox.Show(data);

            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            */
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

        private void textBox_gatunek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_rokwyd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_uwagi_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
