    public void FuncOutParamString(StringBuilder sbValue)
    {
        sbValue.Append("wold!");
        return sbValue;
    }
    
    private void btnOutParam_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("=================== Out Parameter ===================");
        // Declare a variable but don't assign a value to it ******************************
        int y = 0;
    
        // Pass it in as an output parameter, even though its value is unassigned
        FuncOutParamInt(out y);
    
        // It's now assigned a value, so we can write it out:
        Console.WriteLine(y);
    
        // Declare a variable but don't assign a value to it ******************************
        StringBuilder sb = new StringBuilder(50);
        sb.Append("Hello ");
        sb = FuncOutParamString(sb);
    
        Console.WriteLine(sb);
    }
