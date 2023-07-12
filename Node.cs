namespace AppBinaryTree
{
    /// <summary>
    /// Generic Tree Node
    /// Each node has two nodes called left and right
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class Node<T> where T : IComparable
    {
        public int Key { get; private set; }

        /// <summary>
        /// Value stored inside node. May be any type
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Left Node
        /// </summary>
        public Node<T> Left { get; private set; } = null!;

        /// <summary>
        /// Right Node
        /// </summary>
        public Node<T> Right { get; private set; } = null!;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="value">Node Value</param>
        public Node(T value, int key)
        {
            Value = value;
            Key = key;
        }
        /// <summary>
        /// Recursively calls insert down the ree until it find an open spot
        ///           85
        ///          /  \
        ///        75    95
        ///   
        /// </summary>
        /// <param name="newValue">New Node Value</param>
        public void Insert(T newValue, int newKey)
        {
            // if the value passed in is less than the data then insert to left node
            if (newKey < Key)
            {
                // if left node is null create one
                if (Left == null)
                {
                    Left = new Node<T>(newValue, newKey);
                }
                else
                {
                    // if left node is not null recursively call insert on the left node
                    Left.Insert(newValue, newKey);
                }
            }
            else
            {
                // if the value passed in is greater than or equal to the data then insert to right node
                if (Right == null) // if right child node is null create one
                {
                    Right = new Node<T>(newValue, newKey);
                }
                else // if right node is not null recursivly call insert on the right node
                {
                    Right.Insert(newValue, newKey);
                }
            }
        }

        /// <summary>
        /// Small value in binary tree is the last left node 
        /// </summary>
        /// <returns></returns>
        public T SmallestValue()
        {
            // once we reach the last left node we return its data
            if (Left == null)
            {
                return Value;
            }
            else
            {//otherwise keep calling the next left node
                return Left.SmallestValue();
            }
        }

        /// <summary>
        /// Largest value in binary tree is the last right node
        /// </summary>
        /// <returns></returns>
        public int MaxValue()
        {
            // once we reach the last right node we return its data
            if (Right == null)
            {
                return Key;
            }
            else//otherwise keep calling the next right node
            {
                return Right.MaxValue();
            }
        }

        

        public int Count(Node<T> root)
        {
            if (root == null) return 0;
            int l = Count(root.Left);
            int r = Count(root.Right);

            return 1 + l + r;
        }

        public int Sum(Node<T> root)
        {
            if(root == null) return 0;
            return root.Key + Sum(root.Left) + Sum(root.Right);
        }
    
        /// <summary>
        /// function that prints all the keys less than a given value v in a binary tree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="textFormat"></param>
        /// <param name="spacing"></param>
        /// <param name="topMargin"></param>
        /// <param name="leftMargin"></param>
        public void Print(Node<T> root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) throw new Exception("Binary tree is empty");

            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo<T>>();
            var next = root;

            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo<T> { BTNode = next, Text = next.Key.ToString(textFormat) };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.BTNode.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.BTNode.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        public Node<T> FindByKey(int key)
        {
            //this node is the starting current node
            Node<T> currentNode = this;

            //loop through this node and all of the children of this node
            while (currentNode != null)
            {
                //if the current nodes data is equal to the value passed in return it
                if (key == currentNode.Key)
                {
                    return currentNode;
                }
                else if (key > currentNode.Key)//if the value passed in is greater than the current data then go to the right child
                {
                    currentNode = currentNode.Right;
                }
                else//otherwise if the value is less than the current nodes data the go to the left child node 
                {
                    currentNode = currentNode.Left;
                }
            }
            //Node not found
            return null;
        }

        public Node<T> FindRecursiveByKey(int key)
        {
            //value passed in matches nodes data return the node
            if (key == Key)
            {
                return this;
            }
            else if (key < Key && Left != null)//if the value passed in is less than the current data then go to the left child
            {
                return Left.FindRecursiveByKey(key);
            }
            else if (Right != null)//if its great then go to the right child node
            {
                return Right.FindRecursiveByKey(key);
            }
            else
            {
                return null;
            }
        }

        //Left->Root->Right Nodes recursively of each subtree 
        public void InOrderTraversal(ref string content)
        {
            //first go to left child its children will be null so we print its data
            Left?.InOrderTraversal(ref content);
            //Then we print the root node 
            //Console.Write($" ({Key}) ");
            content += (content.Length > 0 ? " => " : "") + Key.ToString();
            //Then we go to the right node which will print itself as both its children are null
            Right?.InOrderTraversal(ref content);

        }


        //Root->Left->Right Nodes recursively of each subtree 
        public void PreOrderTraversal(ref string content)
        {
            //First we print the root node 
            //Console.Write($" ({Key}) ");
            content += (content.Length > 0 ? " => " : "") + Key.ToString();
            //Then go to left child its children will be null so we print its data
            Left?.PreOrderTraversal(ref content);

            //Then we go to the right node which will print itself as both its children are null
            Right?.PreOrderTraversal(ref content);
        }

        //Left->Right->Root Nodes recursively of each subtree 
        public void PostorderTraversal(ref string content)
        {
            //First go to left child its children will be null so we print its data
            Left?.PostorderTraversal(ref content);

            //Then we go to the right node which will print itself as both its children are null
            Right?.PostorderTraversal(ref content);

            //Then we print the root node 
            //Console.Write($" ({Key}) ");
            content += (content.Length > 0 ? " => " : "") + Key.ToString();
        }

        /// <summary>
        /// (a)  The height of a tree is the maximum number of nodes on a path from the root
        /// to a leaf node.Write a C# function that returns the height of a binary tree.
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            //return 1 when leaf node is found
            if (this.Left == null && this.Right == null)
            {
                return 1; //found a leaf node
            }

            int left = 0;
            int right = 0;

            //recursively go through each branch
            if (this.Left != null)
                left = this.Left.Height();
            if (this.Right != null)
                right = this.Right.Height();

            //return the greater height of the branch
            if (left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
            }
        }

        /// <summary>
        /// (b)  The cost of a path in a tree is sum of the keys of the nodes participating
        /// in that path.Write a C function that returns the cost of the most expensive
        /// path from the root to a leaf node.
        /// </summary>
        /// <returns></returns>
        public int MaxCost()
        {
            //return 1 when leaf node is found
            if (this.Left == null && this.Right == null)
            {
                return Key; //found a leaf node
            }

            int left = 0;
            int right = 0;

            //recursively go through each branch
            if (this.Left != null)
                left = this.Left.MaxCost();
            if (this.Right != null)
                right = this.Right.MaxCost();

            //return the greater MaxCost of the branch
            if (left > right)
            {
                return (left + Key);
            }
            else
            {
                return (right + Key);
            }

        }

        /// <summary>
        /// A binary tree is said to be "balanced" if both of its subtrees  
        /// are balanced and the height of its left subtree differs from the
        /// height of its right subtree by at most 1.  Write a C# function to
        /// determine whether a given binary tree is balanced.
        /// </summary>
        /// <returns></returns>
        public bool IsBalanced()
        {
            int LeftHeight = Left != null ? Left.Height() : 0;
            int RightHeight = Right != null ? Right.Height() : 0;

            int heightDifference = LeftHeight - RightHeight;

            if (Math.Abs(heightDifference) > 1)
            {
                return false;
            }
            else
            {
                return ((Left != null ? Left.IsBalanced() : true) && (Right != null ? Right.IsBalanced() : true));
            }
        }
    }

    class NodeInfo<T> where T : IComparable
    {
        public Node<T> BTNode;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo<T> Parent, Left, Right;
    }
}
