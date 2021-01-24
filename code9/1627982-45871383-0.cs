    public static List<MenuFolder> ToTree(IEnumerable<MenuFolder> flatList, int parentId = 0)
    {
        var tree = flatList
            .Where(m => m.ParentID == parentId)
            .ToList();
            
        tree.ForEach(t => t.SubFolders = ToTree(flatList, t.FolderID));
        
        return tree;
    }
