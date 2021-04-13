
namespace Data_Structures
{
    class LinkedListQueue
    {
        public class Node
        {
            public int value { get; set; }
            public Node next { get; set; }
            public Node(int value) { this.value = value; next = null; }
        }

        public int size
        {
            get
            {
                return count;
            }
        }

        private Node start = null;
        private int count = 0;
        /* Reduces insertion complexity from O(N) to O (1) */
        private Node end = null;

        public void Enqueue(int element)
        {
            Node current = new Node(element);
            if (IsEmpty())
                start = current;
            else
                end.next = current;

            end = current;
            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                return -1;

            int value = RemoveNode();

            /* Check for empty condition post removal */
            if (IsEmpty())
                end = null;

            return value;
        }

        private int RemoveNode()
        {
            Node current = start;
            start = start.next;
            current.next = null; // garbage collection

            count--;
            return current.value;

        }

        public int Peek()
        {
            if (IsEmpty())
                return -1;

            return start.value;
        }

        public bool IsEmpty()
        {
            return start == null;
        }

    }
}
