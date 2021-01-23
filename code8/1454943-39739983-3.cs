       var excel = new ExcelQueryFactory();
                    List<ExcelData> allListData = new List<ExcelData>();
                    try
                    {
                        excel = new LinqToExcel.ExcelQueryFactory(@"C:\Users\Mhamudul Hasan\Desktop\FulllData.xlsx");
                        allListData = (from c in excel.Worksheet<ExcelData>("Sheet1")
        
                                       select c).ToList();
                    }
                    catch (Exception exception)
                    {
        
        
                        return;
                    }
    List<ExcelFullData> entities = new List<ExcelFullData>();
                using (var ctx = new testEntities())
                {
                    
                    foreach (var data in allListData)
                    {
                        ExcelFullData excel1 = new ExcelFullData
                        {
                            IMEI1 = data.IMEI1,
                            IMEI2 = data.IMEI2,
                            Color = data.COLOR
                        };
                        //entities.Add(excel1);
                        ctx.ExcelFullDatas.Add(excel1);
    
                    }
                    ctx.SaveChanges();
                }
