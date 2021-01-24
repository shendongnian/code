    public Dictionary<string, string> GetLabelText()
    {
        var labels = new Dictionary<string, string>();
        labels.Add(A1.Name, A1.Text);
        labels.Add(A2.Name, A2.Text);
        // Add all the others
        return labels;
    }
