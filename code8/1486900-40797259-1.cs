    private void button_Click(object sender, EventArgs e)
    {
          treeView2.Nodes.Clear();
          SqlCommand cmd = new SqlCommand("select * from BOMDETAIL ORDER BY partId", cn);
          try
          {
              SqlDataReader dr = cmd.ExecuteReader();
              SomeFun(dr, treeView2);
          }
    
         catch (Exception ex)
         {
              MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }    
    }
    private void SomeFun(SqlDataReader dr, TreeView treeView2)
    {
        if(dr.Read())
        {
           TreeNode node = new TreeNode(dr["bomItem"].ToString());
           node.Nodes(dr["partId"].ToString();
           node.Nodes.Add(dr["bomRev"].ToString());
           treeView2.Nodes.Add(node);
           SomeFun(dr, treeView2);
        }
    }
