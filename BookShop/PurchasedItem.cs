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

        public int Stock
        {
            get { return quantity; }
            set { this.quantity = value; }
        }

        public PurchasedItem(int q, Book b)
        {
            quantity = q;
            book = b;
        }
    }
}
