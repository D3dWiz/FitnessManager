using System;
using System.Collections.Generic;
using System.Text;

namespace NEW_DESIGH.Model
{
    public class Sale
    {
        private int saleID;
        private string product;
        private int quantity;
        private double total;

        public int SaleID
        {
            get { return saleID; }
            set { saleID = value; }
        }

        public string Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
