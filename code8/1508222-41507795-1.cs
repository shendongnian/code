    List<Panel> MyPanels = new List<Panel>();
    int panel_LOC = -60;
    private void button1_Click(object sender, EventArgs e)
    {
        Panel panel = new Panel();
        MyPanels.Add(panel);
        panel_LOC = panel_LOC + 60;
        panel.Location = new Point(0, panel_LOC);
        ...
