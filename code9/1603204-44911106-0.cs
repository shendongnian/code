    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        
        string postid = e.CommandArgument.ToString();
        string emailcc = Session["EMAIL"].ToString();
        string user_id = Session["ID"].ToString();
        string usrnom = Session["NOMBRE"].ToString();
        string usrfoto = Session["FOTO_URL"].ToString();
        
        var COMM_fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    
