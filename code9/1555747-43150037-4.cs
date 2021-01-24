    //first create your SQL-Statement
    String statement = "SELECT MY_CUSTOM_TYPE_COLUMN FROM MY_SUPER_TABLE";
    
    //then set up the database connection
    OracleConnection conn = new OracleConnection("connect string");
    conn.Open();
    OracleCommand cmd = new OracleCommand(statement, conn);
    cmd.CommandType = CommandType.Text;
    //execute the thing
    OracleDataReader reader = cmd.ExecuteReader();
    //get the results
    while(reader.Read()){
        MyCustomClass customObject = new MyCustomClass();
        //get the Object, here the magic happens
        customObject = (MyCustomClass)reader.GetValue(0);
        //do something with your object
    }
