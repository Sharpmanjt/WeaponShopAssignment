using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Player
    {
        public string name;
        public Backpack bp;
        public double money;

        public Player(string n, double m, double mw)
        {
            name = n;
            money = m;
            bp = new Backpack(mw);
        }

        public bool buy(Weapon w, int numpurchased)
        {
            //checks if player has enough money
            if (!withdraw((w.cost) * numpurchased))
            {
                Console.WriteLine("You do not have enough money to purchase this item!");
                return false;
            }
            //checks if player has enough room in backpack
            if (!inventoryFull(w, numpurchased)) return false;
            //all other results return true
            Console.WriteLine("Item purchased!");
            return bp.addItem(w, numpurchased);
        }

        public bool withdraw(double amt)
        {
            //subtracts money from player if possible
            if (amt > money) return false;
            money = money - amt;
            return true;
        }

        public bool inventoryFull(Weapon w, int numpurchased)
        {
            if(bp.presentWeight+(w.weight * numpurchased) > bp.maxWeight)
            {
                Console.WriteLine("Buying this item would exceed max weight.");
                return false;
            }
            return true; 
        }

        public void printCharacter()
        {
            //prints player and backpack attributed
            Console.WriteLine("Name:"+name+"\nMoney:"+money);
            bp.printBackpack();
        }

        public void printBackpack()
        {
            bp.printBackpack();
        }
    }
}
