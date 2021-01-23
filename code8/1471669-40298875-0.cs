    IList<DocumentNode> contents = new List<DocumentNode>();
    int index = 0;
    LoadContents(null, ref index++, result, contents);  
    
    private void LoadContents(DocumentNode parentNode, ref int nodeId, WordContent wordContent, IList<DocumentNode> contents)
    {    
        foreach (OtheClassContent childContent in wordContent.ChildrenContent)
        {
            var node = new DocumentNodeViewModel(nodeId,
                parentNode?.NodeId,
                childContent.SortOrder,
                childContent.Depth);
    
            contents.Add(node);
            nodeId++;
            LoadContents(node, ref nodeId, childContent, contents);
        }
    }
    
    // This line wont work
    IDictionary<int, int?> myDictionary = contents.ToDictionary(a => a.Id, a => a.ParentId);
