using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class PurchasedItem
    {
        private int quantity;
        private Book book;

        public int Quantity
        {
            get { return quantity; }
            set { this.quantity = value; }
        }
        public Book Book
        {
            get { return book; }
        }

        public PurchasedItem(Book b, int q)
        {
            quantity = q;
            book = b;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(book.Title + " BY " + book.Author + " : " + quantity);
            return sb.ToString();
        }
    }
}
