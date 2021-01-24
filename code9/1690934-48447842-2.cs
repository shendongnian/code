    var query= dt.AsEnumerable().GroupBy(row => new
                                 {
                                    Name = row.Field<string>("NAME"),
                                    Id = row.Field<int>("ID")
                                 })
                                .SelectMany(grp=>
                                 { 
                                    var sum=grp.Sum(r => r.Field<decimal>("AMOUNT");
                                    if(sum!=0)
                                    {
                                       DataRow dr = dt.NewRow();
                                       dr["AMOUNT"] = sum;
                                       dr["NAME"] = grp.Key.Name;
                                       dr["ID"] = grp.Key.Id;
                                       return dr;
                                    }
                                    else
                                    {
                                      return grp;
                                    }
                                 }).CopyToDataTable();  
         
