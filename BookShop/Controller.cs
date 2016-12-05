using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Controller
    {
        private bool loggedOn;
        private List<string> isbnList = new List<string>();
        private List<string> usernames = new List<string>();
        private Customer currentCustomer;
        private List<Book> books = new List<Book>();
        private List<Customer> customers = new List<Customer>();
        private List<Transaction> completedTransactions = new List<Transaction>();
        private List<Transaction> pendingTransactions = new List<Transaction>();

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
        }

        public List<Book> Books
        {
            get { return books; }
        }

        public bool LoggedIn
        {
            get { return loggedOn;}
        }
        public Controller()
        {
            this.loggedOn = false;
        }

        public void RegisterNewCustomer(string fn, string ln, string un, string pass, string em, string add, string pn)
        {
            foreach(string u in usernames)
            {
                if (u.ToLower().CompareTo(un.ToLower()) == 0)
                {
                    throw new BookShopException("There is already a customer registered with this username.");
                }
            }
            Customer customer = new Customer(fn, ln, un, pass, em, add, pn);
            usernames.Add(un);
            customers.Add(customer);
        }

        public void Logon(string user, string pass)
        {
            foreach(Customer c in customers)
            {
                if((c.Username.ToLower().CompareTo(user.ToLower()) == 0) && (c.Password.CompareTo(pass)) == 0)
                {
                    currentCustomer = c;
                    loggedOn = true;
                    return;
                }
            }
            throw new BookShopException("Customer does not exist.");
        }

        public void Logoff()
        {
            if(!loggedOn)
            {
                throw new BookShopException("There is no one logged in.");
            }
            loggedOn = false;
            currentCustomer = null;
        }

        public void AddBook(string t, string a, string p, string i, decimal price, string d, int s)
        {
            foreach(string isbn in isbnList)
            {
                if (isbn.ToLower() == i.ToLower())
                {
                    throw new BookShopException("There is already a book registered with that ISBN.");
                }
            }
            Book book = new Book(t, a, p, i, price, d, s);
            isbnList.Add(i);
            books.Add(book);
        }

        public void ListCustomers(ref ListCustomersDialog lc)
        {
            lc.AddDisplayItems(customers.ToArray());
        }

        public void AddToWishList(string i)
        {
            if (!loggedOn)
            {
                throw new BookShopException("There is no one logged in.");
            }
            foreach(Book b in books)
            {
                if(b.ISBN == i)
                {
                    currentCustomer.addBookToWishlist(b);
                }
            }
        }

        public void DisplayWishlist(ref WishListDialog wd)
        {
            if (!loggedOn)
            {
                throw new BookShopException("This operation requires login.");
            }
            currentCustomer.showWishlist(ref wd);
        }

        public void ListBooks(ref ListBooksDialog lb)
        {
            lb.AddDisplayItems(books.ToArray());
        }

        public void ListPendingTransactions()
        {

        }

        public void ListCompletedTransactions()
        {

        }

        public void PopulateCustomerDialog(ref CustomerDialog cd)
        {
            if (!loggedOn) throw new BookShopException("This operation requires login.");
            cd.FirstName = currentCustomer.FirstName;
            cd.LastName = currentCustomer.LastName;
            cd.UserName = currentCustomer.Username;
            cd.Password = currentCustomer.Password;
            cd.EMailAddress = currentCustomer.Email;
            cd.Address = currentCustomer.Address;
            cd.TelephoneNumber = currentCustomer.PhoneNumber;
        }

        public void PopulateBookInfo(ref BookInformationDialog bid, Book b)
        {
            bid.BookTitle = b.Title;
            bid.Author = b.Author;
            bid.Publisher = b.Publisher;
            bid.ISBN = b.ISBN;
            bid.Price = b.Price;
            bid.Date = b.Date;
            bid.Stock = b.Stock;
        }

        public void EditCustomerInfo(ref CustomerDialog cd)
        {

        }
    }
}