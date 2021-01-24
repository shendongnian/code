    var myData = {[
      {
        "timex": "XXXX-08-25",
        "type": "date",
        "value": "2016-08-25"
      },
      {
        "timex": "XXXX-08-25",
        "type": "date",
        "value": "2017-08-25"
      }
    ]}
    
    List<MyDataList> _myDataList = new List<MyDataList>();
    
    foreach(var item in myData)
    {
        MyDataList _myDataListObject = new MyDataList();
        
        Dictionary<string, object> desirializedJsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ToString());
    
        myDataListObject.timex = Convert.ToString(desirializedJsonObject["timex"]);
        myDataListObject.type= Convert.ToString(desirializedJsonObject["type"]);
        myDataListObject.value = Convert.ToString(desirializedJsonObject["value"]);
    
        myDataList.Add(myDataListObject);
    }
    
    //Get first records data
    MyDataList _myData = myDataList.FirstOrDefault();
    
    //Your class to get data
    public class MyDataList
    {
        public string timex {get; set;}
        public string type {get; set;}
        public string value {get; set;}
    }
