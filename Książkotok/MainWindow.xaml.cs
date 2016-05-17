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

namespace Książkotok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> items = new List<Book>();
        
        Book tmpp;
        Book tmpBook;
        public MainWindow()
        {
            InitializeComponent();

            // tmpBook.Id = 9;
            
            tmpBook = new Book() {Author = "Grzyb",Id=12};
            items.Add(new Book() { Id = 1, Author = "Kowalski" });
            items.Add(tmpBook);
            lvBooks.ItemsSource = items;
        }
        

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddBook okno = new AddBook();
            okno.Show();
            
            tmpp = okno.book();
           // MessageBox.Show(tmpp.Author);
            items.Add(okno.book());
            items.Add(new Book() {Author = "Julcia"});
          //  lvBooks.ItemsSource = items;
        }
    }
}
