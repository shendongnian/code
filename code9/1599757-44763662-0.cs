    Dictionary<Button, TextBox> pair = new Dictionary<Button, TextBox>(); // A dictionary to store the Button - TextBox pair
    private void button1_Click(object sender, EventArgs e) {
        int n = 3; // Added for testing
        int space = 0; // Added for testing
        int UsernameX, UsernameY, RemoveX, RemoveY;
        UsernameX = 100; // Modified for testing
        UsernameY = 45;
        RemoveX = 400; // Modified for testing
        RemoveY = 45;
        for (int i = 0; i < n; i++) {
            var Username = new TextBox();
            Username.Size = new Size(233, 26);
            Username.Location = new Point(UsernameX, UsernameY + space);
            Username.Font = new Font("Arial", 10);
            Username.Name = "Username";
            var Remove = new Button();
            Remove.Location = new Point(RemoveX, RemoveY + space);
            Remove.Text = "Remove";
            Remove.Font = new Font("Arial", 10);
            Remove.Size = new Size(95, 23);
            Remove.UseVisualStyleBackColor = true;
            Remove.Click += new EventHandler(Remove_Click);
            Remove.Name = "Remove";
            Controls.Add(Username);
            Controls.Add(Remove);
            pair.Add(Remove, Username);
            space += 35;
        }
    }
    private void Remove_Click(object sender, EventArgs e) {
        Controls.Remove((Button)sender); // Removes the delete button
        Controls.Remove(pair[(Button)sender]); // Removes the textbox
        pair.Remove((Button)sender); // Removes the entry in dictionary
    }
