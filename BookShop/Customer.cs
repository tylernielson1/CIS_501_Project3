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
            this.currentCart = new Transaction(this);
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

        public Transaction CurrentCart
        {
            get { return currentCart; }
        }
        
        public List<Transaction> History
        {
            get { return transactionHistory; }
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
            foreach(PurchasedItem pi in currentCart.Cart)
            {
                if(pi.Book.ISBN == b.ISBN)
                {
                    pi.Quantity++;
                    currentCart.Price += b.Price;
                    b.Stock--;
                    return;
                }
            }
            PurchasedItem p = new PurchasedItem(b, 1);
            currentCart.Cart.Add(p);
            currentCart.Price += p.Book.Price;
            b.Stock--;
        }

        public void RemoveFromCart(Book b)
        {
            foreach(PurchasedItem pi in currentCart.Cart)
            {
                if(pi.Book.ISBN == b.ISBN)
                {
                    pi.Quantity--;
                    currentCart.Price -= b.Price;
                    b.Stock++;
                    if(pi.Quantity <= 0)
                    {
                        currentCart.Cart.Remove(pi);
                    }
                }
            }
        }

        public void showCart(ref CartDialog cd)
        {
            cd.AddDisplayItems(currentCart.Cart.ToArray());
        }

        public void showHistory(ref ListTransactionHistoryDialog th)
        {
            th.AddDisplayItems(transactionHistory.ToArray());
        }

        public void CheckCustOut()
        {
            transactionHistory.Add(currentCart);
            currentCart = new Transaction(this);
        }

        public void RemoveTransaction(Transaction t)
        {
            foreach(Transaction trans in transactionHistory)
            {
                if(trans == t)
                {
                    transactionHistory.Remove(t);
                    break;
                }
            }
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