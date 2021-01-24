     DataTable dttoexcel = some data source;
     String[] pro = { "Az", "Bz", "X" };
     List<DataRow> loginDetails = new List<DataRow>();
     for (int f = 0; f < pro.Length; f++)
     {
         loginDetails.Concat(dttoexcel //or AddRange method
             .AsEnumerable()
             .Where((r => r.Field<string>("Subcategoryname") == pro[f]))
             .ToList());
     }
