    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace ConsoleApp3
    {
        class Node
        {
            public int ID;
            public List<Node> Children;
        }
        class Program
        {
            public static void Main(string[] args)
            {
                Node root =
                    new Node {ID = 1, Children = new List<Node>{
                        new Node {ID = 2},
                        new Node {ID = 3, Children = new List<Node>{
                            new Node {ID = 4},
                            new Node {ID = 5}}},
                        new Node {ID = 6 }
                    }};
                Flatten(
                    root, 
                    node => node.ID,
                    node => node.Children,
                    path => Console.WriteLine(string.Join(", ", path)));
            }
            public static void Flatten<T, U>(T root, Func<T, U> select, Func<T, IEnumerable<T>> children, Action<List<U>> output)
            {
                List<U> pathSoFar = new List<U>();
                flatten(pathSoFar, root, select, children, output);
            }
            static void flatten<T, U>(List<U> pathSoFar, T root, Func<T, U> select, Func<T, IEnumerable<T>> children, Action<List<U>> output)
            {
                pathSoFar.Add(select(root));
                if (children(root) == null)
                {
                    output(pathSoFar);
                    return;
                }
                foreach (var child in children(root))
                    flatten(pathSoFar.ToList(), child, select, children, output);
            }
        }
    }
