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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Finisar.SQLite;

namespace Książkotok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        Book tmpp;
        Book tmpBook;
        public MainWindow()
        {
            InitializeComponent();
            wyswietl();
            
        }

        public void wyswietl()
        {
            List<Book> items = new List<Book>();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=False;Compress=True;");

            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM Ksiazki";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            int i = 0;
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                //System.Console.WriteLine(sqlite_datareader["text"]);
                string dataId = sqlite_datareader.GetString(0);
                string dataAutor = sqlite_datareader.GetString(1);
                string dataTytul = sqlite_datareader.GetString(2);
                string dataISBN = sqlite_datareader.GetString(3);
                string dataGatunek = sqlite_datareader.GetString(4);
                string dataRokwyd = sqlite_datareader.GetString(5);
                string dataUwagi = sqlite_datareader.GetString(6);
                // MessageBox.Show(data);
                items.Add(new Book() { Id = dataId, Autor = dataAutor, Tytul = dataTytul, ISBN = dataISBN, Gatunek = dataGatunek, Rokwyd = dataRokwyd, Uwagi = dataUwagi });

            }
            lvBooks.ItemsSource = items;
            sqlite_conn.Close();

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddBook okno = new AddBook();
            okno.Show();
            
        }
        

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            List<Book> items3 = new List<Book>();
            //items3.Add(new Book() { Id = 1, Autor = "Kowalski" });
            lvBooks.ItemsSource = items3;


        }

        private void button_odswiez_Click(object sender, RoutedEventArgs e)
        {
            wyswietl();
        }
    }
}
