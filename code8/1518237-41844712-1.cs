    string s;                
    while (reader.Read())
    {
        if(!String.IsNullOrEmpty(s)){
            s += ", ";
        }
        s += reader["name"].ToString();
    }
