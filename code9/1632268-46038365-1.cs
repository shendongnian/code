    public YourForm()
    {
        InitializeComponent();
        ComboBoxFonts.DrawItem += ComboBoxFonts_DrawItem;           
        ComboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
    }
    private void ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var fontFamily = (FontFamily)comboBox.Items[e.Index];
        var font = new Font(fontFamily, comboBox.Font.SizeInPoints);
        e.DrawBackground();
        e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
    }
