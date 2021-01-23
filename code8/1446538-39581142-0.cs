     epiDataView edvPP =((EpiDataView)(oTrans.EpiDataViews["DataView From Grid"]));
          int Count = 0;
          int i = 0;
          using (System.IO.StreamWriter sw = new      System.IO.StreamWriter(@"C:'Location'\Test.txt"))
 
    {
         foreach(DataRow dr in edvPP.dataView.Table.Rows)
          {
            object[] ay = dr.ItemArray;
            for (i=0; i < Count - 1; i++)
               {
                 sw.Write(ay[i].ToString() + "");
               }
             sw.WriteLine(ay[i].ToString());
           }
        }
 
