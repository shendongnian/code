    DataTable loDt = new DataTable();
    loDt.Columns.Add("CategoryName", typeof(string));
    loDt.Columns.Add("GroupName", typeof(string));
    loDt.Columns.Add("TestName", typeof(string));
    loDt.Columns.Add("TestNumber", typeof(string));
    loDt.Columns.Add("TestVisitCode", typeof(string));
    
    var loRow = loDt.NewRow();
    loRow["CategoryName"] = "FirstCategory";
    loRow["GroupName"] = "FirstGroup";
    loRow["TestName"] = "FirstTest";
    loRow["TestNumber"] = "12";
    loRow["TestVisitCode"] = "W1";
    loDt.Rows.Add(loRow);
    
    loRow = loDt.NewRow();
    loRow["CategoryName"] = "FirstCategory";
    loRow["GroupName"] = "FirstGroup";
    loRow["TestName"] = "FirstTest";
    loRow["TestNumber"] = "13";
    loRow["TestVisitCode"] = "W2";
    loDt.Rows.Add(loRow);
    
    ...    
