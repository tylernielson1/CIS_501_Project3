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
        private List<Book> wishlist = new List<Book>();
        private Transaction currentCart;
        private List<Transaction> transactionHistory = new List<Transaction>();

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
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public List<Book> Wishlist
        {
            get { return wishlist; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public void showWishlist(ref WishListDialog wd)
        {
            wd.AddDisplayItems(wishlist.ToArray());
        }

        public void addBookToWishlist(Book b)
        {
            wishlist.Add(b);
        }
        public void removeBookFromWishlist(Book b)
        {
            wishlist.Remove(b);
        }

        public void AddToCart(Book b)
        {
            if (b.Stock <= 0) throw new BookShopException("This book is out of stock.");
            foreach(PurchasedItem p in currentCart.Cart)
            {
                if(p.Book.ISBN == b.ISBN)
                {
                    p.Quantity++;
                    return;
                }
            }
            PurchasedItem p = new PurchasedItem(b, 1);
            currentCart.Cart.Add(p);
        }

        public void showCart(ref CartDialog cd)
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
            sb.Append(email + " ");
            sb.Append(address + " ");
            sb.Append(phoneNumber);
            return sb.ToString();
        }
    }
}