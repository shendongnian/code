    protected void Page_Load(object sender, EventArgs e)
    {
    
       Session["page"] = "Employee";
        if (!IsPostBack)
        {
          BindData();
        
          DataTable dt = add.retrive("select * from statemst");
        
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            
                  ListItem item = new ListItem();
                  item.Text = dt.Rows[i]["statedesc"].ToString();
                  item.Value = dt.Rows[i]["statecode"].ToString();
                  ddl_state.Items.Add(item);
           } 
        }
    
    }
