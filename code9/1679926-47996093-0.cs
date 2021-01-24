    private void FillTree(TreeNode pnode,DataTable data)
        {
            DataRow[] cnodes = data.Select("catparent=" + pnode.Tag.ToString());
            foreach (DataRow crow in cnodes)
            {
                TreeNode ctn = new TreeNode(crow["catname"].ToString());
                ctn.Name = "Cat" + crow["cat_id"].ToString();
                ctn.Tag = crow["cat_id"].ToString();
                pnode.Nodes.Add(ctn);
                FillTree(ctn, data);
            }
        }
