    public class AdditionResult
    {
        public int Result {get; set;}
    }
    
    public AdditionResult GET(int num1, int num2)
    {
        int sum = ClassLibraryDll.MathClass.Add(num1, num2);
        var addResult = new AdditionResult();
        addResult.Result = sum;
        return addResult;          
    }
