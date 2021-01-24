    class Program
    {
        static void Main(string[] args)
        {
            MethodInvokationResult result = SafeActionInvokator.HandleSafely(() =>
            {
                MyFakeBusinessEngine.DivideTwoNumbers(5, 0);
            });
            if (result.Exception is System.DivideByZeroException)
            {
                Debug.WriteLine($"A divide by zerp exception was caught");
            }
            else if (!result.Success)
            {
                Debug.WriteLine($"An unknown error occured.");
            }
        }
    }
