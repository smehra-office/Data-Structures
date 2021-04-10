using System;
using System.Text;

namespace Data_Structures
{
    class LinkedList<T> where T : struct
    {
        private class Node
        {
            public T value { get; set; }
            public Node next { get; set; }

            public Node(T value, Node next = null)
            {
                this.value = value;
                this.next = next;
            }
        }

        private Node first;
        private Node last;
        private int length = 0;

        public LinkedList()
        {
            first = null;
            last = null;
        }

        public void AddLast(T value)
        {
            var element = new Node(value);

            if (isEmpty())
                first = element;
            else
                last.next = element;

            last = element;
            length++;
        }

        public void AddFirst(T value)
        {
            var element = new Node(value, first);
            first = element;
            if (isEmpty())
                last = element;
            length++;
        }

        public void DeleteFirst()
        {
            if (isEmpty())
            {
                Console.WriteLine("nothing to delete!");
                return;
            }
            else if (length == 1)
                first = last = null;
            else
            {
                Node element = first;
                first = first.next;
                element.next = null; // else garbage collector won't un-allocate space
            }

            length--;
        }

        public void DeleteLast()
        {
            if (isEmpty())
            {
                Console.WriteLine("nothing to delete!");
                return;
            }
            else if (length == 1)
            {
                first = last = null;
            }
            else
            {
                var element = GetPreviousNode(last);
                element.next = null;
                last = element;
            }

            length--;
        }

        public bool Contains(T search)
        {
            return IndexOf(search) > -1 ? true : false;
            /* Good Approach */
        }

        public int IndexOf(T search)
        {
            var element = first;
            int index = 0;

            while (element != null)
                if (element.value.Equals(search))
                    return index;
                else
                {
                    element = element.next;
                    index++;
                }

            return -1;
        }

        override public string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");

            if (length > 0)
            {
                var element = first;
                while (element != null)
                {
                    str.Append($"{element.value}, ");
                    element = element.next;
                }
            }

            str.Append("]");

            return str.ToString();
        }

        private Node GetPreviousNode(Node item)
        {
            var current = first;
            while (current != null)
            {
                if (current.next == item)
                    return current;

                current = current.next;
            }
            return null;

        }

        private bool isEmpty()
        {
            return length == 0;
        }

        public int GetSize()
        {
            return length;
        }

        public T[] ToArray()
        {
            T[] array = new T[length];
            var current = first;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.value;
                current = current.next;
            }

            return array;
        }

        private Node reverseList(Node node)
        {
            if (node != null)
            {
                if (node.next == null)
                    first = node;

                else
                {
                    var nextNode = reverseList(node.next);
                    nextNode.next = node;
                }
            }

            return node;
        }

        public void ReverseList()
        {
            last = reverseList(first);
            if (last != null)
                last.next = null;
        }


        // Iterative Approach
        public void GetKthFromEnd(int index)
        {
            // list does not exist
            if (index <= 0 || first == null)
                return;

            Node forward = first;
            Node backward = first;

            while (index - 1 > 0)
            {
                forward = forward.next;
                // index does not exist
                if (forward == null)
                    return;

                index--;
            }

            while (forward.next != null)
            {
                forward = forward.next;
                backward = backward.next;
            }

            Console.WriteLine(backward.value);
        }
        private int GetKthElementFromEnd(Node current, int index)
        {
            if (current == null)
                return -1;

            if (current.next == null)
                return 1;

            int currentIndex = GetKthElementFromEnd(current.next, index) + 1;
            if (currentIndex == index)
                Console.WriteLine(current.value);

            return currentIndex;
        }

        /* Recursive Approach */
        public void GetKthFromEndUtil(int index)
        {
            int returnIndex = GetKthElementFromEnd(first, index);
            if (returnIndex < index)
                Console.WriteLine("Index does not exist!");
        }

        private int getMiddleElement(Node current, int index)
        {
            if (current == null)
                return -1;

            if (current.next == null)
                return getUpperBound(index);

            int middleIndex = getMiddleElement(current.next, index + 1);

            if (middleIndex == index)
                Console.WriteLine(current.value);

            return middleIndex;
        }

        private int getUpperBound(double value)
        {
            double middle = Math.Ceiling((double)value / 2);
            return (int)middle;
        }

        public void PrintMiddleElement()
        {
            int resultCode = getMiddleElement(first, 1);
            if (resultCode == -1)
                Console.WriteLine("Empty linked list!");
        }


        // Floyd Warshall Loop Finding Algorithm
        private bool findLoop(Node head)
        {
            if (head == null)
                return false;
            if (head.next == null)
                return false;

            Node first = head.next;
            Node second = head;

            while (first != null)
            {
                if (first.next != null)
                {
                    first = first.next;
                    second = second.next;
                }

                if (first == second)
                    return true;

                first = first.next;
            }

            return false;
        }

        public void DetectLoop()
        {
            bool result = findLoop(first);
            Console.WriteLine(result);
        }

        public void CreateLoop()
        {
            if (first != null)
                last.next = first;
        }

    }
}


