using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private string _email;
        private string _address;
        private string _phoneNumber;
        private List<Book> _wishlist;
        private Transaction _currentCart;
        private List<Transaction> _transactionHistory;

        public Customer(string fn, string ln, string un, string pass, string em, string add, string pn)
        {
            this._firstName = fn;
            this._lastName = ln;
            this._username = un;
            this._password = pass;
            this._email = em;
            this._address = add;
            this._phoneNumber = pn;
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }

        public void EditInfo()
        {

        }

        public void showWishlist()
        {

        }

        public void showCart()
        {

        }

        public void showHistory()
        {

        }
    }
}
