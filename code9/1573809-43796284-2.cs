    public string Divide(string num1, string num2)
    {
        string resultMsg = "";
    
        try
        {
            double num1Dbl = double.Parse(num1);
            double num2Dbl = double.Parse(num2);
            double result = num1Dbl / num2Dbl;
            resultMsg = result.ToString();
            return resultMsg;
        }
        catch (FormatException error)
        {
            resultMsg = "Error - Invalid Input";
            return resultMsg;
        }
    }
