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
        private CustomerWindow custWindow;
        private StaffWindow staffWindow;
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
            if (loggedOn) throw new BookShopException("There is already a customer logged in.");
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

        public void ListCustomers(ListCustomersDialog lc)
        {
            lc.AddDisplayItems(customers.ToArray());
        }

        public void AddToWishList(string i)
        {

        }

        public void ListBooks(ListBooksDialog lb)
        {
            lb.AddDisplayItems(books.ToArray());
        }

        public void ListPendingTransactions()
        {

        }

        public void ListCompletedTransactions()
        {

        }
    }
}
