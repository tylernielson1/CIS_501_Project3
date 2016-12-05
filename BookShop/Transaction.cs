using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Transaction
    {
        private double totalPrice;
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

        /*public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(PurchasedItem p in cart)
            {
                sb.Append
            }
        }*/
    }
}
