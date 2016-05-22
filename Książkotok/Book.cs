using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Książkotok
{
    public class Book
    {
        public string Id { get; set; } //int
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Gatunek { get; set; }
        public string Rokwyd { get; set; } //int
        public string Uwagi { get; set; }

    }
}
