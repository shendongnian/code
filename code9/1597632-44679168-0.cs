    public static class ExtensionMethods
       {
           public static Node FromNode(this Edge edge, Graph graph){
                return graph.Nodes.FirstOrDefault(n => n.id.Equals(edge.fromNode);
           }
    
           public static Node ToNode(this Edge edge, Graph graph){
                return graph.Nodes.FirstOrDefault(n => n.id.Equals(edge.toNode);
           }
       }
