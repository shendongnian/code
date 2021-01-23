    public static DataTable MergeTwoDataTables(DataTable dt1, DataTable dt2)
            {
                
     var collection = from t1 in dt1.AsEnumerable()
     join t2 in dt2.AsEnumerable() on ToNumericOnly(t1["ZIPCODE"].ToString().Trim().Substring(0,5))equals t2["Zip"] into DataGroup
     from item in DataGroup.DefaultIfEmpty()                            
      select new
       {
          CUSTOMER = ToNumericOnly(t1["CUSTOMER"].ToString()),
          ADDRESS=t1["ADDRESS"],
          ZIPCODE = t1["ZIPCODE"].ToString().Trim(),
          LAT= item == null ? string.Empty : item["lat"],
          LONG= item == null ? string.Empty : item["long"]
           };
     DataTable result = new DataTable("CustomerInfo");
       result.Columns.Add("CUSTOMER", typeof(string));
       result.Columns.Add("ADDRESS", typeof(string));         
       result.Columns.Add("ZIPCODE", typeof(string));
       result.Columns.Add("LAT", typeof(string));
       result.Columns.Add("LONG", typeof(string));
     
    foreach (var item in collection)
       {
        result.Rows.Add(item.CUSTOMER,item.ADDRESS,item.ZIPCODE,
    item.LAT,item.LONG);
     Console.WriteLine("{0}", item);
      //Console.ReadLine();
                }
                return result;
            }
