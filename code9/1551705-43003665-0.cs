    [Serializable]
    public class RequestOne()
    {
      public string date { get; set; };
      public string information { get; set; };
      public string subject { get; set; };
      public RequestOne()
      {
        Date = DEFAULT_DATE;
        Information = DEFAULT_DATE;
        Subject = DEFAULT_SUBJECT;
      }
    }
    [Serializable]
    public class RequestTwo()
    {
      public int ID { get; set; };
      public string Data { get; set; };
      public string Message { get; set; };
      public RequestTwo()
      {
        Data = DEFAULT_DATA;
        message = DEFAULT_MESSAGE;
      }
    }
