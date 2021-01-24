    private Label[] labels = new Label[10];  // Presumably this array is filled somewhere
    private Random rnd = new Random();
    private void Form1_Load(object sender, EventArgs e)
    {
        for(int i = 0; i < labels.Length; i++)
        {
            labels[i] = new Label
            {
                Height = 20,
                Left = 10,
                Name = $"Label{i}",
                Tag = i,
                Text = $"Label{i}",
                Top = 10 + 20 * i,
                Visible = false
            };
            this.Controls.Add(labels[i]);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (labels != null && labels.Length > 0)
        {
            // If needed, this will hide any currently visible labels in the array
            foreach(var label in labels.Where(label => label != null && label.Visible))
            {
                label.Visible = false;
            }
            // Pick a random label and make it visible
            labels[rnd.Next(0, labels.Length)].Visible = true;
        }
    }
