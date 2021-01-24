       public class Node {
            private static List<Node> nodes = new List<Node>();
            private List<Node> inputs { get; set;}
            private List<Node> outputs {get;set;}
            protected Node() { }
            protected Node(Node input, Node outPut) {
                Node newNode = new Node();
                nodes.Add(newNode);
                newNode.inputs.Add(input);
                newNode.outputs.Add(output);
             }
        }
