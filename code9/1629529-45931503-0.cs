        DataTable dttoexcel=some data source;
        String[] pro = { "Az","Bz","X" };
        List<dynamic> LoginDetails = new List<dynamic>();
        for (int f = 0; f < pro.Length; f++)
        {
             LoginDetails.AddRange(dttoexcel.Rows
                         .Cast<DataRow>()
                         .Where((r => r.Field<string>("Subcategoryname") == 
              pro[f])).ToList());
        }
