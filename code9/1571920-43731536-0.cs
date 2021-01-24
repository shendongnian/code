    string tablename = "";
    string values = "";
    string keys = "";
    
    foreach(var kiev in dict)
       {
            string na = kiev.Key;
            if(na != "db_table_name")
            {
                    keys += kiev.Key + ", ";
                    values += "'" + kiev.Value + "', ";
            }
       }
    keys = keys.Remove(keys.Length - 2);
    values = values.Remove(values.Length - 2);
    
    string quer = "insert into " + HttpContext.Current.Session["tablename"].ToString() + " ( " + keys + " ) VALUES ( " + values + " ) ";
    
    SqlCommand cl = new SqlCommand(quer, con);
    cl.ExecuteNonQuery();
