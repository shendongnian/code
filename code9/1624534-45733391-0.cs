    foreach (FileInfo fi in rgFiles)
    {
        current++;
        fileProcessBar.Value = current / count * 60 + 40;                 
        string[] alllines = File.ReadAllLines(fi.FullName);
        // Ensure that resources are released.
        using (CreateForm CF = new CreateForm(fi.FullName))
        {
            for (int i = 0; i < alllines.Length; i++)
            {
                if (alllines[i].Contains("$"))
                {
                    int dollarIndex = alllines[i].IndexOf("--");
                    Regex regex = new Regex(@"(--.{1,100})");
                    var chars = regex.Match(alllines[i]).ToString();
                    string PromptText = chars.Replace("-", "");
                    CF.AddToCanvas(PromptText);
                    CF.ShowDialog(); // This should block until closed.
                }
            }
        }
    }
    
