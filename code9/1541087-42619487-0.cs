    protected void Page_Load(object sender, EventArgs e)
    {
      if (salesPerson)
      {
        TreeNodeCollection nodes = TreeView1.Nodes;
        foreach (TreeNode item in nodes)//TESTING SDN BHD
        {
         foreach (TreeNode item2 in item.ChildNodes)//ABC
         {
           for (int i = 0; i < item2.ChildNodes.Count; i++)
           {
             item2.ChildNodes[i].Text = "";//TOWERs to empty string, it's hiding the node
           }
           item2.Collapse();//It will Collapse the paretn node to hide space of child nodes
         }
       }
     }
