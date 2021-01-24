    public void DoCalculation (Parameter param)
    {
       for (int i = param.Min; i <= param.Max; i++)
       {
          param.Value = i;
          //Do Calculation necessary
       }
    }
