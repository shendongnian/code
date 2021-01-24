    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ClassLibrary2 {
    
        [TestFixture]
        public class NodePathHandler {
    
            [Test]
            public void SetNodePathsTest() {
                var tree = new Node() {
                    IdNode = 1,
                    Childs = Enumerable.Range(1, 2).Select(nId1 => new Node() {
                        IdNode = 1 + nId1,
                        Childs = Enumerable.Range(1, 2).Select(nId2 => new Node() {
                            IdNode = nId1 + nId2,
                            Childs = Enumerable.Range(1, 2).Select(nId3 => new Node() {
                                IdNode = nId2 + nId3,
                                Childs = Enumerable.Empty<Node>().ToList()
                            }).ToList()
                        }).ToList()
                    }).ToList()
                };
                var sw = Stopwatch.StartNew();
                SetNodePaths(tree);
                Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms");
            }
    
            public void SetNodePaths(Node node, string parentPath = null) {
                node.Path = parentPath == null ? node.IdNode.ToString() : $"{parentPath}.{node.IdNode}";            
                //Sequential
                //node.Childs.ForEach(n => SetNodePaths(n, node.Path));
                //Parallel
                Parallel.ForEach(node.Childs, n => SetNodePaths(n, node.Path));
                Console.WriteLine($"Node Id: {node.IdNode} Node Path: {node.Path}");
            }
        }
    
        public class Node {
            public long IdNode { get; set; }
            public List<Node> Childs { get; set; }
            public string Path { get; set; }
            public Data Data { get; set; }
        }
    
        public class Data { }
    }
