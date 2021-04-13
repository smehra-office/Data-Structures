using System;
using System.Text;

namespace Data_Structures
{
    class PriorityQueue
    {
        private int end = -1;
        private int[] queue;

        private int size
        {
            get { return queue.Length; }
            set { size = value; }
        }

        public PriorityQueue(int size)
        {
            queue = new int[size];
        }

        public void Enqueue(int element)
        {
            if (IsFull())
                growQueue();
            else if (IsEmpty())
            {
                queue[++end] = element;
                return;
            }

            insert(element);
            end++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return -1;
            }
            return queue[end--];
        }

        public void Print()
        {
            StringBuilder str = new StringBuilder("[ ");
            if (!IsEmpty())
                for (int index = end; index >= 0; index--)
                    str.Append($"{queue[index]} ");

            str.Append(']');
            Console.WriteLine(str.ToString());
        }

        private void insert(int element)
        {
            int index = indexToInsert(element);
            for (int i = end; i >= index; i--)
                queue[i + 1] = queue[i];

            queue[index] = element;
        }

        private int indexToInsert(int element)
        {
            int index = binarySearchForIndex(0, end, element);
            if (queue[index] > element && index != 0)
                index--;
            else if (queue[index] < element && index != size)
                index++;

            return index;
        }

        /* Return index of closest matching element */
        private int binarySearchForIndex(double start, double end, int element)
        {
            if (start == end)
                return (int)end;

            int mid = (int)Math.Floor((start + end) / 2);
            if (element == queue[mid])
                return mid;
            else if (element < queue[mid])
                return binarySearchForIndex(start, mid - 1, element);
            else
                return binarySearchForIndex(mid + 1, end, element);
        }

        private void growQueue()
        {
            int[] newQueue = new int[size * 2];
            for (int i = 0; i < size; i++)
                newQueue[i] = queue[i];

            queue = newQueue;
        }

        public bool IsFull()
        {
            return end == size - 1;
        }

        public bool IsEmpty()
        {
            return end == -1;
        }
    }
}
