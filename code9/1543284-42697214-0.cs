    if(dt != null && dt.Rows.count > 0){
          foreach(DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrWhiteSpace(dr.Field<string>("col")))
                        {
                            //do something
                            dr["somecol"] = null;
                        }
                        if (dr.Field<string>("somecol") == "someValue")
                        {
                            dr["somecol"] = string.Empty;
                            //do something
                        }
                    }
    }
    else 
    {
        return null;
    }
