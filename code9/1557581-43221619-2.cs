    protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Adding data to datatable
                DataRow t = tablaPed.NewRow();
    
                //adding data to row
                t["SrNo"] = "1";
                t["EmailId"] = "test@gmail.com";
                t["Password"] = "Password";
    
                //adding row to table
                tablaPed.Rows.Add(t);
                //saving databale into viewstate   
                ViewState["UserDetail"] = t;
                //bind Gridview  
                GridView1.DataSource = t;
                GridView1.DataBind(); 
            }
        }
