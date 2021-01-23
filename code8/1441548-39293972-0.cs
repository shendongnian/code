     DataSet ds = new DataSet();
     TreeNode parentNode = null;
     TreeView treeview = null;
     public OrgHierarchy()
     {
        InitializeComponent();
        DataSet ds = RunQuery("select orgid ,parentid .... and parentid is null");
        DataTable dt = ds.Tables[0];
        settingRootLevel(dt);
        if (treeview.Nodes.Count > 0)
        {
                for (int i = 0; i < treeview.Nodes.Count; i++)
                {
                    TreeNode node = treeview.Nodes[i];
                    addChildNodes(dt, node);
                }
        }
            this.Controls.Add(treeview);
     }
    DataSet RunQuery(String Query)
    {
        DataSet ds = new DataSet();
        OracleConnection con = new OracleConnection(OrgScheme.GetConnectionString());
        DataTable dt = new DataTable();
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = Query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
        public void addChildNodes(DataTable dt,TreeNode Node)
        {
            DataRow[] datarows = dt.Select("PARENTID = " + Node.Text);
            for (int i = 0; i < datarows.Length; i++)
            {
                    TreeNode node = new TreeNode(datarows[i][0].ToString());
                    Node.Nodes.Add(node);
                    addChildNodes(dt, node);    
            }
        }
        public void settingRootLevel(DataTable dt)
        {
            DataRow[] datarows = dt.Select("PARENTID is null");
            foreach (DataRow dr in datarows)
            {
                treeview.Nodes.Add(dr[0].ToString());
            }
            
        }
