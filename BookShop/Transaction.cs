using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    [Serializable]
    public class Transaction
    {
        private decimal totalPrice;
        private Customer customer;
        private List<PurchasedItem> cart = new List<PurchasedItem>();

        public Transaction(Customer c)
        {
            customer = c;
        }

        public List<PurchasedItem> Cart
        {
            get { return cart; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public decimal Price
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(PurchasedItem p in cart)
            {
                sb.Append(p.Book.Title + "(" + p.Quantity + ")" + ",  ");
            }
            return sb.ToString();
        }
    }
}
