       SqlCeDataAdapter da = new SqlCeDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            
            da.SelectCommand = new SqlCommand(@"SELECT Fullname, Age,Lastname, Feeling,OtherProperties FROM User", connString);
            da.Fill(ds, "User");
            dt = ds.Tables["User"];
        
            var resultText = "Hello, ";
            var textDic = new Dictionary<string,string>(){
               {"Fullname","And My name is {0}"},
               {"Age","And My age is {0}"},
               {"LastName","And my name is {0}"},
               {"Felling","And I am  {0}"}, 
               {"OtherProperties","And whatever  {0}"}, 
             };
           
             foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    ColumnName = column.ColumnName;
                    ColumnData = row[column].ToString();
                    if(textDic.ContainsKey(ColumnName))
                    {
                        resultText+= string.Format(textDic[ColumnName],ColumnData)
                    }
                }
            }
    
    // your final result is this resultText
