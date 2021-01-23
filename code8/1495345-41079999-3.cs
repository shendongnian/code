    TreeListNode FindTreeNode(TreeListNode node, Enumerations.ItemType type, Nullable<long> id)
    {
        foreach (var c in node.Nodes) 
        {
            if ((Enumerations.ItemType)c[2] == type &&
               (id == null || (long)c[0] == id.Value)) {
                return c;
            }
            if (c.HasChildren) 
            {
                // Here is the secret sauce
                // This is recursion
                var exists = FindTreeNode(c, type, id);
                if (exists != null) { return exists; }
            }
        }
        return null;
    }
