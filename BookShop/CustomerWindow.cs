﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edu.ksu.cis.masaaki
{
    public partial class CustomerWindow : Form
    {
        // XXX add more fields if necessary
        private Controller _controller;

        CustomerDialog customerDialog;
        LoginDialog loginDialog;
        ListBooksDialog listBooksDialog;
        BookInformationDialog bookInformationDialog;
        CartDialog cartDialog;
        WishListDialog wishListDialog;
        BookInWishListDialog bookInWishListDialog;
        ListTransactionHistoryDialog listTransactionHistoryDialog;
        ShowTransactionDialog showTransactionDialog;

        public CustomerWindow()
        {
            InitializeComponent();
        }

        public CustomerWindow(Controller c) : this()
        {
           this. _controller = c;
        }

        // XXX You may add overriding constructors (constructors with different set of arguments).
        // If you do so, make sure to call :this()
        // public CustomerWindow(XXX xxx): this() { }
        // Without :this(), InitializeComponent() is not called
        private void CustomerWindow_Load(object sender, EventArgs e)
        {
            customerDialog = new CustomerDialog();
            loginDialog = new LoginDialog();
            listBooksDialog = new ListBooksDialog();
            bookInformationDialog = new BookInformationDialog();
            cartDialog = new CartDialog();
            wishListDialog = new WishListDialog();
            bookInWishListDialog = new BookInWishListDialog();
            listTransactionHistoryDialog = new ListTransactionHistoryDialog();
            showTransactionDialog = new ShowTransactionDialog();
        }

        private void bnLogin_Click(object sender, EventArgs e)
        {
            // XXX Login Button event handler
            // First, you may want to check if anyone is logged in
            if (loginDialog.Display() == DialogReturn.Cancel) return;
            // XXX Login Button is pressed

        }

        private void bnAddCustomer_Click(object sender, EventArgs e)
        {
            // XXX Register Button event handler
            customerDialog.ClearDisplayItems();
            if (customerDialog.Display() == DialogReturn.Cancel) return;
            // XXX pick up information from customerDialog by calling its properties
            // and register a new customer
        }

        private void bnEditSelfInfo_Click(object sender, EventArgs e)
        {
            // XXX Edit Self Info button event handler

            if (customerDialog.Display() == DialogReturn.Cancel) return;
            // XXX Done button is pressed
        }

        private void bnBook_Click(object sender, EventArgs e)
        {
            // XXX List Books buton is pressed
            
            while (true)
            { 
                try
                {  // to capture an exception from SelectedItem/SelectedIndex of listBooksDialog
                    listBooksDialog.ClearDisplayItems();
                    listBooksDialog.AddDisplayItems(null); // XXX null is a dummy argument
                    if (listBooksDialog.Display() == DialogReturn.Done) return;
                    // select is pressed

                    switch (bookInformationDialog.Display())
                    {
                        case DialogReturn.AddToCart: // Add to Cart
                           // XXX
                            continue;

                        case DialogReturn.AddToWishList: // Add to Wishlist
                            // XXX

                            continue;

                        case DialogReturn.Done: // cancel
                            continue;
                        default: return;
                    }
                }
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnShowWishlist_Click(object sender, EventArgs e)
        {
            // XXX Show WishList Button event handler
          
            while (true)
            {
                try
                { // to capture an excepton by SelectedItem/SelectedIndex of wishListDialog
                    wishListDialog.ClearDisplayItems();
                    wishListDialog.AddDisplayItems(null);  // XXX null is a dummy argument
                    if (wishListDialog.Display() == DialogReturn.Done) return;
                    // select is pressed
                    //XXX 
                    switch (bookInWishListDialog.Display())
                    {
                        case DialogReturn.AddToCart:
                            // XXX 

                            continue;
                        case DialogReturn.Remove:
                            // XXX

                            continue;
                        case DialogReturn.Done: // Done
                            continue;
                    }
                }
                catch(BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnShowCart_Click(object sender, EventArgs e)
        {
           // XXX Show Cart Button event handler
            while (true)
            {
                try
                {  // to capture an exception from SelectedIndex/SelectedItem of carDisplay
                    cartDialog.ClearDisplayItems();
                    cartDialog.AddDisplayItems(null); // null is a dummy argument
                    switch (cartDialog.Display())
                    {
                        case DialogReturn.CheckOut:  // check out
                            // XXX

                            return;
                        case DialogReturn.ReturnBook: // remove a book
                               // XXX

                                continue;
                        
                        case DialogReturn.Done: // cancel
                            return;
                    }
                }
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnTransactionHistory_Click(object sender, EventArgs e)
        {
            // XXX Transaction History button handler
            while (true)
            {
                
                try
                {  // to capture an exception from SelectedIndex/SelectedItem of listTransactionHistoryDialog
                    listTransactionHistoryDialog.ClearDisplayItems();
                    listTransactionHistoryDialog.AddDisplayItems(null); // null is a dummy argument
                    if (listTransactionHistoryDialog.Display() == DialogReturn.Done) return;
                    // Select is pressed
                    

                    showTransactionDialog.ClearDisplayItems();
                    showTransactionDialog.AddDisplayItems(null); // null is a dummy argument
                    showTransactionDialog.ShowDialog();
                }
                catch(BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                }
            }
        }

        private void bnLogout_Click(object sender, EventArgs e)
        {
            // XXX Logout  button event handler
         
        }
    }
}
