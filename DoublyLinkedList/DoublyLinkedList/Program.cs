namespace DoublyLinkedList
{
    public class Node{
        public int element;
        public Node next;
        public Node prev;

        public Node(int e,Node n,Node p)
        {
            element = e;
            next = n;
            prev = p;
        }
}
    internal class DoublyLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int length() {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void addLast(int e) {
            Node newest = new Node(e, null, null);
            if (isEmpty()) {
                head = newest;
                tail = newest;
            }
            else
            {
                tail.next = newest;
                newest.prev = tail;
                tail = newest;
            }
            size++;
        }

        public void display() {
            Node p = head;
            while (p != null) {
                Console.Write(p.element + " --> ");
                p = p.next;
            }
            Console.WriteLine();
        }

        public void addFirst(int e) {
            Node newest = new Node(e, null, null);
            if (isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else {
                newest.next = head;
                head.prev = newest;
                head = newest;

            }
            size++;
        }

        public void addAny(int e, int position) {

            if (position <= 0 || position >= size) {
                Console.WriteLine("Invalid");
            }
            Node newest = new Node(e, null, null);
            Node p = head;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i++;

            }
            newest.next = p.next;
            newest.prev = p;
            p.next = newest;
            p.next.prev = newest;
            size++;

        }

        public int removeFirst() {
            if (isEmpty())
            {
                Console.WriteLine("Invalid");
                return -1;
            }
            int e = head.element;
            head.next.prev = null;
            head = head.next;
            size--;
            if (isEmpty()) {
                tail = null;
                head = null;
            }
            return e;
        }

        public int removeLast() {
            if (isEmpty()) {
                Console.WriteLine("Invalid");
                return -1;
            }
            int e = tail.element;
            tail = tail.prev;
            tail.next = null;
            size--;
            if (isEmpty())
            {
                head = null;
                tail = null;
            }
            return e;
        }

        public int removeAny(int position){
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid");
            }
            else if (isEmpty())
            {
                Console.WriteLine("Invalid");
                return -1;
            }
            Node p = head;
            int i = 1;

            while (i < position - 1)
            {
                p = p.next;
                i++;
            }
            int e = p.next.element;
            p.next = p.next.next;
            p.next.prev = p;
            size--;
            if (isEmpty())
            {
                head = null;
                tail = null;
            }
            return e;
        }
        static void Main(string[] args)
        {
           var l = new DoublyLinkedList();
            l.addLast(1);
            l.addLast(2);
            l.addLast(3);
            l.addLast(4);
            l.addLast(5);
            l.addAny(10, 3);
            l.display();
            Console.WriteLine(l.length());
            
        }
    }
}