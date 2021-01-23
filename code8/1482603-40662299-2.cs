    Form f = new Form();
    TableLayoutPanel tlp = new TableLayoutPanel();
    tlp.RowCount = 5;  // <= this should come from user input 
    tlp.ColumnCount = 5; // <= this should come from user input 
    
    tlp.Dock = DockStyle.Fill;
    for (int x = 0; x < 5; x++)
    {
        for (int y = 0; y < 5; y++)
        {
            CheckBox ledcheck = new CheckBox();
            // No need to position the checkboxes.....
            // ledcheck.Location = new Point(x * 20, y * 20);
            ledcheck.Size = new Size(15,15);
            tlp.Controls.Add(ledcheck);
        }
    }
    f.Controls.Add(tlp);
    f.Show();
