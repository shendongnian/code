    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                var trie = new Trie();
                trie.InsertRange(File.ReadLines("words.txt"));
                Console.WriteLine("Type a prefix and press return.");
                while (true)
                {
                    string prefix = Console.ReadLine();
                    if (string.IsNullOrEmpty(prefix))
                        continue;
                    var node = trie.Prefix(prefix);
                    if (node.Depth == prefix.Length)
                    {
                        foreach (var suffix in suffixes(node))
                            Console.WriteLine(prefix + suffix);
                    }
                    else
                    {
                        Console.WriteLine("Prefix not found.");
                    }
                    Console.WriteLine();
                }
            }
            static IEnumerable<string> suffixes(Node parent)
            {
                var sb = new StringBuilder();
                return suffixes(parent, sb).Select(suffix => suffix.TrimEnd('$'));
            }
            static IEnumerable<string> suffixes(Node parent, StringBuilder current)
            {
                if (parent.IsLeaf())
                {
                    yield return current.ToString();
                }
                else
                {
                    foreach (var child in parent.Children)
                    {
                        current.Append(child.Value);
                        foreach (var value in suffixes(child, current))
                            yield return value;
                        --current.Length;
                    }
                }
            }
        }
        public class Node
        {
            public char Value { get; set; }
            public List<Node> Children { get; set; }
            public Node Parent { get; set; }
            public int Depth { get; set; }
            public Node(char value, int depth, Node parent)
            {
                Value = value;
                Children = new List<Node>();
                Depth = depth;
                Parent = parent;
            }
            public bool IsLeaf()
            {
                return Children.Count == 0;
            }
            public Node FindChildNode(char c)
            {
                return Children.FirstOrDefault(child => child.Value == c);
            }
            public void DeleteChildNode(char c)
            {
                for (var i = 0; i < Children.Count; i++)
                    if (Children[i].Value == c)
                        Children.RemoveAt(i);
            }
        }
        public class Trie
        {
            readonly Node _root;
            public Trie()
            {
                _root = new Node('^', 0, null);
            }
            public Node Prefix(string s)
            {
                var currentNode = _root;
                var result = currentNode;
                foreach (var c in s)
                {
                    currentNode = currentNode.FindChildNode(c);
                    if (currentNode == null)
                        break;
                    result = currentNode;
                }
                return result;
            }
            public bool Search(string s)
            {
                var prefix = Prefix(s);
                return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
            }
            public void InsertRange(IEnumerable<string> items)
            {
                foreach (string item in items)
                    Insert(item);
            }
            public void Insert(string s)
            {
                var commonPrefix = Prefix(s);
                var current = commonPrefix;
                for (var i = current.Depth; i < s.Length; i++)
                {
                    var newNode = new Node(s[i], current.Depth + 1, current);
                    current.Children.Add(newNode);
                    current = newNode;
                }
                current.Children.Add(new Node('$', current.Depth + 1, current));
            }
            public void Delete(string s)
            {
                if (!Search(s))
                    return;
                var node = Prefix(s).FindChildNode('$');
                while (node.IsLeaf())
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }
    }
                                                      
