    for (int i = 0; i < labelContainer.Length ; i++)
    {
        AppResult label = labelContainer[i];
        Assert.IsFalse(string.IsNullOrEmpty(label.Text)); 
    }
