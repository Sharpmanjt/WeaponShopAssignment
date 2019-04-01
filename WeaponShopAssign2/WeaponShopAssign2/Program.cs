using System;

namespace WeaponShopAssign2
{
    class Program
    {
        /*
        public static void addWeapons(HashTable h)
        {
            Console.WriteLine("***********WELCOME TO THE WEAPON ADDING MENU*********");
            string weaponName; int weaponRange; int weaponDamage; double weaponWeight; double weaponCost;
            Console.WriteLine("Please enter the NAME of the Weapon ('end' to quit):");
            weaponName=Console.ReadLine();
            while (weaponName.CompareTo("end") != 0)
            {
                Console.WriteLine("Please enter the Range of the Weapon (0-10):");
                weaponRange= Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Please enter the Damage of the Weapon:");
                weaponDamage=Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Please enter the Weight of the Weapon (in pounds):");
                weaponWeight= Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter the Cost of the Weapon:");
                weaponCost=Convert.ToDouble(Console.ReadLine());
                Weapon w = new Weapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost);
                h.put(w);
                Console.WriteLine("Please enter the NAME of another Weapon ('end' to quit):");
                weaponName = Console.ReadLine();
            }
        }

        public static void showRoom(HashTable ht, Player p)
        {
            string choice;
            Console.WriteLine("WELCOME TO THE SHOWROOM!!!!");
            ht.printTable();
            Console.WriteLine(" You have "+p.money+" money.");
            Console.WriteLine("Please select a weapon to buy('end' to quit):");
            choice=Console.ReadLine();
            while (choice.CompareTo("end") != 0 && !p.inventoryFull())
            {
                Weapon w = ht.get(choice);
                if (w != null)
                {
                    if (w.cost > p.money)
                    {
                        Console.WriteLine("Insufficient funds to buy "+w.weaponName );
                    }
                    else
                    {
                        //p.bp.buy(w);
                        p.withdraw(w.cost);
                    }
                }
                else
                {
                    Console.WriteLine(" ** "+choice+" not found!! **" );
                }
                Console.WriteLine("Please select another weapon to buy('end' to quit):");
                choice = Console.ReadLine();
            }
            Console.WriteLine();
        }
        */

        static int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the game menu!");
            Console.WriteLine("1. Add items to the shop");
            Console.WriteLine("2. Delete items from the shop");
            Console.WriteLine("3. Buy from the shop");
            Console.WriteLine("4. View backpack");
            Console.WriteLine("5. View Player");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Please enter a choice:");
            int choice;
            string input = Console.ReadLine();
            //loops until valid choice entered
            while(!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid choice:");
                input = Console.ReadLine();
            }
            return choice;
        }
        static void addItem(BinaryTreeShop b)
        {
            Console.Clear();
            Console.WriteLine("-----Add Item to Shop-----");
            string name, input;
            int weaponrange, weapondamage, numstock;
            double weight, cost;
            b.printShop();
            Console.WriteLine("Enter the name of an item to add to the shop (enter 'end' to exit):");
            Console.WriteLine("(Iff you enter the name of an existing weapon, it will increase the number in stock.)");
            name = Console.ReadLine();
            //all items to be stored in lowercase
            name = name.ToLower();
            while (name != "end")
            {
                Console.WriteLine("Enter the number of the item that will be added to the stock:");
                input = Console.ReadLine();
                //check for correct input
                while(!int.TryParse(input, out numstock) || numstock < 1)
                {
                    Console.WriteLine("Please enter a valid number for the stock:");
                    input = Console.ReadLine();
                }
                //if the item name is already in the shop
                if(b.Search(name) != null)
                {
                    Weapon w = new Weapon(name, 1, 1, 1, 1);
                    b.Insert(w, numstock);
                    Console.Clear();
                    Console.WriteLine("Item added to shop!");
                    b.printShop();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Enter the range of the weapon:");
                input = Console.ReadLine();
                //check for correct input
                while(!int.TryParse(input, out weaponrange) || weaponrange < 1)
                {
                    Console.WriteLine("Please enter a valid weapon range:");
                    input = Console.ReadLine();
                }
                Console.WriteLine("Enter the weight of the weapon in kilograms:");
                input = Console.ReadLine();
                //check for correct input
                while(!double.TryParse(input, out weight) || weight < 1)
                {
                    Console.WriteLine("Please enter a valid weapon weight in kilograms:");
                    input = Console.ReadLine();
                }
                Console.WriteLine("Enter the cost of the weapon:");
                input = Console.ReadLine();
                //check for correct input
                while (!double.TryParse(input, out cost) || cost < 1)
                {
                    Console.WriteLine("Please enter a valid weapon cost:");
                    input = Console.ReadLine();
                }
                Console.WriteLine("Enter the damage of the weapon:");
                input = Console.ReadLine();
                //check for correct input
                while(!int.TryParse(input, out weapondamage) || weapondamage < 1)
                {
                    Console.WriteLine("Please enter a valid weapon damage:");
                    input = Console.ReadLine();
                }
                Weapon newWeapon = new Weapon(name, weaponrange, weapondamage, weight, cost);
                //adds item to shop
                b.Insert(newWeapon, numstock);
                Console.Clear();
                Console.WriteLine("Weapon added to the shop!");
                b.printShop();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }
        static void deleteItem(BinaryTreeShop bt)
        {
            Console.Clear();
            string input = "";
            while (input != "end")
            {
                Console.Clear();
                Console.WriteLine("-----Delete Item from Shop-----");
                bt.printShop();
                Console.WriteLine("Please enter the name of a weapon to delete (enter 'end' to quit):");
                input = Console.ReadLine();
                //all items stored in lowercase so searches done in lowercase
                input = input.ToLower();
                if (input == "end") break;
                if (bt.Search(input) == null)
                {
                    Console.WriteLine("This item is not in the shop. Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    bt.delete(input);
                    Console.WriteLine("Item deleted from shop! Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void buyItem(Player p, BinaryTreeShop bt)
        {
            Console.Clear();
            string input = "";
            while(input != "end")
            {
                Console.Clear();
                Console.WriteLine("-----Buy Item from Shop-----");
                bt.printShop();
                p.printBackpack();
                Console.WriteLine("Please enter the name of a weapon to buy (enter 'end' to quit):");
                input = Console.ReadLine();
                //all items stored in lowercase so searches done in lowercase
                input = input.ToLower();
                if (input == "end") break;
                if(bt.Search(input) == null)
                {
                    Console.WriteLine("This item is not in the shop. Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    ShopNode purchasedItem = bt.Search(input);
                    int numpurchased;
                    Console.WriteLine("Please enter the number of " + input + " you wish to purchase:");
                    input = Console.ReadLine();
                    //check for correct input
                    while(!int.TryParse(input, out numpurchased) || numpurchased < 1)
                    {
                        Console.WriteLine("Please enter a valid number for number of items:");
                        input = Console.ReadLine();
                    }
                    if (purchasedItem.getNumStock() < numpurchased)
                    {
                        Console.WriteLine("There isn't that many of this item in the shop...");
                    }
                    else
                    {
                        if (p.buy(purchasedItem.shopitem, numpurchased))
                        {
                            purchasedItem.setNumStock(purchasedItem.getNumStock() - numpurchased);
                            if (purchasedItem.getNumStock() == 0) bt.delete(purchasedItem.shopitem.weaponName);
                        }
                        /*
                         * removed code, keeping if something breaks
                         * if (!p.withdraw((purchasedItem.shopitem.cost) * numpurchased))
                        {
                            Console.WriteLine("You do not have enough money to purchase this item.");
                        }
                        else
                        {
                            p.buy(purchasedItem.shopitem, numpurchased);
                            purchasedItem.setNumStock(purchasedItem.getNumStock()-numpurchased);
                        }*/
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }
        static void viewBackpack(Player p)
        {
            Console.Clear();
            Console.WriteLine("-----View Backpack-----");
            p.printBackpack();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void viewPlayer(Player p)
        {
            Console.Clear();
            Console.WriteLine("-----View Player-----");
            p.printCharacter();
            p.printBackpack();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            //start
            string name;
            Console.WriteLine("Please enter player name:");
            name = Console.ReadLine();
            BinaryTreeShop bts = new BinaryTreeShop();
            Player p = new Player(name, 500.50, 1000);
            int choice = 0;
            //menu handling
            while(choice != 6)
            {
                choice = MainMenu();
                switch (choice)
                {
                    case 1:
                        addItem(bts);
                        break;
                    case 2:
                        deleteItem(bts);
                        break;
                    case 3:
                        buyItem(p, bts);
                        break;
                    case 4:
                        viewBackpack(p);
                        break;
                    case 5:
                        viewPlayer(p);
                        break;
                }
            }
            Console.WriteLine("Thank you for playing - good-bye!");
            Console.ReadKey();

            //-----------END--------------
            /*
             * testing
             * BinaryTreeShop Bt = new BinaryTreeShop();
            Weapon w1 = new Weapon("Short Sword", 1, 10, 10, 50.0);
            Weapon w2 = new Weapon("Long Sword", 1, 15, 10, 75.0);
            Weapon w3 = new Weapon("Bow", 20, 8, 10, 40.0);
            Weapon w4 = new Weapon("Zylo", 1, 3, 4, 15.0);
            Bt.Insert(w1, 1);
            Bt.Insert(w2, 3);
            Bt.Insert(w3, 4);
            Bt.Insert(w4, 2);
            Bt.Insert(w1, 5);
            Bt.printShop();
            //B.delete("Zylo");
            
            b.addItem(w1, 1);
            b.addItem(w2, 3);
            b.addItem(w3, 4);
            b.addItem(w4, 2);
            b.addItem(w1, 5);
            b.addItem(w4, 19);
            b.printBackpack();*/
        }
    }
}
