    public int? CalculateSomething(int input)
    {
        try
        {
            var result1 = SomeMath(input);
            var result2 = SomeOtherMath(result1);
            return result2;
        }
        catch
        {
            return null;
        }
    }
