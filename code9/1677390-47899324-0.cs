    public class Node
    {
       // examples
       public string Id {get;set;}
       public Node Parent {get;set;}
       public Node Child {get;set;}
       public Node Sibling {get;set;}
    }
    
    var nodes = new Dictionary<string,Node>();
    
    // add like this
    nodes.Add(node.Id,node);
    
    // look up like this    
    node = nodes[key];
    
    // access its relatives 
    node.Parent
    node.Child
    Node.Sibling 
