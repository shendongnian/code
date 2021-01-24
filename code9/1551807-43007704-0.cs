    public class PortNames
    {
      public string value{get;set;}
      public int key {get;set;}
    }
    ctor()
    {
      cbxPorts.ItemsSource = new List<PortNames>();
    }
