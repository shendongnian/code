    int n = 3; // Added for testing, probably you already have it somewhere
    int space = 0; // Added for testing, probably you already have it somewhere
    // Moved for logic
    // Value modified for testing
    int UsernameX = 100;
    int UsernameY = 45;
    int RemoveX = 400;
    int RemoveY = 45;
        
    int SpaceDelta = 35; // Added for logic
        
    List<Button> RemoveButtons = new List<Button>();
    List<TextBox> UsernameTextBoxes = new List<TextBox>();
    private void button1_Click(object sender, EventArgs e) {
            
        Random rnd = new Random((int)DateTime.Now.Ticks); // Added for testing
        for (int i = 0; i < n; i++) {
            var Username = new TextBox();
            Username.Size = new Size(233, 26);
            Username.Location = new Point(UsernameX, UsernameY + space);
            Username.Font = new Font("Arial", 10);
            Username.Name = "Username";
            Username.Text = $"{(int)(rnd.NextDouble() * 100000)}"; // Added for testing
            var Remove = new Button();
            Remove.Location = new Point(RemoveX, RemoveY + space);
            Remove.Text = $"{(int)(rnd.NextDouble() * 100000)}";  // Modified for testing
            Remove.Font = new Font("Arial", 10);
            Remove.Size = new Size(95, 23);
            Remove.UseVisualStyleBackColor = true;
            Remove.Click += new EventHandler(Remove_Click);
            Remove.Name = "Remove";
            Controls.Add(Username);
            Controls.Add(Remove);
                
            RemoveButtons.Add(Remove);
            UsernameTextBoxes.Add(Username);
            space += SpaceDelta;
        }
    }
    private void Remove_Click(object sender, EventArgs e) {
        int idx = RemoveButtons.IndexOf((Button)sender);
        // Remove button
        RemoveButtons[idx].Dispose();
        RemoveButtons.RemoveAt(idx);
        // Remove textbox
        UsernameTextBoxes[idx].Dispose();
        UsernameTextBoxes.RemoveAt(idx);
        // Shift controls up
        for (int i = idx; i < RemoveButtons.Count; i ++) {
            RemoveButtons[i].Top -= SpaceDelta;
            UsernameTextBoxes[i].Top -= SpaceDelta;
        }
            
        space -= SpaceDelta;
    }
