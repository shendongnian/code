    //DbHelper class
    public static string AppConnectionString(){
       if(Session["cnn"] != null)
         return ConfigurationManager.ConnectionStrings["Second"].ConnectioonString;
       return ConfigurationManager.ConnectionStrings["Default"].ConnectioonString;
    }
    //button handler
    protected void LinkSwitchApp_Click(object sender, EventArgs e)
     {
       if(Session["cnn"] != null)
         Session.Remove("cnn");
       else
         Session["cnn"] = true; //or whatever
     }
    //any time you connect to DB
    var conn = new SqlClient.SqlConnection(DbHelper.AppConnectionString());
