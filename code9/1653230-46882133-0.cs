    private Label[] labels = new Label[10];  // Presumably this array is filled somewhere
    private Random rnd = new Random();
    private void button1_Click(object sender, EventArgs e)
    {
    private void button1_Click(object sender, EventArgs e)
    {
        if (labels != null && labels.Length > 0)
        {
            foreach(var label in labels.Where(label => label.Visible))
            {
                label.Visible = false;
            }
            labels[rnd.Next(0, labels.Length)].Visible = true;
        }
    }
    }
