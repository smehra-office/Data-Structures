using System;
using System.Collections.Generic;
using System.Linq;

namespace HashStructures
{
    public class HashTable
    {
        public class Item
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public Item(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private LinkedList<Item>[] hashTable = new LinkedList<Item>[10];

        public HashTable()
        {
            for (int index = 0; index < 10; index++)
                hashTable[index] = new LinkedList<Item>();
        }

        public void Put(int key, string value)
        {
            int position = getPosition(key);
            Item node = getNode(key, position);
            
            /* Item exists */
            if (node != null)
            {
                node.Value = value;
                return;
            }

            hashTable[position].AddLast(new Item(key, value));
        }
       
        public String Get(int key)
        {
            int position = getPosition(key);
            String result = hashTable[position].FirstOrDefault(item => item.Key.Equals(key))?.Value;

            return result;
        }

        public bool Remove(int key)
        {
            int position = getPosition(key);
            Item node = hashTable[position].FirstOrDefault(item => item.Key.Equals(key));
            bool result = hashTable[position].Remove(node);
            return result;
        }

        private int getPosition(int key)
        {
            return key.GetHashCode() % 10;
        }

        private Item getNode(int key, int index)
        {
            foreach (Item item in hashTable[index])
                if (item.Key.Equals(key))
                    return item;

            return null;
        }






    }
}
