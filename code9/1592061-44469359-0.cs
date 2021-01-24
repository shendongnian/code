    List<Button> buttons = new List<Button>();
    List<Label> labels = new List<Label>();
    
    buttons.Add(xButton1)
    buttons.Add(oButton1)
    buttons.Add(xButton2)
    buttons.Add(oButton2)
    ...
    
    labels.Add(xLabel1)
    labels.Add(oLabel1)
    labels.Add(xLabel2)
    labels.Add(oLabel2)
    ...
    foreach(var ctr in buttons)
    {
         ctr.Enabled = true;
    }
    foreach(var ctr in labels)
    {
         ctr.Enabled = true;
    }
