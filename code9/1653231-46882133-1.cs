    private Label[] labels = new Label[10];  // Presumably this array is filled somewhere
    private Random rnd = new Random();
    private void button1_Click(object sender, EventArgs e)
    {
        if (labels != null && labels.Length > 0)
        {
            // If needed, this will hide any currently visible labels in the array
            foreach(var label in labels.Where(label => label.Visible))
            {
                label.Visible = false;
            }
            // Pick a random label and make it visible
            labels[rnd.Next(0, labels.Length)].Visible = true;
        }
    }
