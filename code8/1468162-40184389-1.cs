    public class MainClass
    {
    public static void Main(string[] args)
    {
        String value = Console.ReadLine();
        var a = new MainClass();
        if a.IsNumeric(value){
        //your logic with numeric
        }
        else 
        {
        //your logic with string
        }
    }
    
    public Boolean IsNumeric(String value){
     try 
       var numericValue = Int64.Parse(value);
       return true;
     catch 
       return false;
    }
