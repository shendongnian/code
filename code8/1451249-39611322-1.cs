    public abstract class TransportationInfo
    {
      public string TableName { get; protected set; }
      public string PKName { get; protected set; }
      public abstract void DoSomething();
    }
    public class Bicycle : TransportationInfo
    {
      public Bicycle()
      { 
        TableName = "bicycle_table";
        PKName = "aaa";
      }
      public override void DoSomething()
      {
    		// use TableName dosomething...
    		// use PKName dosomething...
    	}
    }
