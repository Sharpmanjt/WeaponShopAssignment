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
        public void delete(string w)
        {
            root = deleteWorker(w, root);
        }
        public ShopNode deleteWorker(string w, ShopNode current)
        {
            if (current == null) return current;
            //if item to the right
            if (string.Compare(w, current.shopitem.weaponName) > 0) current.right= deleteWorker(w, current.right);
            //if item to the left
            else if (string.Compare(w, current.shopitem.weaponName) < 0) current.left= deleteWorker(w, current.left);

            else if(w == current.shopitem.weaponName)
            {
                if (current.left == null) return current.right;
                if (current.right == null) return current.left;

                ShopNode successor = current.right;
                while (current.left != null)
                    successor = successor.left;
                current.setNumStock(successor.getNumStock());
                current.shopitem = successor.shopitem;
                current.right = deleteWorker(current.shopitem.weaponName, current.right);
                
            }
            return current;
        }
        public void printShop()
        {
            Console.WriteLine("Shop Contents: ");
            Console.WriteLine("Name\t\tDamage\tCost\tNumber in Stock");
            printHelper(root);
            Console.WriteLine("");
        }
        public void printHelper(ShopNode s)
        {
            //prints nothing if shop is empty
            if (s == null) return;
            printHelper(s.left);
            Console.WriteLine("{0}\t\t{1}\t{2}\t{3}", s.shopitem.weaponName, s.shopitem.damage, s.shopitem.cost, s.getNumStock());
            printHelper(s.right);
        }
    }
}
