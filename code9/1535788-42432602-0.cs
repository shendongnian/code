    public class MyGridDateTime
    {
      public string Hour{get;set;}
    
      public string Date{get;set;}
    
      public string Message{get;set;}
    }
    
    public void InitalizeGrid()
    {
       List<MyGridDateTime> list = new List<MyGridDateTime>();
       int i = 0;
       foreach (string hour in hoursCollection)
       {
          list.Add(new MyGridDateTime {Hour = hour, Date = dateCollection[i], Message = messageCollection[i]};
          i++;
       }
    
       grid.DataSource = list;
    }
