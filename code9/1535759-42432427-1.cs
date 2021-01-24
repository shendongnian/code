    public class MyJsonObject
    {
       public List<Table> Tables{get;set;}
    }
    
    public class Table
    {
       public int Id {get;set;}
    
       public string Item {get;set;}
    }
    
    private void Convert()
    {
       string json = @"{
        'Table1': [
          {
            'id': 0,
            'item': 'item 0'
          },
          {
            'id': 1,
            'item': 'item 1'
          }
       ]
      }";
    
      MyJsonObject obj = JsonConvert.DeserializeObject<MyJsonObject>(json);
      Console.WriteLine(obj.Tables[0].Item);
    }
