    using System;
    using System.Collections.Generic;
    
    class MainClass {
      
      public class Time
      {
         public DateTime From { get; set; }
         public DateTime To { get; set; }
         public string Src { get; private set; }
         
         public Time(){
           Src = "DB";
         }
         
         public Time Gap(DateTime prev) {
           if(prev >= this.From) return null;
           return new Time {From = prev, To = this.From, Src="GAP"};
         }
         
         public static Time Gap(DateTime from, DateTime to){
           if(from >= to) return null;
           return new Time {From = from, To = to, Src="GAP"};
         }
         
         override public string ToString(){
           return $"Time: {Src}\n\t{From}\n\t{To}";
         }
      }
      
      
      
      public static void Main (string[] args) {
        var times = new List<Time>();
        times.Add(new Time {From = DateTime.Parse("1/1/2017 12:00 PM"), To=DateTime.Parse("1/1/2017 13:00 PM")});
        times.Add(new Time {From = DateTime.Parse("1/1/2017 13:00 PM"), To=DateTime.Parse("1/1/2017 16:00 PM")});
        times.Add(new Time {From = DateTime.Parse("1/1/2017 20:00 PM"), To=DateTime.Parse("1/1/2017 22:00 PM")});
        
        // Begin
        
        times.Sort((a, b) => a.From.CompareTo(b.From));
        
        var prev = DateTime.Parse("1/1/2017 00:00 AM");
        var last = prev.AddDays(1).AddMilliseconds(-1);
        Time gap;
        
        foreach(var time in times.ToArray()) {
          gap = time.Gap(prev);
          if(gap != null) {
            times.Add(gap);
          }
          prev = time.To;
        }
        
        gap = Time.Gap(prev, last);
        if(gap != null) {
          times.Add(gap);
        }
    
        foreach(var time in times){
          Console.WriteLine (time);
        }
    
      }
    }
