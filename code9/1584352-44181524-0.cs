    private void CreateNode(List<CategoryNode> nodes, CategoriesList parent)
    {
        foreach (var node in nodes)
        {
            if (node.Id == parent.Id)
            {
                node.Children.Add(new CategoryNode { Id = parent.Id, Name = parent.Name });
            }
            else
            {
                CreateNode(node.Children, parent);
            }
        }
    }
