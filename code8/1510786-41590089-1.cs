    public static bool IsThisAsync(Action action)
    {
        return action.Method.IsDefined(typeof(AsyncStateMachineAttribute),
            false);
    }
    // This method SHOULD NOT, BUT WILL be used in this example
    public static void Execute(Action action)
    {
        try
        {
            if (IsThisAsync(action))
            {
                Console.WriteLine("Is async");
                throw new ArgumentException("Action cannot be async.", nameof(action));
            }
            else
            {
                Console.WriteLine("Is not async");
            }
            action();
        }
        catch (MySpecialException)
        {
            
        }
    }
           
