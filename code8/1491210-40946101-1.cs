    OracleCommand cmd = new OracleCommand();
    cmd.Connection = conOra;
    cmd.CommandText = "SELECT * FROM TABLE(MQ_CRM.CC_NEW.getClients(:p_Organization_Name, :p_Director_Last_Name)) ";
    cmd.CommandType = CommandType.Text; 
    cmd.Parameters.Add(new OracleParameter("p_Organization_Name", OracleDbType.Varchar2, "мяскин", ParameterDirection.Input));
    cmd.Parameters.Add(new OracleParameter("p_Director_Last_Name", OracleDbType.Varchar2,"", ParameterDirection.Input));
    OracleDataReader dr = cmd.ExecuteReader();
