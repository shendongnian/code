      var first = new TimeSpan(0, 20, 45);// 20mins 45secs 
      var second = new TimeSpan(1, 30, 15);   // 2nd time slot is 1hr30mins15secs
      var result = first + second;
      Debug.WriteLine(result.ToString());
 
     public String toReadableString(TimeSpan ts)
     {
        // TODO: Write your function that receives a TimeSpan and generates the desired output string formatted...
     }
