using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Controller
    {
        private bool _loggedOn;
        private List<string> _isbnList = new List<string>();
        private List<string> _usernames = new List<string>();
        private Customer _currentCustomer;
        private CustomerWindow _custWindow;
        private StaffWindow _staffWindow;
        private List<Book> _books = new List<Book>();
        private List<Customer> _customers = new List<Customer>();
        private List<Transaction> _completedTransactions = new List<Transaction>();
        private List<Transaction> _pendingTransactions = new List<Transaction>();

        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }

            set { this._currentCustomer = value; }
        }

        public List<Book> Books
        {
            get { return _books; }
        }

        public Controller()
        {
            this._loggedOn = false;
        }

        public void RegisterNewCustomer(string fn, string ln, string un, string pass, string em, string add, string pn)
        {
            foreach(string u in _usernames)
            {
                if (u.ToLower().CompareTo(un.ToLower()) == 0)
                {
                    return;
                }
            }
            Customer customer = new Customer(fn, ln, un, pass, em, add, pn);
            _usernames.Add(un);
            _customers.Add(customer);
        }

        public void Logon(string user, string pass)
        {
            if (_loggedOn) return;
            foreach(Customer c in _customers)
            {
                if((c.Username.ToLower().CompareTo(user.ToLower()) == 0) && (c.Password.CompareTo(pass)) == 0)
                {
                    _currentCustomer = c;
                    _loggedOn = true;
                    return;
                }
            }
        }

        public void Logoff()
        {
            _loggedOn = false;
            _currentCustomer = null;
        }

        public void AddBook(string t, string a, string p, string i, decimal price, string d, int s)
        {
            foreach(string isbn in _isbnList)
            {
                if (isbn.ToLower() == i.ToLower())
                {
                    return;
                }
            }
            Book book = new Book(t, a, p, i, price, d, s);
            _isbnList.Add(i);
            _books.Add(book);
        }

        public void ListCustomers(ListCustomersDialog lc)
        {
            lc.AddDisplayItems(_customers.ToArray());
        }

        public void AddToWishList(string i)
        {

        }

        public void ListBooks(ListBooksDialog lb)
        {
            lb.AddDisplayItems(_books.ToArray());
        }

        public void ListPendingTransactions()
        {

        }

        public void ListCompletedTransactions()
        {

        }
    }
}
