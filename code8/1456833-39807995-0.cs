    public class MainClass {
    public static void Main()
    {
        try {
            Invalid();
        }
        catch (Exception ext) {
            Console.Write(ext.Message);
        }
    }
    public static void Invalid()
    {
        string message = "new string";
        object o = message;
        try
        {
            int i = (int)o;
        }
        finally
        {
            Console.WriteLine("In finally");
        }
     }
    }
