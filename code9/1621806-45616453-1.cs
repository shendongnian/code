    for (int f = 0; f < total.Count(); f++)
    {
         for (int k = 0; k < tableNames.Count; k++)
         {
               myCommand3.Parameters["@" + tableNames[k]].Value = total[f][k];
         }
         myCommand3.ExecuteNonQuery();
    }
    myCommand3.Parameters.Clear();
