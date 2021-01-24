    private void chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
    {
        foreach (LegendItem lit in e.LegendItems)
        {
            var cells = lit.Cells;
            cells[0].Margins = new Margins(30, 0, 400, 100);
            cells[1].Margins = new Margins(30, 0, 0, 200);
        }
    }
