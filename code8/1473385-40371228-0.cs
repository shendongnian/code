    public static TreeNode GetFolderStructure(string path, List<string> allExt)
    {
        TreeNode result = new TreeNode(path, "DIR");
        foreach (string dirName in Directory.GetDirectories(path))
        {
            result.Append(GetFolderStructure(dirName, allExt));
        }
        foreach (string item in allExt)
        {
            foreach (string fileName in Directory.GetFiles(path, item))
            {
                result.Append(fileName, "FILE");
            }
        }
        if (result.ChildNodes.Count > 0) // <- check do it have any child
            return result;
        else                             // if not, return null, so it will not include in result
            return null;
    }
