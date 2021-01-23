    StringBuilder output = new StringBuilder();
    double variableOne = 8.1;
    double variableTwo = 14.9;
    
    double start = 0;
    double end = 0;
    
    bool isShowingInitialVariable = true;
             
    
    //if (double.TryParse(variableOneText.Text, out variableOne))
    //{
    //    if (double.TryParse(variableTwoText.Text, out variableTwo))
    //    {
    
    
    //take allways the smaller number to start and the greater for end
    start = Math.Min(variableOne, variableTwo); 
    end = Math.Max(variableOne, variableTwo);
    
    //build your output
    output.AppendLine(string.Format("first variable {0}, second variable {1}", variableOne, variableTwo));
    output.AppendLine(string.Format("min", start));
    output.AppendLine(string.Format("max", end));
    output.AppendLine(string.Format("difference {0}", end - start));
    
    
    //all the natural numbers in between.
    for (int i = (int)Math.Ceiling(start); i < Math.Floor(end); i++)
    {
        output.AppendLine(i.ToString());
    }
    
    Console.WriteLine(output.ToString());
    //        outputLabel.Text = output.ToString();
    
    //    }
    
    //}
