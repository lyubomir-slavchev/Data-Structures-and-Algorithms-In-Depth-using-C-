using System.Security.Cryptography.X509Certificates;

namespace BinarySearchTree
{
    class Node {
        public int element;
        public Node left;
        public Node right;

        public Node(int e, Node l, Node r)
        {
            element = e;
            left = l;
            right = r;
        }
    }
    internal class BinarySearchTree
    {
        Node root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void insert(Node troot, int e) {
            Node temp = null;
            while (troot != null) {
                temp= troot;
                if (e == troot.element)
                    return;
                else if (e < troot.element) { 
                    troot = troot.left;
                }
                else if (e > troot.element)
                {
                    troot = troot.right;
                }
            }
            Node n = new Node (e, null,null);
            if (root != null) {
                if (e < temp.element)
                    temp.left = n;
                else
                    temp.right = n;
            }
            else 
                root = n;
        }

        public Node rinsert(Node troot,int e) {
            if (troot != null)
            {
                if (e < troot.element)
                {
                    troot.left = rinsert(troot.left, e);
                }
                else if (e > troot.element)
                {
                    troot.right = rinsert(troot.right, e);
                }
            }
            else {
                Node n = new Node(e, null, null);
                troot = n;

            }
            return troot;
            
        }

        public void inorder(Node troot) {
            if (troot != null) { 
                inorder(troot.left);
                Console.Write(troot.element + "  ");
                inorder(troot.right);
                
            }
        }

        public void preorder(Node troot) {
            if (troot != null) {
                Console.Write(troot.element + "  ");
                preorder(troot.left);
                preorder(troot.right);
            }
        }

        public void postorder(Node troot)
        {
            if (troot != null)
            {
                postorder(troot.left);
                postorder(troot.right);
                Console.Write(troot.element + "  ");
            }
        }

        public bool search(int key) {
            Node troot = root;
            while (troot != null)
            {
                if (key == troot.element)
                    return true;
                else if (key < troot.element)
                    troot = troot.left;
                else if (key > troot.element)
                    troot = troot.right;
            }
            return false;
        }

        public bool rsearch(Node troot,int key) {
            if (troot != null) {
                if (key == troot.element)
                    return true;
                else if (key < troot.element)
                    return rsearch(troot.left, key);
                else if (key > troot.element)
                    return rsearch(troot.right,key);       
            }
            return false;
        }


        public bool delete(int e) { 
            Node p = root;
            Node pp = null;
            while (p != null && p.element != e)
            {
                pp = p;
                if (e<p.element)
                    p=p.left;
                else
                    p= p.right;
            }
            if (p == null) 
                return false;
            if (p.left != null && p.right != null) { 
                Node s = p.left;
                Node ps = p;
                while (s.right != null) {
                    ps = s;
                    s = s.right;
                }
                p.element = s.element;
                p = s;
                pp = ps;

            }

            Node c = null;
            if(p.left != null)
                c = p.left;
            else
                c = p.right;
            if (p == root)
                root = null;
            else
            {
                if (p == pp.left)
                    pp.left = c;
                else
                    pp.right = c;
            }
            return true;
        }

        public int count(Node troot) {
            int x = 0;
            int y = 0;
            if (troot == null) 
                return 0;
            else {
                x = count(troot.left);
                y = count(troot.right);
                return x + y + 1;
            }
        
        }

        public int height(Node troot) {
            if (troot == null) return 0;
            else { 
                int x = height(troot.left);
                int y = height(troot.right);
                if (x > y)           
                    return x + 1;               
                else
                    return y + 1;
            }
        }


        static void Main(string[] args)
        {
            var b = new BinarySearchTree();
            b.insert(b.root,50);
            b.insert(b.root, 30);
            b.insert(b.root, 80);
            b.insert(b.root, 10);
            b.insert(b.root, 40);
            b.insert(b.root, 60);
            b.insert(b.root, 90);
            b.delete(50);
            b.inorder(b.root); 
            Console.WriteLine();
            b.preorder(b.root);
            Console.WriteLine();
            b.postorder(b.root);
            Console.WriteLine();
            Console.WriteLine(b.count(b.root));
            
        }
    }
}