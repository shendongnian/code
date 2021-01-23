    var getResponse = client.Get<Graph>("graph-id");
    
    var graph = getResponse.Source;
    var node = graph.NodeList.First(n => n.Id == "node-id");  
    
    // make changes to the node
    node.Name = "new name";
    node.EdgeList.First().Cost = 9.99;
    
    var indexResponse = client.Index(graph, i => i
        // specify the version from the get request
        .Version(getResponse.Version)
    );
