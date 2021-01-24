    class Node
    {
        public int Data { get; set; }
        // omitting other Node details here
    }
    class ObjFlag
    {
        public Node Node { get; set; }
        public bool Found { get; set; }
    }
    class Tree
    {
        public ObjFlag FindNodeWithValue(int valueToFind)
        {
            var objFlag = new ObjFlag() { Found = false, Node = null };
            DepthTraverse(node =>
            {
                if (node.Data == valueToFind)
                {
                    objFlag.Node = node;
                    objFlag.Found = true;
                }                
            });
            return objFlag;
        }
        public void DepthTraverse(Action<Node> action)
        {
            Node nodeToInspect = null;
            // some logic to get the node to inspect
            if (action != null)
                action(nodeToInspect);
        }
    }
