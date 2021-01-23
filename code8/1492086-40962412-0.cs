    public Form1()
    {
        InitializeComponent();
            
        for (int i = 0; i < 5; i++)
        {
            var txtBox = new TextBox();
            txtBox.Name = "TextBox" + i;
            txtBox.TextChanged += TxtBox_TextChanged;
            this.tableLayoutPanel1.Controls.Add(txtBox);
        }
    }
    private void TxtBox_TextChanged(object sender, EventArgs e)
    {
        var txtBox = sender as TextBox;
        string firstName = string.Empty;
        string lastName = string.Empty;
        switch (txtBox.Name)
        {
            case "TextBox1":
                firstName = txtBox.Text;
                break;
            case "TextBox2":
                lastName = txtBox.Text;
                break;
            // more cases here but you get the point...
            default:
                break;
        }
    }
    
