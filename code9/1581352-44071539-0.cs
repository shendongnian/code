    using System.Linq;
    ...
    // Add step to progress, return list of steps
    public List<string> WriteToProgress(string step) {
      // Add step (if it's not null or empty) to progress
      if (!string.IsNullOrEmpty(step))
        myListBox.Items.Add(step);
      // collect and return all steps as a list:
      return myListBox.Items
        .OfType<Object>()
        .Where(o => o != null)
        .Select(o => o.ToString())
        .ToList();
    } 
    ...
    WriteToProgress("step #1: db connect"); 
    WriteToProgress("step #2: uploading"); 
    ...
    // Let's report the progress so far
    var progress = WriteToProgress("step #N: reporting");
    MessageBox.Show(string.Join(Environment.NewLine, progress));
