    public class MyMappedCSVFile
    {
      public string ProfileID { get; set; } 
      public string Date { get; set; }
      
      public MyMappedCSVFile(string profile, string date)
      {
        ProfileID = profile;
        Date = date;
      }
    }
