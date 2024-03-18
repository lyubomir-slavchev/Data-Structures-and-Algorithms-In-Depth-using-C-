namespace LinkedList
{
    public class Node {
        public int element;
        public Node next;

        public Node(int e , Node n)
        {
            element = e;
            next = n;
        }
    }
    internal class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public LinkedList()
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
            if (size == 0) {
                return true;
            }
            return false;
        }

        public void addLast(int e) { 
            Node newest = new Node(e, null);
            if (isEmpty())
                head = newest;
            else
                tail.next = newest;

            tail = newest;
            size++;
        }

        public void display() {
            Node p = head;
            while (p!=null) {
                Console.Write(p.element + " --->  ");
                p = p.next;
            }
            Console.WriteLine();
        }

        public void addFirst(int e) {
            Node newest = new Node(e, null);
            if (isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else {
                newest.next = head;
                head = newest;             
            }
            size++;
        }

        public void addAny(int e, int pos){
            if (pos <= 0 || pos >= size) {
                Console.WriteLine("Invalid");
                return;
            }

            Node newest = new Node(e, null);
            Node p = head;
            int i = 1;
            while (i < pos - 1) { 
                p=p.next;
                i++;
            }
            newest.next = p.next;
            p.next = newest;
            size++;
        }

        public int removeFirst() {
            if (isEmpty())
            {
                Console.WriteLine("List is empty");
                return -1;
            }
            else {
                int e = head.element;
                head = head.next;
                size--;
                if (isEmpty())
                {
                    tail = null;

                }
                return e;
                }

        }

        public int removeLast() {
            if (isEmpty())
            {
                Console.WriteLine("List is empty");
                return -1;
            }
            Node p = head;
            int i = 1;
            while (i < length() - 1) {
                p = p.next;
                i++;
            }
            tail = p;
            p = p.next;
            int e = p.element;
            tail.next = null;
            size--;
            return e;
        }

        public int removeAny(int position) {
            if (position <= 0 || position >= size-1)
            {
                Console.WriteLine("Invalid");
                return - 1;
            }
            Node p = head;
            int i =1;
            while (i <= position - 1) {
                p = p.next;
                i++;
            }
            int e = p.next.element;
            p.next = p.next.next;
            size++;
            return e;
        }

        public int search(int key) {
            if (isEmpty())
            {
                Console.WriteLine("List is empty");
                return -1;
            }
            Node p = head;
            int i = 0;
            while (key != p.element) { 
                p=p.next;
                i++;
            }
            return i;

        }


        static void Main(string[] args)
        {
          var l = new LinkedList();
            l.addLast(7);
            l.addLast(4);
            l.addLast(12);
            l.addLast(9);
            Console.WriteLine(l.length());
            l.display();
            Console.WriteLine(l.search(7));
        }
    }
}