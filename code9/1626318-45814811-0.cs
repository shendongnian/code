        private List<NodeEntity> GetDeadNodes(List<NodeEntity> originalList)
        {
            var rest = originalList.ToList();
            // Remove simple nodes and their ascendants.
            // The rest will be dead nodes.
            var simpleNodes = originalList.Where(n => n.Type == NodeType.Simple);
            foreach (var simpleNode in simpleNodes)
            {
                rest.Remove(simpleNode);
                RemoveAscendants(rest, simpleNode);
            }
            return rest;
        }
        private void RemoveAscendants(List<NodeEntity> rest, NodeEntity node)
        {
            var parent = rest.SingleOrDefault(n => n.Code == node.ParentCode);
            // We have reached the root node.
            if (parent == null)
            {
                return;
            }
            rest.Remove(parent);
            RemoveAscendants(rest, parent);
        }
