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
        private List<int> _isbnList;
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
            _staffWindow = new StaffWindow(this);
            _custWindow = new CustomerWindow(this);
        }

        public void RegisterNewCustomer()
        {

        }

        public void Logon()
        {

        }

        public void Logoff()
        {

        }

        public void AddBook()
        {

        }

        public void ListCustomers()
        {

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
