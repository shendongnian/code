    public TreeNode Append(TreeNode newNode)
    {
        // I have change to return this, I think you want to have fluent design
        // change to other thing if you are not
        // and this line will check if newNode is null, do nothing
		if (newNode == null) return this;
		
        if (childNodes.Contains(newNode))
            throw new Exception("the File/Folder is already in the List");
        childNodes.Add(newNode);
        return this;
    }
    public TreeNode Append(string newValue, string newValueType)
    {
        TreeNode newNode = new TreeNode(newValue, newValueType);
        return Append(newNode);
    }
    // I have add this in order to test the program, you can remove it
    public string ToString(string prefix)
    {
        string result = string.Format("{0}{1}: {2}\r\n", prefix, ValueType, Value);
        foreach (var item in childNodes)
        {
            result += item.ToString(prefix + "\t");
        }
        return result;
    }
