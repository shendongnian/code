    public class MyTreeNode : TreeNode
    {
      public bool IsAllNodesExpanded()
      {
        if (!IsExpanded)
        {
          return false;
        }
        bool allChildsExpanded = true;
        foreach (MyTreeNode child in Nodes.OfType<MyTreeNode>())
        {
          if (!child.IsAllNodesExpanded())
          {
            allChildsExpanded = false;
            break;
          }
        }
        return allChildsExpanded;
      }
    } 
