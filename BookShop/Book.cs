using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    class Book
    {
        private string _title;
        private string _author;
        private string _publisher;
        private string _isbn;
        private decimal _price;
        private string _date;
        private int _stock;

        public Book(string t, string a, string p, string i, decimal price, string d, int s)
        {
            this._title = t;
            this._author = a;
            this._publisher = p;
            this._isbn = i;
            this._price = price;
            this._date = d;
            this._stock = s;
        }

    }
}
