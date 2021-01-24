    static void Main(string[] args)
    {
         var utcNow = DateTime.UtcNow;
         TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
         var pstNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, pstZone);
     
         DateTime targetPstTime = pstNow.Date.AddDays(1).AddHours(5);
         
         DateTime utcAnswer = TimeZoneInfo.ConvertTimeToUtc(targetPstTime, pstZone);
     
         Console.WriteLine(utcAnswer);
         Console.ReadKey();
     
     }
