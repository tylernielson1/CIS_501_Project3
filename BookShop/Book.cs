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
            set { isbn = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public Book(string t, string a, string p, string i, decimal price, string d, int s)
        {
            this.Title = t;
            this.Author = a;
            this.Publisher = p;
            this.isbn = i;
            this.Price = price;
            this.Date = d;
            this.Stock = s;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Title + " ");
            sb.Append(Author + " ");
            sb.Append(Publisher + " ");
            sb.Append(isbn + " ");
            sb.Append(Price + " ");
            sb.Append(Date + " ");
            sb.Append(Stock);
            return sb.ToString();
        }

    }
}
