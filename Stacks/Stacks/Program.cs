namespace Stacks
{
    class Node {
        public int element;
        public Node next;

        public Node(int e, Node n)
        {
           element= e;
           next= n;
        }
    }

    class StacksLinked {
        Node top;
        int size;

        public StacksLinked()
        {
            size=0;
            top = null;
        }

        public int length() {
            return size;
        }

        public bool isEmpty() { 
        return size == 0;
        }

        public void push(int e) {
            Node newest = new Node(e, null);
            if (isEmpty()) {
                top  = newest;

            }
            else { 
                newest.next = top;
                top = newest;
                
            }
            size++;

        }

        public int pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Invalid");
                return -1;
            }
            
                int e = top.element;
                top = top.next;
            
            size--;
            return e;
        }

        public int peak() {
            if (isEmpty()) {
                Console.WriteLine("Invalid");
                return -1;
            }
            return top.element;
        }

        public void display() { 
            Node p = top;
            while (p != null) {
                Console.Write(  p.element + "--");
                p= p.next;  
            }
            Console.WriteLine();
        }
    }


    internal class StacksArr
    {
        int[] data;
        int top;

        public StacksArr(int n)
        {
            data=new int[n];
            top=0;   
        }

        public int length() {
            return top;
        }

        public bool isEmpty() { 
            return top== 0;
        }

        public bool isFull() { 
            return top== data.Length;
        }


        public void push (int e) {
            if (isFull())
            {
                Console.WriteLine("Overflow");
                return;
            }
            else {
                data[top] = e;
                top++;

            }
        }

        public int pop()
        {
            if (isEmpty()) {
                Console.WriteLine("Underflow");
                return -1;
            }
            int e = data[top-1];
            top--;
            return e;
        }

        public int peak() {
            if (isEmpty())
            {
                Console.WriteLine("Underflow");
                return -1;
            }
            return data[top-1];
        }

        public void display() {
            for (int i = 0; i < length(); i++) {
                Console.Write(data[i] + "--");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var s = new StacksArr(10);
            s.push(5);
            s.push(4);
            s.push(3);
            s.push(2);
            s.push(1);
            s.display();
            Console.WriteLine(s.length());
            Console.WriteLine(s.pop());
            Console.WriteLine(s.isEmpty());




        }
    }
}