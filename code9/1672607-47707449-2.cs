    generator();
    
    public async void generator()
    {
       generatedArray = getUniqueRandomArray(1, 81, 20).ToArray();
       for (int i = 0; i < MyLabels.Count; i++)
       {
          for (int j = 1; j < generatedArray[i] + 1; j++)
          {
             await Task.Run(async () => await Task.Delay(500));
             
             //Set the text property of the custom labels. The order will be respected
             MyLabels[i].Text = j.ToString();
          }
    }
