    private void Form1_Load(object sender, EventArgs e)
    {
        InitializeComboBox();
    }
    
    internal ComboBox ComboBox1;
    private string[] items;
    
    // This method initializes the owner-drawn combo box.
    // The drop-down width is set much wider than the size of the combo box
    // to accomodate the large items in the list.  The drop-down style is set to 
    // ComboBox.DropDown, which requires the user to click on the arrow to 
    // see the list.
    private void InitializeComboBox()
    {
        this.ComboBox1 = new ComboBox();
        this.ComboBox1.DrawMode =
            System.Windows.Forms.DrawMode.OwnerDrawVariable;
        this.ComboBox1.BackColor = Color.Red;
        this.ComboBox1.Location = new System.Drawing.Point(10, 20);
        this.ComboBox1.Name = "ComboBox1";
        this.ComboBox1.Size = new System.Drawing.Size(100, 120);
        this.ComboBox1.DropDownWidth = 250;
        this.ComboBox1.TabIndex = 0;
        this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
        items = new string[] { "Mountain", "Sea", "Other" };
        ComboBox1.DataSource = items;
        this.Controls.Add(this.ComboBox1);
    
        // Hook up the MeasureItem and DrawItem events
        this.ComboBox1.DrawItem +=
            new DrawItemEventHandler(ComboBox1_DrawItem);
        this.ComboBox1.MeasureItem +=
            new MeasureItemEventHandler(ComboBox1_MeasureItem);
        this.ComboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
    }
    
    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Color itemBackgroundColor = new Color();
    
        switch (ComboBox1.SelectedIndex)
        {
            case 0:
                itemBackgroundColor = Color.Red;
                break;
            case 1:
                itemBackgroundColor = Color.Blue;
                break;
            case 2:
                itemBackgroundColor = Color.Green;
                break;
        }
    
        ComboBox1.BackColor = itemBackgroundColor;
    }
    
    // If you set the Draw property to DrawMode.OwnerDrawVariable, 
    // you must handle the MeasureItem event. This event handler 
    private void ComboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        // No change to item height.
        e.ItemHeight = e.ItemHeight;
    }
    
    // You must handle the DrawItem event for owner-drawn combo boxes.  
    // This event handler changes the color, size and font of an 
    // item based on its position in the array.
    private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        string text = ((ComboBox)sender).Items[e.Index].ToString();
        Color itemBackgroundColor = new Color();
    
        switch (e.Index)
        {
            case 0:
                itemBackgroundColor = Color.Red;
                break;
            case 1:
                itemBackgroundColor = Color.Blue;
                break;
            case 2:
                itemBackgroundColor = Color.Green;
                break;
        }
    
        // Draw the background of the item.
        e.DrawBackground();
    
        // Create a square filled with the animals color. Vary the size
        // of the rectangle based on the length of the animals name.
        e.Graphics.FillRectangle(new SolidBrush(itemBackgroundColor), e.Bounds);
    
        // Draw each string in the array, using a different size, color,
        // and font for each item.
    
        e.Graphics.DrawString(items[e.Index], e.Font, Brushes.Black, e.Bounds);
        // Draw the focus rectangle if the mouse hovers over an item.
    
        e.DrawFocusRectangle();
    }
