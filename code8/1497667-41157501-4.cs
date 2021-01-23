         List<object[]> returnColumnList = new List<object[]>();
    string json = string.Empty;
    var returnObject = new List<object>();
    returnColumnList.Add(new object[]  { "Depart" , "123", "345"  });
    returnColumnList.Add(new object[] { "Depart", "123", "345" });
    
    foreach (var item in returnColumnList)
    {
    
    returnObject.Add(new {name = item.GetValue(0), data = (new object[] {item.GetValue(1) , item.GetValue(2)})});
    
    }
    
    json = new JavaScriptSerializer().Serialize(returnObject);
       
