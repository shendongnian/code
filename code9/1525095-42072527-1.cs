    int n = list.Count;
    for(int i=0; i<n; i++)
    {
        // the second argument "true" indicates to 
        // search child controls recursivly
        Label label = Controls.Find($"supName{i}", true).OfType<Label>().FirstOrDefault(); 
        if (label == null) continue; // no such label, add error handling
        label.Text = list[i].Attributes["name"].Value;
    }
