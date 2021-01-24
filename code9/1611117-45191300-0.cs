    public class OpRoot
    {
       public string _note { get; set; }
       public int status { get; set; }
       public int time { get; set; }
       public Dictionary<string, OpItem> response { get; set; }
    }
    
    public class OpItem
    {
       public int op_7_day { get; set; }
       public int op_30_day { get; set; }
    }
