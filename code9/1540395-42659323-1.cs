     private void EstablishPath(List<Node> closedNodes, Node nodeStart, Node nodeDestination)
        {
            PathOfNodes = new List<Node>(); // Stores the path for the entity to follow to its target.
            // Start at the end of the path.
            Node nodeToAdd = closedNodes[closedNodes.Count - 1];
            while (!PathOfNodes.Contains(nodeStart))
            { // Add each node's parent until the start is reached.
                PathOfNodes.Add(nodeToAdd);
                nodeToAdd = nodeToAdd.Parent;
            }
            PathOfNodes.Remove(null); // Remove the final null node (as the final node had no parent).
        }
