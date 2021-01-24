    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    namespace xmlTest
    {
        internal class Program
        {
            public static void Main(string[] args)
            {
                var document = CreateDocument();
                // Gets all children of the root element whose name starts with "node".
                var nodeElements = document.XPathSelectElements("/root/*[starts-with(name(), 'node')]").ToList();
                // Creates Tuples in the fashion: { 1, $NODE_ONE }, { 2, $NODE_TWO }, ... 
                // This is done because some values might be skipped.
                var indexedNodes = nodeElements.Select(x => new Tuple<int, XElement>(int.Parse(x.Descendants("node-id").First().Value), x)).ToList();
                
                foreach(var indexedNode in indexedNodes)
                {
                    var parentId = GetParentNodeId(indexedNode.Item2);
                    if (parentId != null)
                    {
                        // Remove the node from its parent.
                        indexedNode.Item2.Remove();
                        // Add the node to the new parent.
                        var newParent = indexedNodes.First(x => x.Item1 == parentId).Item2;
                        newParent.Add(indexedNode.Item2);
                    }
                }
                Console.WriteLine(document.ToString());
            }
            static int? GetParentNodeId(XElement element) {
                try {
                    var parentId = int.Parse(element.Descendants("parent-id").First().Value);
                    return parentId;
                }
                catch // Add some appropriate error handling here. 
                {
                    return null;
                }
            }
            private static XDocument CreateDocument()
            {
                const string xml =
                    "<root> <node-one> <parent-id /> <node-id>1</node-id> <value>foo</value> </node-one> <node-two> <parent-id>1</parent-id> <node-id>2</node-id> <value>bar</value> </node-two> <node-three> <parent-id>1</parent-id> <node-id>3</node-id> <value>baz</value> </node-three> <node-four> <parent-id>3</parent-id> <node-id>4</node-id> <value>qux</value> </node-four> </root>";
                return XDocument.Parse(xml);
            }
        }
    }
