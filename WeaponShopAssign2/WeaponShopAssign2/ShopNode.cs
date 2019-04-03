using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class ShopNode
    {
        public Weapon shopitem;
        private int numStock;
        public ShopNode right;
        public ShopNode left;

        public ShopNode(Weapon s)
        {
            shopitem = s;
            numStock = 0;
            right = null;
            left = null;
        }

        public void setNumStock(int n)
        {
            numStock = n;
        }

        public int getNumStock()
        {
            return numStock;
        }
    }
}
