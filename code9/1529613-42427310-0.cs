    using System;
    
    namespace MyBinaryTree
    {
        // Creates a binary tree
        // Finds the lowest common ancestor in a binary tree
    
        class МainSolution
        {
            static void Main(string[] args)
            {
                
                // Initialises binary tree view
    
                var btView = new ViewBinaryTree();
                btView.BinaryTreeView();
    
                // Initialises new binary tree
    
                BinarySearchTree tree = new BinarySearchTree();
    
                // Reads the desired number of nodes
    
                Console.Write("Enter how many nodes you want: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine();
    
                // Reads the nodes' values
    
                for (int i = 1; i <= number; i++)
                {
                    Console.Write($"Enter name of {i} node: ");
                    string nodeName = Console.ReadLine().ToUpper();                
                    tree.Insert(nodeName);                
                }
    
                // Lowest common ancestor - reads the two required values
                // Checks the values
                // Prints the lowest common ancestor
    
                bool isValid = true;
    
                while (isValid)
                {
                    Console.WriteLine();
                    Console.Write("Please enter the first node value: ");
                    string nameOne = Console.ReadLine().ToUpper();
                    Console.Write("Please enter the second node value: ");
                    string nameTwo = Console.ReadLine().ToUpper();
    
                    if (tree.Find(nameOne) == true && tree.Find(nameTwo) == true)
                    {
                        Console.WriteLine();
                        var result = tree.SearchLCA(tree.root, nameOne, nameTwo);
                        Console.WriteLine($"Lowest common ancestor: {result} ");
                        Console.WriteLine();
                        isValid = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid name!");
                    }
                }
             }
         }
    }
