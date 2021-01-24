    StringBuilder sb = new StringBuilder();
    
    using (var cmd = dbCon.CreateCommand()) {
            cmd.CommandText = sql;
            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    sb.Append(reader.GetInt32(0).ToString()+". " + reader.GetString(1) + "\n" + reader.GetString(2)+"\n\n");
                } 
            }
    
    if(sb.Length <= 0)
      sb.Append("the data is empty");
    
    output.text = sb.ToString();
