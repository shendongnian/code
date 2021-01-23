     public List<TreeNode> FillRecursive(List<T> eqpList)
        {
            
            List<TreeNode> list = new List<TreeNode>();
            //First Item in the list is our RootNode
            var FirstEqp = eqpList.FirstOrDefault();
            TreeNode RootNode = new TreeNode();
            RootNode.text = FirstEqp.Parent;
            RootNode.items.Add(new TreeNode() { text = FirstEqp.child });
            foreach (EquipmentHierarchySPList eqp in eqpList)
            {
                GetTreeStructureFromList(eqp, list, RootNode);
            }
            return list;
        }
        public void GetTreeStructureFromList(T eqp, List<TreeNode> list,TreeNode RootNode)
        {
            bool found = false;
            TreeNode FoundNode =  GetTreeNode((list.Count != 0 ? RootNode : null), eqp.Parent, out found);
            if (!FoundNode.IsNullValue())
                FoundNode.items.Add(new TreeNode() { text = eqp.child });
            else //this will execute only once.
                list.Add(RootNode);
        }
        public TreeNode GetTreeNode(TreeNode RootNode, string findText,out bool found)
        {
            //if RootNode is Null , just return;
            if (RootNode.IsNullValue())
            {
                found = false;
                return null;
            }
            if (RootNode.text.Equals(findText))
            {
                found = true;
                return RootNode;
            }
            for (int j = 0; ; j++)
            {
                if (j >= RootNode.items.Count)
                {
                    found = false;
                    return RootNode;
                }
                  
                var final = GetTreeNode(RootNode.items[j], findText,out found);
                if (found == true)
                    return final;
                if (final.IsNullValue())
                    return RootNode;
                
            }
            
        }
    }
    public class TreeNode
    {
        public TreeNode()
        {
            items = new List<TreeNode>();
        }
        public string text { get; set; }
        public List<TreeNode> items { get; set; }
            public bool TreeCompare(string findText)
            {
                return Convert.ToBoolean(text.CompareTo(findText));
            }
           
    }
