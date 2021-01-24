    private void CreateButtonDelegate(object sender, EventArgs e)
    {
        Button newButton= new Button();
        this.Controls.Add(newButton);
        newButton.Text = "Created Button";
        newButton.Location = new Point(70,70);
        newButton.Size = new Size(50, 100);
        newButton.Location = new Point(20, 50);
    }
