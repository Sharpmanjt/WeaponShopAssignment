using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BinaryTreeShop
    {
        public ShopNode root;

        public BinaryTreeShop()
        {
            root = null;
        }
        public void Insert(Weapon w, int n)
        {
            //inserts item into shop
            ShopNode newItem = new ShopNode(w);
            root = InsertHelper(root, newItem, n);
        }
        public ShopNode InsertHelper(ShopNode s, ShopNode newItem, int numStock)
        {
            //if shop is empty
            if(s == null)
            {
                s = newItem;
                s.setNumStock(s.getNumStock() + numStock);
                return s;
            }
            //if player enters an item into the shop that is already there, increases stock
            if (s.shopitem.weaponName == newItem.shopitem.weaponName)
            {
                s.setNumStock(s.getNumStock() + numStock);
                return s;
            }
            //if item goes right in tree
            if (string.Compare(newItem.shopitem.weaponName, s.shopitem.weaponName) > 0) s.right = InsertHelper(s.right, newItem, numStock);
            //if item goes left in tree
            else if (string.Compare(newItem.shopitem.weaponName, s.shopitem.weaponName) < 0) s.left = InsertHelper(s.left, newItem, numStock);
            return s;
        }
        public ShopNode Search(string w)
        {
            return SearchHelper(root, w);
        }
        public ShopNode SearchHelper(ShopNode s, string w)
        {
            //if you reached the end of the current branch, item is not there
            if (s == null) return null;
            //if item found
            if (w == s.shopitem.weaponName) return s;
            //if item to the right
            if (string.Compare(w, s.shopitem.weaponName) > 0) return SearchHelper(s.right, w);
            //if item to the left
            else if (string.Compare(w, s.shopitem.weaponName) < 0) return SearchHelper(s.left, w);
            return null;
        }
        public bool delete(string w)
        {
            ShopNode deleteItem = Search(w);
            if (deleteItem == null) return false;
            ShopNode current = root;
            ShopNode previous = root;
            while(current != deleteItem)
            {
                previous = current;
                if (string.Compare(deleteItem.shopitem.weaponName, current.shopitem.weaponName) > 0) current = current.right;
                else if (string.Compare(deleteItem.shopitem.weaponName, current.shopitem.weaponName) < 0) current = current.left; 
            }
            Console.WriteLine(previous.shopitem.weaponName);
            Console.WriteLine(current.shopitem.weaponName);
            return true;
            /*if (string.Compare(current.shopitem.weaponName, current.right.shopitem.weaponName) > 0)
            {
                
            }
            else if (string.Compare(current.shopitem.weaponName, current.left.shopitem.weaponName) < 0)
            {

            }*/

        }
        public void printShop()
        {
            Console.WriteLine("Shop Contents: ");
            printHelper(root);
            Console.WriteLine("");
        }
        public void printHelper(ShopNode s)
        {
            //prints nothing if shop is empty
            if (s == null) return;
            printHelper(s.left);
            Console.WriteLine("Name: {0}    Damage: {1}    Cost: {2}   Number in Stock: {3}", s.shopitem.weaponName, s.shopitem.damage, s.shopitem.cost, s.getNumStock());
            printHelper(s.right);
        }
    }
}
