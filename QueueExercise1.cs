using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    class QueueEx1
    {
        private Queue<int> queue;
        private Stack<int> stack;
        private int count
        {
            get
            {
                return queue.Count();
            }
        }

        public QueueEx1()
        {
            queue = new Queue<int>();
            stack = new Stack<int>();
        }

        public void Enqueue(params int[] elements)
        {
            foreach (int element in elements)
                queue.Enqueue(element);
        }

        public int Dequeue()
        {
            if (count > 0)
                return queue.Dequeue();

            return -1;
        }

        public void ReverseKElements(int count)
        {
            if (count > this.count)
            {
                Console.WriteLine("Invalid K property!");
                return;
            }

            moveElementsToStack(count);
            moveElementsToQueue();
        }

        private void moveElementsToStack(int count)
        {
            for (int i = 0; i < count; i++)
                stack.Push(queue.Dequeue());
        }

        private void moveElementsToQueue()
        {
            Queue<int> tempQueue = new Queue<int>();

            /* Clear stack First */
            while (stack.Count > 0)
                tempQueue.Enqueue(stack.Pop());

            /* Empty remaining elements of orignal queue */
            while (queue.Count > 0)
                tempQueue.Enqueue(queue.Dequeue());

            queue = tempQueue;

        }
    }
}
