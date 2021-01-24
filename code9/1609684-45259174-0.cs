    //Convert image to binary
    string imgpathC2 = txtH_C2.Text;
    FileStream fsC2;
    fsC2 = new FileStream(@imgpathC2, FileMode.Open, FileAccess.Read);
    byte[] picbyteC2 = new byte[fsC2.Length];
    fsC2.Read(picbyteC2, 0, System.Convert.ToInt32(fsC2.Length));
    fsC2.Close();
    
    //Add binary value to SQL parameter
    SqlParameter picparaC2 = new SqlParameter();
    picparaC2.SqlDbType = SqlDbType.Image;
    picparaC2.ParameterName = "picC2";
    picparaC2.Value = picbyteC2;
    
    //use parameter in command
    cmd.Parameters.Add(picparaC2);
