        public List<Node> GetAllNodes()
        {
            var allNodes = new List<Node>();
            GetAllNodesRecursive(allNodes, Head);
            return allNodes;
        }
        private void GetAllNodesRecursive(List<Node> allNodes, Node node)
        {
            if (node == null)
            {
                return;
            }
            allNodes.Add(node);
            GetAllNodesRecursive(allNodes, node.Next);
        }
