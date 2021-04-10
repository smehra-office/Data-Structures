
using System;
using System.Text;

namespace Data_Structures
{
    class DoubleStack
    {
        private int counterA;
        private int counterB;
        private int[] stack;
        private int length
        {
            get
            {
                return stack.Length - 1;
            }
            set
            {
                length = value;
            }
        }

        public DoubleStack()
        {
            stack = new int[2];
            counterA = -1;
            counterB = length + 1;
        }

        public void PushStackA(int element)
        {
            if (IsStackAFull())
                growStack();

            stack[++counterA] = element;
        }

        public void PushStackB(int element)
        {
            if (IsStackBFull())
                growStack();

            stack[--counterB] = element;
        }

        public void PopStackA()
        {
            if (IsStackAEmpty())
                Console.WriteLine("Stack A is empty");
            else
                counterA--;
        }

        public void PopStackB()
        {
            if (IsStackBEmpty())
                Console.WriteLine("Stack B is empty");
            else
                counterB++;
        }

        public void PrintStackA()
        {
            StringBuilder str = new StringBuilder("[");
            if (!IsStackAEmpty())
                for (int i = counterA; i >= 0; i--)
                    str.Append($"{ stack[i]} ");

            str.Append("]");

            Console.WriteLine(str.ToString());
        }

        public void PrintStackB()
        {
            StringBuilder str = new StringBuilder("[");
            if (!IsStackBEmpty())
                for (int i = counterB; i <= length; i++)
                    str.Append($"{stack[i]} ");

            str.Append("]");

            Console.WriteLine(str.ToString());
        }
        
        public bool IsStackAFull()
        {
            return counterA == length || counterA + 1 == counterB;
        }

        public bool IsStackBFull()
        {
            return counterB == 0 || counterB - 1 == counterA;
        }

        public bool IsStackBEmpty()
        {
            return counterB == length + 1;
        }

        public bool IsStackAEmpty()
        {
            return counterA == -1;
        }

        private void growStack()
        {
            int[] newStack = new int[(length + 1) * 2];
            copyStackA(newStack);
            copyStackB(newStack);
            stack = newStack;
        }

        /* Copies elements of stack A in new array*/
        private void copyStackA(int[] element)
        {
            for (int i = 0; i < counterA + 1; i++)
            {
                element[i] = stack[i];
            }
        }

        /* Copies elements of stack B in new array and updates counter B */
        private void copyStackB(int[] element)
        {
            int counter = element.Length;
            for (int index = length; index >= counterB; index--)
            {
                element[--counter] = stack[index];
            }

            counterB = counter;
        }

    }
}
