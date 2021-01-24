    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
    {
        float h = (100 - yOffTop - yOffBottom) / visibleCount;
        ChartArea main = chart1.ChartAreas[0];
        for (int i = 1; i < chart1.ChartAreas.Count; i++)
        {
            float yOff = i != 0 ? mainExtra : 0;
            float yExtra = i == 0 ? mainExtra : 0;
            ChartArea ca = chart1.ChartAreas[i];
            ca.Position = new ElementPosition(0, h * i - vScrollBar1.Value + mainExtra, 80, h);
            ca.Visible = ca.Position.Y  >= main.Position.Bottom ;
        }
    }
