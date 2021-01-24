    string MyConnection = "server=localhost; port=3306; databae=database_name; uid=root;pwd=;sslMode=None; ;
    string Query =  "INSERT INTO table_name(username,password)VALUES('"+textbox_name.Text+"','"+password_name.Password+"');
    MySqlConnection con = new MySqlConnection(MyConnection);
    MySqlCommand command = new MySqlCommand(Query,con);
    con.open();
    try{
    command.ExcuteNonQuery();
}
        catch(Expection ex)
