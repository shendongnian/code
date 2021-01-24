    dynamic cust= new System.Dynamic.ExpandoObject();
    cust.CustomerId = x.CustomerId;
    cust.CustName = x.CustName;
    cust.CustJson = JsonConvert.DeserializeObject(x.CustJson);
    //Result containing only pure json
    var jsonResult = JsonConvert.SerializeObject(cust);
