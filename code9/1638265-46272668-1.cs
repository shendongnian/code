    using Newtonsoft.Json;
    using System.Dynamic;
    using Newtonsoft.Json.Converters;
 
 
    public bool SendTransactio(string jsonReceiverInCsharpObjecName)
     {
       dynamic dynData =JsonConvert.DeserializeObject<ExpandoObject>
       (jsonReceiverInCsharpObjecName, new ExpandoObjectConverter());
       
    foreach (KeyValuePair<string, object> transItem in dynData 
    {
       if (transItem.Key == "transaction_time")
       var transaction_time = Convert.ToString(transItem.Value);
       else if (transItem.Key == "transaction_status")
       var transaction_status = Convert.ToString(transItem.Value);
       else if (transItem.Key == "transaction_id")
       var transaction_ido = Convert.ToString(transItem.Value);
       //else
       //do for rest attribute of your json data
     }
    
    return true;
     }
