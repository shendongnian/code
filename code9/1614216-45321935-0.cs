    protected void imgBtnView_Click(object sender, ImageClickEventArgs e)
    {
       ImageButton imgBtn = (ImageButton)sender;
       //string UserID = imgBtn.CommandArgument; //just ignored intermediate value holder
       Session["UserID"] = imgBtn.CommandArgument;
       Response.Redirect("Employee.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {     
      if(!IsPostBack) //Do stuff only during page first load.
      {
       //Check if session is null. 
       string userId = Session["UserID"]==null? String.Empty : Session["UserID"].ToString(); 
       txtEmployeeNo.Text = userId;
       if(!String.IsNullOrEmpty(userId))
       {
          FillFields(userId);
       }
      }
    }
    
    //This method should return datatable or DataRow and avoid setting control value. 
    //Returing datatable or DataRow makes this method more reusable.
    private void FillFields(string User_ID)
    {
        //This way of execuring sql query is highly discourage. 
        //You should use parametrized sql command or use store procedure.
        String commandString = @"SELECT * FROM [dbo].[Tbl_Employee] WHERE 
        [UserID] = '"+ User_ID + "'"; 
        DataRow dr = Global.StartQuery(commandString).Rows[0]; -- > global class
        txtEmployeeNo.Text = User_ID;
        txtFirstName.Text = dr["FirstName"].ToString(); 
        txtLastName.Text =  dr["LastName"].ToString();
    }
