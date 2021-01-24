    public class Program
    {
        int result=0;
        int result2= 0;
    public void Add(int num1, int num2){
        result = num1 + num2;
        Console.WriteLine(result);
    }
    public int Add2(int num1, int num2){
        return result2 = num1 + num2;
    }
    public static void Main(string[] args)
    {
        Program program = new Program();
        program.Add(5,6);
        Console.WriteLine(program.result);
        program.Add2(4,2);
     
    }
