    [Serializable]
    public class RequestOne()
     {
       private string _date;
       public string date { get { return _date;} set { _date = value ?? DEFAULT_DATE; }};
       public string information; // same here
       public string subject; //same here
     }
