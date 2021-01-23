    public Form1()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.Manual;
        Rectangle area = Screens.Primary.WorkingArea;
        Location = new Point(area.Width-315, area.Height-340);
    }
