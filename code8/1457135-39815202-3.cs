    public Node GetTree(string filePath)
    {
        string[] lines = System.IO.File.ReadAllLines(filePath);
        //if lines is empty the tree is null
        if(lines.Length == 0)
        {
            return null;
        }
        //create the root
        Node root = new Node(lines[0].Trim());
        
        //get the root leading white spaces length
        int rootWhiteSpaceLength = lines[0].TakeWhile(c => c=" ").Count();
       
        //Crete  a list to hold the nodes and their white space length
        List<Tuple<Node, int>> nodesAndLengths = new  List<Tuple<Node, int>>();
        //add the root to nodes list with it's white space length
        nodesAndLengths.Add(new Tuple<Node, int>(root, rootWhiteSpaceLength));       
        //iterate over the lines strating from index 1
        for (var i = 1; i < lines.Length, i++)
        {
            //create the node
            Node node = new Node(lines[i].Trim());
            //get the node leading white spaces length
            int nodeWhiteSpaceLength = lines[i].TakeWhile(c => c=" ").Count();
           
            //Check that is not another root
            if(nodeWhiteSpaceLength <= rootWhiteSpaceLength)
            {
                throw new Exception("There is more than one root");
            }
            //find the node parent in the nodes list using LINQ
            Node parent = nodesAndLengths.Last(nodeAndLength => nodeAndLength.Item2 < nodeWhiteSpaceLength).Item1;
            
            //Alternatively using while loop
            //int j = i - 1;
            //while(nodeWhiteSpaceLength >= nodesAndLengths[j].Item2)
            //{
                //j--;
            //}
            //Node parent=nodesAndLengths[j].Item1;
            
            //add the node to it's parent
            parent.Children.Add(node);
            //add the node to nodes list with it's white space length
            nodesAndLengths.Add(New Tuple<Node, int>(node, nodeWhiteSpaceLength));
        }
        return root; 
    }
    
    
