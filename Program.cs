using AppBinaryTree;
using System.ComponentModel;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var tree = new BinaryTree<string>();
            IDictionary<int, string> values = new Dictionary<int, string> {
                { 300, "A1" },
                {350, "B1" },
                {320, "C1" },
                {355, "D1" },
                {354, "E1" },
                {370, "F1" },
                {80, "G1" },
                {75, "H1" },
                {57, "I1" },
                {90,"J1" },
                {32,"K1" },
                {7,"L1" },
                {44,"M1" },
                {60,"N1" },
                {86,"O1" },
                {93,"P1" },
                {99,"Q1" },
                {100,"R1" },
             };
           
            foreach (var value in values)// new[] { 300, 350, 320, 355, 354, 370, 80, 75, 57, 90, 32, 7, 44, 60, 86, 93, 99, 100 })
                tree.Insert(value.Value, value.Key);

            //3. (a)  Write a function that counts the number of items in a binary tree.
            Console.WriteLine($"No. of items = {tree.Count()}");
            Console.WriteLine();

            // (b)  Write a function that returns the sum of all the keys in a binary tree.
            Console.WriteLine($"Sum of keys = {tree.Sum()}");
            Console.WriteLine();

            //(c) Write a function that returns the maximum value of all the keys in a binary
            // tree.Assume all values are nonnegative; return -1 if the tree is empty.
            Console.WriteLine($"Maximum value = {tree.Max()}");
            Console.WriteLine();

            // 5. (a)  The height of a tree is the maximum number of nodes on a path from the root
            // to a leaf node. Write a C# function that returns the height of a binary tree.
            Console.WriteLine($"Binary Tree Height = {tree.Height()}");

            //(b)  The cost of a path in a tree is sum of the keys of the nodes participating
            // in that path. Write a C function that returns the cost of the most expensive
            // path from the root to a leaf node.
            Console.WriteLine();
            Console.WriteLine($"Maximum Cost = {tree.MaxCost()}");

            // 6. A binary tree is said to be "balanced" if both of its subtrees  
            // are balanced and the height of its left subtree differs from the
            // height of its right subtree by at most 1.Write a C# function to
            // determine whether a given binary tree is balanced.

            Console.WriteLine();
            Console.WriteLine($"Binary Tree Is Balanced = {tree.IsBalanced()}");

            Console.WriteLine();
            Console.WriteLine("Print all nodes");
            tree.Print();

            // 4. Write a C# function that prints all the keys less than a given value v in a binary tree.
            Console.WriteLine();
            Console.WriteLine("Print all nodes less than 75");
            tree.Print(75);

            Console.WriteLine();
            Console.WriteLine("In-Order Tranversal");
            Console.WriteLine("Left->Root->Right Nodes recursively of each subtree");
            tree.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Pre-Order Tranversal");
            Console.WriteLine("//Root->Left->Right Nodes recursively of each subtree ");
            tree.PreOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Post-Order Tranversal");
            Console.WriteLine("Left->Right->Root Nodes recursively of each subtree");
            tree.PostorderTraversal();
            Console.WriteLine();
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in run binary tree : {ex.Message}");
        }
    }
}