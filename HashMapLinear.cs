using System;

namespace Data_Structures
{
    class HashMapLinear
    {
        public class Node
        {
            public int key { get; set; }
            public string data { get; set; }

            public Node(int key, string data)
            {
                this.key = key;
                this.data = data;
            }
        }

        public int Size { get { return map.Length; } set { Size = value; } }

        private Node[] map;
        int count;

        public HashMapLinear(int size)
        {
            map = new Node[size];
            count = 0;
        }
        public void Put(int key, string data)
        {
            if (isFull())
            {
                Console.WriteLine("Sorry map is full!");
                return;
            }
            Node item = new Node(key, data);
            int position = computePosition(item.key);
            addItem(item, position);
        }

        public Node Get(int key)
        {
            int position = computePosition(key);
            return findElement(key, position);
        }

        public bool Remove(int key)
        {
            if (!isEmpty())
            {
                int position = computePosition(key);
                return deleteNode(key, position);
            }

            return false;
        }

        private bool deleteNode(int key, int position, int count=1)
        {
            if (count > Size)
                return false;

            if (map[position].key == key)
            {
                map[position] = null;
                return true;
            }

            return deleteNode(key, (position + 1) % Size, count++);
        }

        private Node findElement(int key, int position)
        {
            if (isItemFound(position, key))
                return map[position];

            for (int counter = 1; counter != Size; counter++, position++)
                if (isItemFound(position + 1, key))
                    return map[position];

            return null;
        }

        private bool isItemFound(int position, int key)
        {
            return map[position % Size].key == key;
        }

        private bool isFull()
        {
            return count == Size;
        }

        private bool isEmpty()
        {
            return count == 0;
        }

        private int computePosition(int key)
        {
            return key.GetHashCode() % Size;
        }

        private void addItem(Node item, int position)
        {
            if (map[position] == null)
                map[position] = item;
            else
                linearProbe(item, position);

            count++;
        }

        private void linearProbe(Node item, int position)
        {
            int index = position;
            while (map[index] != null)
                index = (index + 1) % Size;

            map[index] = item;
        }
    }
}
