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
        private List<string> _isbnList;
        private List<string> _usernames;
        private Customer _currentCustomer;
        private CustomerWindow _custWindow;
        private StaffWindow _staffWindow;
        private List<Book> _books;
        private List<Customer> _customers;
        private List<Transaction> _completedTransactions;
        private List<Transaction> _pendingTransactions;

        public Controller()
        {
            this._loggedOn = false;
        }

        public void RegisterNewCustomer(string fn, string ln, string un, string pass, string em, string add, string pn)
        {
            foreach(string u in _usernames)
            {
                if (u.ToLower() == un.ToLower())
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
                if((c.Username.ToLower() == user.ToLower()) && (c.Password == pass))
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

        public void ListCustomers()
        {
            foreach(Customer c in _customers)
            {

            }
        }

        public void ListBooks()
        {

        }

        public void ListPendingTransactions()
        {

        }

        public void ListCompletedTransactions()
        {

        }
    }
}
