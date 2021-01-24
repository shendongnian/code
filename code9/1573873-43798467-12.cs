     // In general case, if ROBAID can have duplicates
     var Dictionary_roba = List_roba
       .GroupBy(item => item.ROBAID)
       .ToDictionary(chunk => chunk.Key, 
                     chunk => chunk.First());
     // If ROBAID is unique:
     //var Dictionary_roba = List_roba
     //  .ToDictionary(item => item.ROBAID, item => item); 
     ...
 
     using (FbCommand cmd = new FbCommand(sql, con)) {
       using (FbDataReader dr = cmd.ExecuteReader()) {
         while (dr.Read()) {
           if (dr.IsDBNull(0)) // <- Is it really possible for Id to be null?
             continue;
           int trenutnaRobaId = Convert.ToInt32(dr[0]);
           // C# 7.0 Syntax - out var; 
           // if you don't have C# 7.0 you have to declare "roba" variable  
           if (Dictionary_roba.TryGeValue(trenutnaRobaId, out var roba))
             roba.kolicina = roba.kolicina + Convert.ToDecimal(dr[1]);
         } 
       }
     } 
