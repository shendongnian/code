    public string CheckDetails(string param1, string param2)
    {
      var chk = new check
      {
        subject = "hello! " +param1 ,
        description = param2 +" Years Old"
      };
     return JsonConvert.SerializeObject(chk);
    }
        
    public class check
    {
      public string subject { get; set; }
      public string description { get; set; }
    }
