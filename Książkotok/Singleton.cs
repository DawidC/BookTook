using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Finisar.SQLite;

namespace BookTook
{
    public sealed class SingletonSecured
    {
        private static SingletonSecured m_oInstance = null;
        private static readonly object m_oPadLock = new object();
        private int m_nCounter = 0;

        public static SingletonSecured Instance
        {
            get
            {
                lock (m_oPadLock)
                {
                    if (m_oInstance == null)
                    {
                        m_oInstance = new SingletonSecured();
                    }
                    return m_oInstance;
                }
            }
        }

        public void DBConnect()
        {
            MessageBox.Show("Polaczenie nr "+ m_nCounter++);
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=False;Compress=True;");
        }
        

        private SingletonSecured()
        {
            m_nCounter = 1;
        }
    }

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
        public void DBConnect()
        {
            MessageBox.Show("Polaczenie nr " + m_nCounter++);
           
            sqlite_conn = new SQLiteConnection("Data Source=Ksiazkotok.db;Version=3;New=False;Compress=False;");
        }
        public void DBConnOpen()
        {
            DBConnect();
            sqlite_conn.Open();
        }

        public void DBCommand()
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
        }

        private SingletonWithoutLocks()
        {
            m_nCounter = 1;
        }
    }
}
