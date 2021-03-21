using System;
using System.Text;

namespace Data_Structures
{
    public class Dynamic_Array<T> where T : struct
    {
        private int index = 0;
        
        public T[] Array { get; set; }
        public int TotalElements { get; set; }

        public Dynamic_Array(int size)
        {
            Array = new T[size];
            TotalElements = 0;
        }

        public Dynamic_Array()
        {
            Array = new T[1];
            TotalElements = 0;
        }

        public T Insert(T value)  // appends sequentially from start to end
        {
            if (TotalElements + 1 == Array.Length)
                Array = GrowArraySize(Array.Length * 2);

            else if (!Array[index].Equals(default(T)))
            {
                /* keep traversing until empty cell is found */
                while (!Array[index].Equals(default(T)))
                    index++;
            }
            Array[index++] = value;
            TotalElements++;

            return value;
        }

        public void Insert(T value, int index)  // inserts at specific index
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Index is not in range");
            else if (index > Array.Length - 1)
                Array = GrowArraySize(index);
            else if (Array[index].Equals(null))
                throw new SystemException("Value already exists at the given index");

            TotalElements++;
            Array[index - 1] = value;
        }

        public T remove(int index)
        {
            if (index < 0 || index > Array.Length - 1)
                throw new IndexOutOfRangeException("Cannot delete element beyond the array range");
            else if (Array[index].Equals(default(T)))
                throw new NullReferenceException("Index is already not defined");

            T removedElement = Array[index];
            Array[index] = default;
            TotalElements--;

            return removedElement;
        }

        private T[] GrowArraySize(int size)
        {
            T[] newArray = new T[size]; // create new array with given size
            int index = 0;
            foreach (T value in Array)
            {
                newArray[index] = value;
                index += 1;
            }
            return newArray;
        }

        public void reset()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = default(T);
            }
        }

        override public String ToString()
        {
            if (TotalElements == 0)
                return "[]";
            else
            {
                StringBuilder str = new StringBuilder();
                str.Append("[");
                foreach(T value in Array)
                    str.Append($"{value},");

                str.Append("]");
                return str.ToString();
            }
        }

    }
}



