    void Main()
    {
      var bus = new Bus();
      var data = new string[6] { "A", "B", "C", "D", "E", "F" };
      
      for (var i = 1; i <= 6; i++)
      {
        bus.GetType().GetProperty("Val" + i.ToString()).SetValue(bus, data[i - 1]);
      }
      
      Console.WriteLine(bus.Val5); // E
    }
    
    public class Bus 
    {
      public string Val1 {get;set;}
      public string Val2 {get;set;}
      public string Val3 {get;set;}
      public string Val4 {get;set;}
      public string Val5 {get;set;}
      public string Val6 {get;set;}
    }
