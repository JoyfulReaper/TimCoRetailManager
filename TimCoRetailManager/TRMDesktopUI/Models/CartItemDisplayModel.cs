using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.ViewModels;

namespace TRMDesktopUI.Models
{
    public class CartItemDisplayModel : INotifyPropertyChanged
    {
        public ProductDisplayModel Product { get; set; }
        private int _quantityInCart;

        public int QuantityInCart
        {
            get { return _quantityInCart; }
            set
            {
                _quantityInCart = value;
                
                CallPropertyChanged(nameof(QuantityInCart));
                CallPropertyChanged(nameof(DisplayText));
            }
        }


        public string DisplayText { get => $"{Product.ProductName} ({QuantityInCart})"; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
