using System;

namespace Data_Structures
{
    class ArrayQueueCircular
    {
        private int[] queue;
        private int start;
        private int end;
        private int size;

        public ArrayQueueCircular()
        {
            queue = new int[3];
            start = -1;
            end = -1;
        }

        public ArrayQueueCircular(int Size)
        {
            queue = new int[Size];
            size = Size;
            start = -1;
            end = -1;
        }

        public void Enqueue(int element)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }
            else if (IsEmpty())
                end = start = 0;
            else
                end = (end + 1) % size;

            queue[end] = element;
        }

        public void DeQueue()
        {
            if (IsEmpty())
                Console.WriteLine("Queue is empty");
            else if (start == end)
                start = end = -1;
            else
                start = (start + 1) % size;
        }

        public bool IsFull()
        {
            return end + 1 % 10 == start;
        }

        public bool IsEmpty()
        {
            return start == -1 && end == -1;
        }

        public int Peek()
        {
            if (!IsEmpty())
                return queue[start];

            return -1;
        }

    }
}
