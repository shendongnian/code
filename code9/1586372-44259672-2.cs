    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    txt.Attributes.Add("onkeyup", "javascript:setTimeout('__doPostBack(\'txt\',\'\')', 0)");
                    GridView1.DataSource = GetDataSource();
                    GridView1.DataBind();
                }
            }
            private DataTable GetDataSource()
            {
                var dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("regon", typeof(string));
                dt.Columns.Add("nip", typeof(string));
                dt.Rows.Add("Name-1", "regon-1", "nip-1");
                dt.Rows.Add("Name-2", "regon-1", "nip-1");
                dt.Rows.Add("Name-3", "regon-1", "nip-1");
                dt.Rows.Add("Name-4", "regon-1", "nip-1");
                dt.Rows.Add("Name-5", "regon-1", "nip-1");
                dt.Rows.Add("Name-6", "regon-1", "nip-1");
                dt.Rows.Add("Name-7", "regon-1", "nip-1");
                return dt;
            }
            protected void txt_TextChanged(object sender, EventArgs e)
            {
                if (txt.Text != "")
                {
                    GridView1.DataSource = GetDataSource();
                    GridView1.DataBind();
                }
            }
