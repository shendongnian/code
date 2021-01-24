    public void HandleModelObject(object modelObject)
    {
        var folder = modelObject as Folder;
        if (folder != null)
        {
            TreeNode NewNode = new TreeNode(folder.Object_string);
            return;
        }
        var document = modelObject as Document;
        if (document != null)
        {
            TreeNode NewNode = new TreeNode(document.Object_string);
            return;
        }
        var someOtherType = modelObject as SomeOtherType;
        if (someOtherType != null)
        {
            TreeNode NewNode = new TreeNode(someOtherType.Object_string);
            return;
        }
    }
