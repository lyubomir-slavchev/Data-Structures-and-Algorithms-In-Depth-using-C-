using System;
using System.ComponentModel.DataAnnotations;

namespace Circular_LinkedList
{
    public class Node {
        public int element;
        public Node next;
        public Node(int e, Node n)
        {
            element = e;
            next = n;
        }
    }
    internal class CircularLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public CircularLinkedList( )
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
            Node newest = new Node(e,null);
            if (isEmpty())
            {
                newest.next = newest;
                head = newest;
            }
            else {
                newest.next = tail.next;
                tail.next = newest;
            }
            
            tail = newest;
            size++;
        }

        public void display() {
            if (isEmpty()) {
                Console.WriteLine("invalid");
            }
            Node p= head;
            int i = 0;
            while (i < length())
            {
                Console.Write(p.element + "-->");
                p = p.next;
                i++;
            }
            Console.WriteLine();
        }

        public void addFirst(int e) {
            Node newest = new Node(e, null);
            if (isEmpty())
            {
                newest.next = newest;
                head = newest;
                tail= newest;
                
            }
            newest.next = head;
            head = newest;
            tail.next = head;
            size++;
        }

        public void addAny(int e, int position) {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("invalid");
            }
            Node newest = new Node(e, null);
            Node p = head;
            int i = 1;
            while (i < position - 1) {
                p= p.next;
                i++;
            }
            newest.next = p.next;
            p.next = newest;
            size++;
            
        }

        public int removeFirst() {
            if (isEmpty()) {
                Console.WriteLine( "Invalid" );
            }
            int e = head.element;
            tail.next = head.next;
            head = head.next;
            size--;
            if (isEmpty()) {
                head = null;
                tail = null;
            }
            return e;
        }

        public int removeLast()
        {
            if (isEmpty()) {
                Console.WriteLine("Invalid");
                return -1;
            }
            Node p = head;
            int i = 1;
            while (i < length() - 1) {
                p = p.next;
                i++;
            }
            int e = tail.element;
            p.next = tail.next;
            tail = p;
            size--;
            if (isEmpty())
            {
                head = null;
                tail = null;
            }
            return e;
        }

        public int removeAny(int position) {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("invalid");
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
            var l = new CircularLinkedList();
            l.addLast(7);
            l.addLast(8);
            l.addLast(9);
            l.addLast(6);
            l.addLast(5);
            l.display();
            Console.WriteLine(   l.removeLast());
            l.display() ;
            Console.WriteLine(l.removeLast());
            l.display();

        }
    }
}