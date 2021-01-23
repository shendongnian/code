    var progressBars = new List<ProgressBar>();
    
    foreach (var control in Controls)
    {
        // this ensure the type is a ProgressBar, unlike name, it cant be randomly assigned
        if (control is ProgressBar)
        {
            // a cast is needed here
            progressBars.Add(control as ProgressBar);
        }
    }
    
    progressBars[0].Value = 100;
