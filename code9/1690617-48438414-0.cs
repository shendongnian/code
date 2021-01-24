    private void populateTreeview(DataTable dt)
        {
            var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("Type"));
            foreach (var group in groups)
            {
                UltraTreeNode node = utObjects.Nodes.Add(group.Key);
                foreach (string name in group.Select(x => x.Field<string>("Name")))
                {
                    // Generates a unique key for each node.
                    node.Nodes.Add(Guid.NewGuid().ToString(), name); 
                }
            }
        }
