    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //this one uses strings as node names
                Dijkstra1.Program.Dijkstra();
                Console.ReadLine();
            }
        }
    }
    namespace Dijkstra1
    {
        class Program
        {
            //Sydney,Dubai,1
            //Dubai,Venice,2
            //Venice,Rio,3
            //Venice,Sydney,1
            //Sydney,Rio,7
            static List<List<String>> input1 = new List<List<string>>{
                   new List<String>() {"Sydney","0","1","7","1"},
                   new List<String>() {"Dubai", "1","0","0","2"},
                   new List<String>() {"Rio",   "7","0","0","3"},
                   new List<String>() {"Venice","1","2","3","0"},
                };
            static public void Dijkstra()
            {
                CGraph cGraph;
                cGraph = new CGraph(input1);
                Console.WriteLine("-------------Input 1 -------------");
                cGraph.PrintGraph();
            }
            class CGraph
            {
                List<Node> graph = new List<Node>();
                public CGraph(List<List<String>> input)
                {
                    foreach (List<string> inputRow in input)
                    {
                        Node newNode = new Node();
                        newNode.name = inputRow[0];
                        newNode.distanceDict = new Dictionary<string, Path>();
                        newNode.visited = false;
                        newNode.neighbors = new List<Neighbor>();
                        //for (int index = 1; index < inputRow.Count; index++)
                        //{
                        //    //skip diagnol values so you don't count a nodes distance to itself.
                        //    //node count start at zero
                        //    // index you have to skip the node name
                        //    //so you have to subtract one from the index
                        //    if ((index - 1) != nodeCount)
                        //    {
                        //        string nodeName = input[index - 1][0];
                        //        int distance = int.Parse(inputRow[index]);
                        //        newNode.distanceDict.Add(nodeName, new List<string>() { nodeName });
                        //    } 
                        //}
                        graph.Add(newNode);
                    }
                    //initialize neighbors using predefined dictionary
                    for (int nodeCount = 0; nodeCount < graph.Count; nodeCount++)
                    {
                        for (int neighborCount = 0; neighborCount < graph.Count; neighborCount++)
                        {
                            //add one to neighbor count to skip Node name in index one
                            if (input[nodeCount][neighborCount + 1] != "0")
                            {
                                Neighbor newNeightbor = new Neighbor();
                                newNeightbor.node = graph[neighborCount];
                                newNeightbor.distance = int.Parse(input[nodeCount][neighborCount + 1]);
                                graph[nodeCount].neighbors.Add(newNeightbor);
                                Path path = new Path();
                                path.nodeNames = new List<string>() { input[neighborCount][0] };
                                //add one to neighbor count to skip Node name in index one
                                path.totalDistance = int.Parse(input[nodeCount][neighborCount + 1]);
                                graph[nodeCount].distanceDict.Add(input[neighborCount][0], path);
                            }
                        }
                    }
                    foreach (Node node in graph)
                    {
                        foreach (Node nodex in graph)
                        {
                            node.visited = false;
                        }
                        TransverNode(node);
                    }
                }
                public class Neighbor
                {
                    public Node node { get; set; }
                    public int distance { get; set; }
                }
                public class Path
                {
                    public List<string> nodeNames { get; set; }
                    public int totalDistance { get; set; }
                }
                public class Node
                {
                    public string name { get; set; }
                    public Dictionary<string, Path> distanceDict { get; set; }
                    public bool visited { get; set; }
                    public List<Neighbor> neighbors { get; set; }
                }
                static void TransverNode(Node node)
                {
                    if (!node.visited)
                    {
                        node.visited = true;
                        foreach (Neighbor neighbor in node.neighbors)
                        {
                            TransverNode(neighbor.node);
                            string neighborName = neighbor.node.name;
                            int neighborDistance = neighbor.distance;
                            //compair neighbors dictionary with current dictionary
                            //update current dictionary as required
                            foreach (string key in neighbor.node.distanceDict.Keys)
                            {
                                if (key != node.name)
                                {
                                    int neighborKeyDistance = neighbor.node.distanceDict[key].totalDistance;
                                    if (node.distanceDict.ContainsKey(key))
                                    {
                                        int currentDistance = node.distanceDict[key].totalDistance;
                                        if (neighborKeyDistance + neighborDistance < currentDistance)
                                        {
                                            List<string> nodeList = new List<string>();
                                            nodeList.AddRange(neighbor.node.distanceDict[key].nodeNames);
                                            nodeList.Insert(0, neighbor.node.name);
                                            node.distanceDict[key].nodeNames = nodeList;
                                            node.distanceDict[key].totalDistance = neighborKeyDistance + neighborDistance;
                                        }
                                    }
                                    else
                                    {
                                        List<string> nodeList = new List<string>();
                                        nodeList.AddRange(neighbor.node.distanceDict[key].nodeNames);
                                        nodeList.Insert(0, neighbor.node.name);
                                        Path path = new Path();
                                        path.nodeNames = nodeList;
                                        path.totalDistance = neighbor.distance + neighborKeyDistance;
                                        node.distanceDict.Add(key, path);
                                    }
                                }
                            }
                        }
                    }
                }
                public void PrintGraph()
                {
                    foreach (Node node in graph)
                    {
                        Console.WriteLine("Node : {0}", node.name);
                        foreach (string key in node.distanceDict.Keys.OrderBy(x => x))
                        {
                            Console.WriteLine(" Distance to node {0} = {1}, Path : {2}", key, node.distanceDict[key].totalDistance, string.Join(",", node.distanceDict[key].nodeNames.ToArray()));
                        }
                    }
                }
            }
        }
    }
