using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Book
    {
        private string title;
        private string author;
        private string publisher;
        private string isbn;
        private decimal price;
        private string date;
        private int stock;

        public string ISBN
        {
            get { return isbn; }
        }

        public Book(string t, string a, string p, string i, decimal price, string d, int s)
        {
            this.title = t;
            this.author = a;
            this.publisher = p;
            this.isbn = i;
            this.price = price;
            this.date = d;
            this.stock = s;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(title + " ");
            sb.Append(author + " ");
            sb.Append(publisher + " ");
            sb.Append(isbn + " ");
            sb.Append(price + " ");
            sb.Append(date + " ");
            sb.Append(stock + " ");
            return sb.ToString();
        }

    }
}
