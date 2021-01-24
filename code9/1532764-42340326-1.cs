    var listWithDeserializedProperty = customers.Select(c => 
    {
        dynamic cust = new System.Dynamic.ExpandoObject();
        cust.CustomerId = c.CustomerId;
        cust.CustName = c.CustName;
        cust.CustJson = JsonConvert.DeserializeObject(c.CustJson);
        return cust;
    });
    return JsonConvert.SerializeObject(listWithDeserializedProperty);
