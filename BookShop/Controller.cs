using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        public List<Customer> Customers
        {
            get { return customers; }
        }

        public bool LoggedIn
        {
            get { return loggedOn; }
        }

        public List<Transaction> PendingTransactions
        {
            get { return pendingTransactions; }
        }

        public List<Transaction> CompletedTransactions
        {
            get { return completedTransactions; }
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

        public void ListCart(ref CartDialog cd)
        {
            if (!loggedOn)
            {
                throw new BookShopException("This operation requires login.");
            }
            currentCustomer.showCart(ref cd);
            cd.AddDisplayItems("====================================================", "Total Price: $" + CurrentCustomer.CurrentCart.Price);
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

        public void RemoveFromWishlist(string i)
        {
            foreach(Book b in books)
            {
                if(b.ISBN == i)
                {
                    currentCustomer.removeBookFromWishlist(b);
                }
            }
        }

        public void AddToCart(string i)
        {
            foreach(Book b in books)
            {
                if(b.ISBN == i)
                {
                    currentCustomer.AddToCart(b);
                }
            }
        }

        public void RemoveFromCart(string i)
        {
            foreach(Book b in books)
            {
                if(b.ISBN == i)
                {
                    currentCustomer.RemoveFromCart(b);
                }
            }
        }

        public void RemoveFromPending(Customer c, PurchasedItem pi, Transaction t)
        {
            foreach(Customer cust in customers)
            {
                if(cust == c)
                {
                    c.RemoveBookFromHistory(t, pi);
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

        public void ListPendingTransactions(ref ListPendingTransactionsDialog pt)
        {
            foreach(Transaction t  in pendingTransactions)
            {
                pt.AddDisplayItems(t.Customer.Username + " : " + t);
            }
        }

        public void ListCompletedTransactions(ref ListCompleteTransactionsDialog ct)
        {
            foreach(Transaction t in completedTransactions)
            {
                ct.AddDisplayItems(t.Customer.Username + " : " + t);
            }
        }

        public void PopulatePendingTransaction(ref ShowPendingTransactionDialog spt, Transaction t)
        {
            spt.AddDisplayItems(t.Cart.ToArray());
            spt.AddDisplayItems("====================================================");
            spt.AddDisplayItems("Total Price: $" + t.Price);
        }

        public void PopulateCompletedTransaction(ref ShowCompleteTransactionDialog scp, Transaction t)
        {
            scp.AddDisplayItems(t.Cart.ToArray());
            scp.AddDisplayItems("====================================================");
            scp.AddDisplayItems("Total Price: $" + t.Price);
        }

        public void ApproveTransaction(Transaction t)
        {
            foreach(Transaction trans in pendingTransactions)
            {
                if(trans == t)
                {
                    completedTransactions.Add(t);
                    pendingTransactions.Remove(t);
                    break;
                }
            }
        }

        public void RemovePendingTransaction(Transaction t)
        {
            foreach(Transaction trans in pendingTransactions)
            {
                if(trans == t)
                {
                    foreach(Customer c in customers)
                    {
                        if(c == t.Customer)
                        {
                            c.RemoveTransaction(t);
                        }
                    }
                    pendingTransactions.Remove(t);
                    break;
                }
            }
        }

        public void RemoveCompletedTransaction(Transaction t)
        {
            foreach(Transaction trans in completedTransactions)
            {
                if(trans == t)
                {
                    foreach (Customer c in customers)
                    {
                        if (c == t.Customer)
                        {
                            c.RemoveTransaction(t);
                        }
                    }
                    completedTransactions.Remove(t);
                    break;
                }
            }
        }

        public void ShowCustomerHistory(ref ListTransactionHistoryDialog th)
        {
            if (!loggedOn) throw new BookShopException("This operation requires login.");
            currentCustomer.showHistory(ref th);
        }

        public void CheckOut()
        {
            pendingTransactions.Add(currentCustomer.CurrentCart);
            currentCustomer.CheckCustOut();
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

        public void PopulateCustomerDialog(ref CustomerDialog cd, Customer cust)
        {
            cd.FirstName = cust.FirstName;
            cd.LastName = cust.LastName;
            cd.UserName = cust.Username;
            cd.Password = cust.Password;
            cd.EMailAddress = cust.Email;
            cd.Address = cust.Address;
            cd.TelephoneNumber = cust.PhoneNumber;
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

        public void PopulateBookInfo(ref BookInWishListDialog bid, Book b)
        {
            bid.BookTitle = b.Title;
            bid.Author = b.Author;
            bid.Publisher = b.Publisher;
            bid.ISBN = b.ISBN;
            bid.Price = b.Price;
            bid.Date = b.Date;
            bid.Stock = b.Stock;
        }

        public void PopulateBookInfo(ref BookDialog bd, Book b)
        {
            bd.BookTitle = b.Title;
            bd.Author = b.Author;
            bd.Publisher = b.Publisher;
            bd.ISBN = b.ISBN;
            bd.Price = b.Price;
            bd.Date = b.Date;
            bd.Stock = b.Stock;
        }

        public void EditCustomerInfo(ref CustomerDialog cd)
        {
            usernames.Remove(currentCustomer.Username);
            currentCustomer.FirstName = cd.FirstName;
            currentCustomer.LastName = cd.LastName;
            currentCustomer.Username = cd.UserName;
            currentCustomer.Password = cd.Password;
            currentCustomer.Email = cd.EMailAddress;
            currentCustomer.Address = cd.Address;
            currentCustomer.PhoneNumber = cd.TelephoneNumber;
            usernames.Add(currentCustomer.Username);
        }

        public void EditCustomerInfo(ref CustomerDialog cd, Customer c)
        {
            usernames.Remove(c.Username);
            c.FirstName = cd.FirstName;
            c.LastName = cd.LastName;
            c.Username = cd.UserName;
            c.Password = cd.Password;
            c.Email = cd.EMailAddress;
            c.Address = cd.Address;
            c.PhoneNumber = cd.TelephoneNumber;
            usernames.Add(c.Username);
        }

        public void EditBookInfo(ref BookDialog bd, Book b)
        {
            isbnList.Remove(b.ISBN);
            b.Title = bd.BookTitle;
            b.Author = bd.Author;
            b.Publisher = bd.Publisher;
            b.ISBN = bd.ISBN;
            b.Price = bd.Price;
            b.Date = bd.Date;
            b.Stock = bd.Stock;
            isbnList.Add(b.ISBN);
        }

        public void Serialize(string fn)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream f = new FileStream(fn, FileMode.Create, FileAccess.Write))
            {
                Tuple<List<Book>, List<Customer>, List<Transaction>, List<Transaction>> toSerialize
                    = new Tuple<List<Book>, List<Customer>, List<Transaction>, List<Transaction>>(books, customers, pendingTransactions, completedTransactions);

                bf.Serialize(f, toSerialize);
            }

            /*For testing purposes.
            books = new List<Book>();
            customers = new List<Customer>();
            pendingTransactions = new List<Transaction>();
            completedTransactions = new List<Transaction>();
            */


        }

        public void Deserialize(string fn)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream f = new FileStream(fn, FileMode.OpenOrCreate, FileAccess.Read))
            {
                Tuple<List<Book>, List<Customer>, List<Transaction>, List<Transaction>> toDeserialize
                    = (Tuple<List<Book>, List<Customer>, List<Transaction>, List<Transaction>>)bf.Deserialize(f);

                /*For testing purposes.
                books = toDeserialize.Item1;
                customers = toDeserialize.Item2;
                pendingTransactions = toDeserialize.Item3;
                completedTransactions = toDeserialize.Item4;
                */
            }

        }
    }
}