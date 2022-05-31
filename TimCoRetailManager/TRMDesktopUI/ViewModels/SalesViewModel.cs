using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private int _itemQuantity;
        private BindingList<string> _cart;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string SubTotal
        {
            get
            {
                // TODO Replave with calculation
                return "$0.00";
            }
        }
        public string Tax
        {
            get
            {
                // TODO Replave with calculation
                return "$0.00";
            }
        }
        public string Total
        {
            get
            {
                // TODO Replave with calculation
                return "$0.00";
            }
        }

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public bool CanAddToCart
        {
            get
            {
                // Make sure that something is selected
                // Make sure that the user has entered a quantity

                return false;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                // Make sure that something is selected

                return false;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                // Make sure that something is in the cart

                return false;
            }
        }

        public void CheckOut()
        {

        }
    }
}
