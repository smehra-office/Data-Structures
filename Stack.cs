using System;

namespace Data_Structures
{
    class Stack
    {
        private int[] stack;
        private int pointer = -1;
        private int length = 2;
        public Stack()
        {
            stack = new int[length];
        }

        public bool IsEmpty()
        {
            return pointer == -1;
        }

        private bool isFull()
        {
            return pointer == length - 1;
        }

        public void Push(int element)
        {
            if (isFull())
                increaseSize();

            stack[++pointer] = element;
        }

        public void Pop()
        {
            if (IsEmpty())
                Console.WriteLine("Stack is empty");
            else
                pointer--;
        }

        public int Peek()
        {
            if (IsEmpty())
                return -1;
            else
                return stack[pointer];
        }

        private void increaseSize()
        {
            int[] newStack = new int[length * 2];

            for (int index = 0; index < length; index++)
                newStack[index] = stack[index];

            stack = newStack;
            length *= 2;
        }

    }
}

