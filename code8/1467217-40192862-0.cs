    using (DataSet ds = new DataSet())
    {
         ds.ReadXml("\\Server\\ZZZZ\\Downloads\\Data.xml");
         int nTableCounts = ds.Tables.Count;
         foreach(DataTable dt in ds.Tables)
         {
              using (dt)
              {
                //Put data in SQL table.
              }
         }
    }
