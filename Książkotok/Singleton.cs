using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Finisar.SQLite;

namespace BookTook
{
    public sealed class SingletonWithoutLocks
    {
        private static readonly SingletonWithoutLocks m_oInstance = new SingletonWithoutLocks();
        private int m_nCounter = 0;

        static SingletonWithoutLocks()
        {
        }

        public static SingletonWithoutLocks Instance
        {
            get
            {
                return m_oInstance;
            }
        }

        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        public void DBConnect()
        {
            //MessageBox.Show("Polaczenie nr " + m_nCounter++);
           
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=False;Compress=False;");
        }
        public void DBConnOpen()
        {
            DBConnect();
            sqlite_conn.Open();
            
        }

        public void DBConnClose()
        {
            sqlite_conn.Close();
        }

        public void DBCommand(string cmd)
        {
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = cmd;
            sqlite_cmd.ExecuteNonQuery();
            DBConnClose();
        }

        public void DBDataReaderBooks(List<Book> items)
        {

            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Ksiazki";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            int i = 0;
            while (sqlite_datareader.Read()) 
            {
                string dataId = sqlite_datareader.GetString(0);
                string dataAutor = sqlite_datareader.GetString(1);
                string dataTytul = sqlite_datareader.GetString(2);
                string dataISBN = sqlite_datareader.GetString(3);
                string dataGatunek = sqlite_datareader.GetString(4);
                string dataRokwyd = sqlite_datareader.GetString(5);
                string dataUwagi = sqlite_datareader.GetString(6);
                string dataDataWyp = sqlite_datareader.GetString(7);
                string dataDataOdd = sqlite_datareader.GetString(8);
                string dataFlaga = sqlite_datareader.GetString(10);

                if (dataFlaga == "1")
                {
                    items.Add(new Book() { Id = dataId, Autor = dataAutor, Tytul = dataTytul, ISBN = dataISBN, Rokwyd = dataRokwyd, Uwagi = dataUwagi, Gatunek = dataGatunek, DataWyp = dataDataWyp, DataOdd = dataDataOdd, Flaga = dataFlaga });
                    
                }
            }
            DBConnClose();
        }

        public void DBDataReaderUsers(List<User> items)
        {

            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Uzytkownicy";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            int i = 0;
            while (sqlite_datareader.Read())
            {
                string dataId = sqlite_datareader.GetString(0);
                string dataImie = sqlite_datareader.GetString(1);
                string dataNazwisko = sqlite_datareader.GetString(2);
                string dataEmail = sqlite_datareader.GetString(3);
                string dataTelefon = sqlite_datareader.GetString(4);
                string dataTypKonta = sqlite_datareader.GetString(5);
                string dataIloscKsiazek = sqlite_datareader.GetString(6);
                string dataFlaga = sqlite_datareader.GetString(7);

                if (dataFlaga == "1")
                {
                    items.Add(new User() { Id = dataId, Imie = dataImie, Email = dataEmail, Flaga = dataFlaga, IloscKsiazek = dataIloscKsiazek, Nazwisko = dataNazwisko, Telefon = dataTelefon, TypKonta = dataTypKonta});

                }
            }
            DBConnClose();
        }

        public void DBCreateNew()
        {
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=True;Compress=False;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            //ksiazki
            sqlite_cmd.CommandText = "CREATE TABLE Ksiazki (Id integer primary key, Autor varchar(100), Tytul varchar(100), ISBN varchar(100), Gatunek varchar(100), RokWyd integer, Uwagi varchar(100), DataWyp varchar(100), DataOdd varchar(100), Status varchar(10), Flaga varchar (10), IdUser varchar (10));";
            sqlite_cmd.ExecuteNonQuery();
            //uzytkownicy
            sqlite_cmd.CommandText = "CREATE TABLE Uzytkownicy (Id integer primary key, Imie varchar(100), Nazwisko varchar(100), Email varchar(100), Telefon varchar(20), TypKonta varchar(10), IloscKsiazek varchar(10), Flaga varchar(10));";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        

        public void DBCounter(int n, ref string[] ciag, ref int licznik, string table, int flagaid)
        {
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM "+table;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string dataId = sqlite_datareader.GetString(0);
                string dataFlaga = sqlite_datareader.GetString(flagaid);

                if (dataFlaga == "1"&&licznik <=n)
                {
                    
                    ciag[licznik] = dataId;
                    licznik++;
                }
            }
            DBConnClose();
        }

        public void DBEdit(string index, ref string Autor, ref string Tytul, ref string ISBN, ref string Gatunek, ref string RokWyd, ref string Uwagi, ref string Flaga)
        {
            List<Book> items = new List<Book>();
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Ksiazki WHERE Id ='" + index + "';";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Autor = sqlite_datareader.GetString(1);
                Tytul = sqlite_datareader.GetString(2);
                ISBN = sqlite_datareader.GetString(3);
                Gatunek = sqlite_datareader.GetString(4);
                RokWyd = sqlite_datareader.GetString(5);
                Uwagi = sqlite_datareader.GetString(6);
                //string dataDataWyp = sqlite_datareader.GetString(7);
               // string dataDataOdd = sqlite_datareader.GetString(8);
                Flaga = sqlite_datareader.GetString(10);
                
            }
            DBConnClose();
        }

        public void DBEditUser(string index, ref string Imie, ref string Nazwisko, ref string Email, ref string Telefon, ref string TypKonta, ref string IloscKsiazek, ref string Flaga)
        {
            List<User> items = new List<User>();
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Uzytkownicy WHERE Id ='" + index + "';";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Imie = sqlite_datareader.GetString(1);
                Nazwisko = sqlite_datareader.GetString(2);
                Email = sqlite_datareader.GetString(3);
                Telefon = sqlite_datareader.GetString(4);
                TypKonta = sqlite_datareader.GetString(5);
                IloscKsiazek = sqlite_datareader.GetString(6);
                Flaga = sqlite_datareader.GetString(7);

            }
            DBConnClose();
        }

        public void DBFillDefault()
        {
            //TODO: zrobic domyslne dane do wypelnianaia
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi, Flaga) VALUES ('Dawid Czarneta','BookTook','133','Przygodowa','2016','Brak','1');"; ;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi, Flaga) VALUES ('Adam Mickiewicz','Dziady','3221','Proza','1995','arak','1');"; ;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi, Flaga) VALUES ('Afsd','qwee','42334','Przygodowa','222','asdsad','0');"; ;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi, Flaga) VALUES ('Kochanowski','Ferdydurke','123423','Przygodowa','422','asdsad','0');"; ;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Ksiazki (Autor, Tytul, ISBN, Gatunek, RokWyd, Uwagi, Flaga) VALUES ('Kochanowski','Ferdydurke','123423','Przygodowa','422','asdsad','1');"; ;
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO Uzytkownicy (Imie, Nazwisko, Email, Telefon, TypKonta, IloscKsiazek, Flaga) VALUES ('Jan', 'Kowalski', 'j.kowalski@gmail.com', '123123123', 'Zwykle', '5', '1');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Uzytkownicy (Imie, Nazwisko, Email, Telefon, TypKonta, IloscKsiazek, Flaga) VALUES ('asdd', 'saddsa', 'dsddsdsil.com', '66422123', 'Adminadator', '0', '0');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Uzytkownicy (Imie, Nazwisko, Email, Telefon, TypKonta, IloscKsiazek, Flaga) VALUES ('Dawid', 'Czarneta', 'dawidczarneta@gmail.com', '665123123', 'Administrator', '0', '1');";
            sqlite_cmd.ExecuteNonQuery();
            DBConnClose();
        }

        public string[] listId = new string[255];
        public void DBSearch(string ciag, List<Book> items)
        {
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Ksiazki WHERE Autor LIKE '%" + ciag + "%' OR Tytul LIKE '%" + ciag + "%' OR Id LIKE '%" + ciag + "%' OR ISBN LIKE '%" + ciag + "%' OR Gatunek LIKE '%" + ciag + "%' OR RokWyd LIKE '%" + ciag + "%' OR Uwagi LIKE '%" + ciag + "%'";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            //string listId = "";
            int i = 0;
            while (sqlite_datareader.Read())
            {
                string dataId = sqlite_datareader.GetString(0);
                string dataAutor = sqlite_datareader.GetString(1);
                string dataTytul = sqlite_datareader.GetString(2);
                string dataISBN = sqlite_datareader.GetString(3);
                string dataGatunek = sqlite_datareader.GetString(4);
                string dataRokwyd = sqlite_datareader.GetString(5);
                string dataUwagi = sqlite_datareader.GetString(6);
                string dataDataWyp = sqlite_datareader.GetString(7);
                string dataDataOdd = sqlite_datareader.GetString(8);
                string dataFlaga = sqlite_datareader.GetString(10);
                if (dataFlaga == "1")
                {
                    items.Add(new Book() { Id = dataId, Autor = dataAutor, Tytul = dataTytul, ISBN = dataISBN, Rokwyd = dataRokwyd, Uwagi = dataUwagi, Gatunek = dataGatunek, DataWyp = dataDataWyp, DataOdd = dataDataOdd, Flaga = dataFlaga });
                    listId[i] = dataId;
                    i++;
                }
            }
            DBConnClose();
        }

        
        public void DBSearchUser(string ciag, List<User> items)
        {
            DBConnOpen();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM Uzytkownicy WHERE Imie LIKE '%" + ciag + "%' OR Nazwisko LIKE '%" + ciag + "%' OR Id LIKE '%" + ciag + "%' OR Email LIKE '%" + ciag + "%' OR Telefon LIKE '%" + ciag + "%' OR TypKonta LIKE '%" + ciag + "%' ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string dataId = sqlite_datareader.GetString(0);
                string dataImie = sqlite_datareader.GetString(1);
                string dataNazwisko = sqlite_datareader.GetString(2);
                string dataEmail = sqlite_datareader.GetString(3);
                string dataTelefon = sqlite_datareader.GetString(4);
                string dataTypKonta = sqlite_datareader.GetString(5);
                string dataIloscKsiazek = sqlite_datareader.GetString(6);
                string dataFlaga = sqlite_datareader.GetString(7);
                if (dataFlaga == "1")
                {
                    items.Add(new User() { Id = dataId, Flaga = dataFlaga, Imie = dataImie, Email = dataEmail, Nazwisko = dataNazwisko, IloscKsiazek = dataIloscKsiazek, Telefon = dataTelefon, TypKonta = dataTypKonta});
                    
                }
            }
            DBConnClose();
        }

        private SingletonWithoutLocks()
        {
            m_nCounter = 1;
        }


    }
}
