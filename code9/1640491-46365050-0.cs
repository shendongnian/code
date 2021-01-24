    public class Program
    {
     public static void Main(string[] args)
    {
    string input = "You have 6 uncategorized contacts from <an id='316268655'>SAP SE</an>";   
              
    var parts = Regex.Split(input, @"(<an[\s\S]+?<\/an>)").Where(l => l != string.Empty).ToArray();  
    string part="";
     foreach(var a in parts)
    {
      part =a;
          if(a.Contains("<an")){
          part = Regex.Replace(a, @"(?i)<(an)(?:\s+(?:""[^""]*""|'[^']*'|[^""'>])*)?>", "<$1>");
         
           }
            Console.WriteLine(part);
       }
       Console.ReadLine();
    }
    } 
 
