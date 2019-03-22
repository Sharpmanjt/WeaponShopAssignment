using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{   // This class implements a backpack as a linked list
    // The backpack can hold any number of weapons as long as maxWeight is not crossed.
    // If an attempt to add a weapon to backpack is rejected due to weight
    class Backpack
    {
        public double maxWeight { get; set; }
        public  double presentWeight { get; set; }
        public PackNode head;

        public Backpack(double mweight)
        {
            head = null;
            presentWeight = 0;
            maxWeight = mweight;
        }
        public bool addItem(Weapon w, int numstock)
        {
            PackNode newNode = new PackNode(w, numstock);
            //if no items in backpack
            if (head == null)
            {
                head = newNode;
                presentWeight += w.weight * numstock;
                return true;
            }
            PackNode current = head;
            //if you already have some of that item in your bag and are buying additional copies
            if (current.w == w)
            {
                current.stock += numstock;
                presentWeight += (w.weight * numstock);
                return true;
            }
            //loops until you find the item or get to the end
            while (current.next != null)
            {
                //once you find another copy of the purchased item, increases stock and weight
                if (current.w == w)
                {
                    current.stock += numstock;
                    presentWeight += (w.weight * numstock);
                    return true;
                }
                current = current.next;
            }
            //if item purchased is the last item in the bag
            if (current.w == w)
            {
                current.stock += numstock;
                presentWeight += (w.weight * numstock);
                return true;
            }
            //if item is not in the bag
            current.next = newNode;
            presentWeight += (w.weight * numstock);
            return true;
        }
        public void buy(Weapon w, int numstock)
        {
            /*
             * 
             * Not used, just kept in case something breaks
            if(presentWeight + (w.weight*numstock) > maxWeight)
            {
                Console.WriteLine("Buying this item would exceed max weight.");
                return false;
            }
            PackNode newNode = new PackNode(w, numstock);
            if(head == null)
            {
                head = newNode;
                presentWeight += w.weight * numstock;
                Console.WriteLine("Item purchased!");
                return true;
            }
            PackNode current = head;
            if (current.w == w)
            {
                current.stock += numstock;
                presentWeight += (w.weight*numstock);
                Console.WriteLine("Item purchased!");
                return true;
            }
            while (current.next != null)
            {
                if(current.w == w)
                {
                    current.stock += numstock;
                    presentWeight += (w.weight * numstock);
                    Console.WriteLine("Item purchased!");
                    return true;
                }
                current = current.next;
            }
            if (current.w == w)
            {
                current.stock += numstock;
                presentWeight += (w.weight * numstock);
                Console.WriteLine("Item purchased!");
                return true;
            }
            current.next = newNode;
            presentWeight += (w.weight * numstock);
            Console.WriteLine("Item purchased!");
            return true;*/
        }
        public void printBackpack()
        {
            PackNode current = head;
            Console.WriteLine("Backpack contents:");
            Console.WriteLine("Weight: {0}, Max Weight: {1}", presentWeight, maxWeight);
            //prints nothing if empty
            while (current != null)
            {
                Console.WriteLine("Name: {0}    Damage: {1}   Number in Bag: {2}", current.w.weaponName, current.w.damage, current.stock);
                current = current.next;
            }
            Console.WriteLine("");
        }
    }
}
