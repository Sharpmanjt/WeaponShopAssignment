using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class PackNode
    {
        public Weapon w;
        public int stock;
        public PackNode next;

        public PackNode(Weapon w, int s)
        {
            this.w = w;
            next = null;
            stock = s;
        }
    }
}
