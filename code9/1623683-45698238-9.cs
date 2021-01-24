    public void HandleModelObject(object modelObject)
    {
        var value = modelObject.GetType().GetProperty("Object_string", BindingFlags.Instance).GetValue(modelObject) as string;
        TreeNode NewNode = new TreeNode(value);
    }
