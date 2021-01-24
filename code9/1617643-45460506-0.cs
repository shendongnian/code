    /// <summary>
    /// Creates a JObject from the tree node
    /// </summary>
    /// <param name="treeModel">The node to serialize</param>
    /// <param name="context">All items</param>
    /// <returns></returns>
    public static JObject CreateJObject(TreeModel treeModel,IList<TreeModel> context) 
    {
        JObject result = JObject.FromObject(treeModel);
        //This is not really needed but will cut the size of array for next iterations
        context.Remove(treeModel);
        //Used stream for the primary key.
        result["children"] = GetChildren(treeModel.StreamName, context);
        return result;
    }
    /// <summary>
    /// Gets the children of the parent from context object
    /// </summary>
    /// <param name="id">id of the node</param>
    /// <param name="context">All the nodes to read the children from</param>
    /// <returns></returns>
    public static JArray GetChildren(string id, IList<TreeModel> context) 
    {
        //I used Parent for the forign key for the 
        return new JArray(context.Where(c => c.Parent == id).ToArray().Select(c => CreateJObject(c, context)));
    } 
