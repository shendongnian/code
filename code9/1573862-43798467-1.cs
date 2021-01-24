     //FIRST SLOW QUERY (Hope, much faster now)
 
     //DONE: Keep SQL readable
     string sql = 
        @"SELECT ROBAID, 
                 SUM(KOLICINA) 
            FROM STAVKA 
           WHERE MAGACINID = 12 AND
                 VRDOK IN (16, 18, 22)
        GROUP BY ROBAID";
     using (FbCommand cmd = new FbCommand(sql, con)) {
       using (FbDataReader dr = cmd.ExecuteReader()) {
         while (dr.Read()) {
           if (dr.IsDBNull(0)) // <- Is it really possible for Id to be null?
             continue;
           int trenutnaRobaId = Convert.ToInt32(dr[0]);
           //TODO: you may want to turn List_roba into Dictionary_roba 
           var roba = List_roba
             .Where(r => r.ROBAID == trenutnaRobaId)
             .FirstOrDefault();
           if (roba != null)  
             roba.kolicina = roba.kolicina + Convert.ToDecimal(dr[1]);
         } 
       }
     }
