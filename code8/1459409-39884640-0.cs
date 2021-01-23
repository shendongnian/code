    public class myModel
    { 
       public string Item1 {get;set;}
       public string Item2 {get;set;}
       public string Item3 {get;set;}
       public override string ToString()
       {
           return string.Join(" ", this.Item1, this.Item2, this.Item3);
       }
    }
