    string column = string.Empty;
    
    switch((int.Parse(cmb.selectedValue))
    {
    case 1:
    column = "OT1"
    break;
    .
    .
    .
    case 10:
    column = "OT10"
    break;
    }
    
    string sql = @"UPDATE tucitelotazky SET " + column + " = " + "@hodnota;";   
    MySqlCommand cmd = new MySqlCommand(sql, cnn);
    cmd.Parameters.Add("@hodnota", hodnota);
    
    cmd.ExecuteNonQuery();
