    protected void Page_Load(object sender, EventArgs e)
        {
    
    
            if (!IsPostBack) {
                check_box();
            }
        }
    
        public void check_box() {
    
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Roll_NO");
            dt.Columns.Add("Gender");
            dt.Rows.Add();
            dt.Rows[0][0]="Prateek Ghosh";
            dt.Rows[0][1] = 123;
            dt.Rows[0][2] = "Male";
            dt.Rows.Add();
            dt.Rows[1][0] = "Rahul";
            dt.Rows[1][1] = 1234;
            dt.Rows[1][2] = "Male";
            dt.Rows.Add();
            dt.Rows[2][0] = "Neha";
            dt.Rows[2][1] = 12345;
            dt.Rows[2][2] = "Female";
    
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
