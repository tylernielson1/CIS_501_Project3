using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string email;
        private string address;
        private string phoneNumber;
        private List<Book> wishlist;
        private Transaction currentCart;
        private List<Transaction> transactionHistory;

        public Customer(string fn, string ln, string un, string pass, string em, string add, string pn)
        {
            this.firstName = fn;
            this.lastName = ln;
            this.username = un;
            this.password = pass;
            this.email = em;
            this.address = add;
            this.phoneNumber = pn;
        }

        public string Username
        {
            get { return username; }
        }

        public string Password
        {
            get { return password; }
        }

        public List<Book> Wishlist
        {
            get { return wishlist; }
        }

        public void EditInfo()
        {

        }

        public void showWishlist(ref WishListDialog wd)
        {
            wd.AddDisplayItems(wishlist.ToArray());
        }

        public void showCart()
        {

        }

        public void showHistory()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(firstName + " ");
            sb.Append(lastName + " ");
            sb.Append(username + " ");
            sb.Append(password + " ");
            sb.Append(email + " ");
            sb.Append(address + " ");
            sb.Append(phoneNumber + " ");
            return sb.ToString();
        }
    }
}