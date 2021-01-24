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
        public class MemberNetworkViewModel
        {
            public int MemberGenerationNumber { get; set; }
            public int MemberId { get; set; }
            public int ParentId { get; set; }
            public List<MemberNetworkViewModel> children { get; set; }
        }
        class Program
        {
            public static void Main(string[] args)
            {
                Node root =
                    new Node {ID = 1, Children = new List<Node>{
                        new Node {ID = 2, Children = new List<Node>() },
                        new Node {ID = 3, Children = new List<Node>{
                            new Node {ID = 4, Children = new List<Node>()},
                            new Node {ID = 5, Children = new List<Node>()}}},
                        new Node {ID = 6, Children = new List<Node>() }
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
                bool any = false;
                foreach (var child in children(root))
                {
                    any = true;
                    flatten(pathSoFar, child, select, children, output);
                }
                if (!any)
                    output(pathSoFar.ToList());
                pathSoFar.RemoveAt(pathSoFar.Count-1);
            }
        }
    }
