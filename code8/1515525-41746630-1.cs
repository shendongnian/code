    public static class MyData
    {
         public static IEnumerable<DateTime> ValueTimes { get; set;} //(or IList or List<T> or whatever you want)     
    }
    
    public class IDoStuff
    {
      public DateTime myTime { get; set; }
      public IDoStuff(DateTime d) //constructor
      {
         if(ValueTimes.IndexOf(d) != -1) //-1 says I no findie
            myTime = d;
         else
            throw new ApplicationException("That's not a valid time, dummy");
      }
    }
