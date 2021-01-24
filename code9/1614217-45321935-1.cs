    protected void Page_Load(object sender, EventArgs e)
        {     
          if(!IsPostBack) //Do stuff only during page first load.
          {
           //Check if session is null. 
           string userId = Session["UserID"]==null? String.Empty : Session["UserID"].ToString(); 
           txtEmployeeNo.Text = userId;
           if(!String.IsNullOrEmpty(userId))
           {
              DataRow dr = FillFields(userId);
              txtEmployeeNo.Text = User_ID;
              txtFirstName.Text = dr["FirstName"].ToString(); 
              txtLastName.Text =  dr["LastName"].ToString();
           }
          }
        }
    private DataRow FillFields(string User_ID)
        {
            //This way of execuring sql query is highly discourage. 
            //You should use parametrized sql command or use store procedure.
            String commandString = @"SELECT * FROM [dbo].[Tbl_Employee] WHERE 
            [UserID] = '"+ User_ID + "'"; 
            DataRow dr = Global.StartQuery(commandString).Rows[0]; -- > global class
            return dr;
        }
