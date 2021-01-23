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
