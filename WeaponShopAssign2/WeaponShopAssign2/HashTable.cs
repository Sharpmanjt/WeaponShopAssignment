using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class HashTable
    {
        int tableLength;    // records the max size of the table
        int numItems;       // records number of items in the list
        Weapon[] table; //hashtable itself

        public HashTable(int size)
        {
            tableLength = size;
            numItems = 0;
            table = new Weapon[tableLength];
            for (int i = 0; i < tableLength; i++)
            {
                table[i] = null;
            }
        }


        public int hash(string key)
        {
            int value = 0;
            for (int i = 0; i < key.Length; i++)
                value = value + key[i];
            return value % tableLength;
        }

        public void put(Weapon item)
        {
            int location = hash(item.weaponName); //gets location in table based on name
            while (table[location] != null)
            {
                location = (location + 1);      // look one down
                location = location % tableLength; // to ensure wraparound at end of array
            }
            table[location] = item;
            numItems++;
        }

        public Weapon get(string key)
        {
            int location = hash(key); //gets location in table based on key
            while (table[location] != null && key.CompareTo(table[location].weaponName) != 0)
            {  // not empty and not item
                location = (location + 1);      // look one down
                location = location % tableLength; // to ensure wraparound at end of array
            }
            return table[location];
        }

        public void printTable()
        {
            int count = 0;
            for (int x = 0; x < tableLength; x++)
            {
                if (table[x] != null)
                {
                    Console.WriteLine("Name: " +table[x].weaponName+"   Damage:"+table[x].damage+"    Cost:"+table[x].cost);
                }
            }
        }
    }
}
