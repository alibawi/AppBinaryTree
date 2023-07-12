using System.Xml.Linq;

namespace AppBinaryTree
{
    /// <summary>
    /// Binary Tree Class.
    /// The BinaryTree class has a single property, Root.
    /// </summary>
    /// <typeparam name="T">Accept any type</typeparam>
    public class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Root Property is the topmost node in the tree
        /// </summary>
        public Node<T> Root { get; private set; } = null!;

        /// <summary>
        /// Add method to add a new value to the tree
        /// </summary>
        /// <param name="newkey"></param>
        public void Insert(T value, int newkey)
        {
            if (Root == null)
            {
                Root = new Node<T>(value, newkey);
            }
            else
            {
                Root.Insert(value, newkey);
            }
        }

        /// <summary>
        /// function to counts the number of items in a binary tree.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if (Root == null) return -1;
            return Root.Count(Root);
        }

        /// <summary>
        /// function that returns the sum of all the keys in a binary tree.
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            if(Root == null) throw new Exception("Binary tree is empty");
            return Root.Sum(Root);
        }

        /// <summary>
        /// function that prints all the keys less than a given value v in a binary tree.
        /// </summary>
        /// <param name="key"></param>
        public void Print(int key = 0)
        {
            Node<T> node = Root;
            if(key != 0) node = Root.FindByKey(key).Left;

            if (node != null)
            {
                node.Print(node, "(0)", 15, 4);
            }
            else
            {
                throw new Exception("Node not found");
            }
        }

        /// <summary>
        /// function that returns the maximum value of all the keys in a binary
        /// tree.Assume all values are nonnegative; return -1 if the tree is empty.
        /// </summary>
        /// <returns></returns>
        public int Max()
        {
            //if we have a root node then we can search for the largest node
            if (Root != null)
            {
                return Root.MaxValue();
            }
            else
            {//otherwise we return -1
                return -1;
            }
        }

        /// <summary>
        /// The height of a tree is the maximum number of nodes on a path from the root
        /// to a leaf node.Write a C# function that returns the height of a binary tree.
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            //if root is null then height is zero
            if (Root == null) throw new Exception("Binary tree is empty");

            return Root.Height();
        }

        /// <summary>
        /// (b)  The cost of a path in a tree is sum of the keys of the nodes participating
        /// in that path.Write a C function that returns the cost of the most expensive
        /// path from the root to a leaf node.
        /// </summary>
        /// <returns></returns>
        public int MaxCost()
        {
            if(Root == null) throw new Exception("Binary tree is empty");
            return Root.MaxCost();
        }

        /// <summary>
        /// A binary tree is said to be "balanced" if both of its subtrees  
        /// are balanced and the height of its left subtree differs from the
        /// height of its right subtree by at most 1. function to
        /// determine whether a given binary tree is balanced.
        /// </summary>
        /// <returns></returns>
        public bool IsBalanced()
        {
            if (Root == null)//Empty Tree
                throw new Exception("Binary tree is empty");

            return Root.IsBalanced();
        }


        public void InOrderTraversal()
        {
            string content = string.Empty;
            if (Root == null) throw new Exception("Binary tree is empty");
            Root.InOrderTraversal(ref content);
            Console.WriteLine(content);
        }

        public void PreOrderTraversal()
        {
            string content = string.Empty;
            if (Root == null) throw new Exception("Binary tree is empty");
            Root.PreOrderTraversal(ref content);
            Console.WriteLine(content);
        }

        public void PostorderTraversal()
        {
            string content = string.Empty;
            if (Root == null) throw new Exception("Binary tree is empty");
            Root.PostorderTraversal(ref content);
            Console.WriteLine(content);
        }
    }
}
