    private void chart1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        chart1.ApplyPaletteColors();
        foreach (var kv in ChartColumnRectangles)
        {
            {
                foreach (var r in kv.Value)
                    g.DrawRectangle(Pens.Black, r);
            }
        }
    }
