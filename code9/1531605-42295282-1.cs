     private void ApplyRulesetColors()
     {
        foreach (var rule in dictOverwriteEntries)
        {
            TreeNode resultNode = SearchTreeView(rule.Key, tvDirectoryStructure.Nodes);
            if (resultNode != null)
            {
                switch (rule.Value)
                {
                    case Operations.Overwrite:
                        resultNode.BackColor = Color.Red;
                        break;
                    case Operations.Delete:
                        break;
                    case Operations.None:
                        break;
                    default:
                        break;
                }
            }
       }
    }
