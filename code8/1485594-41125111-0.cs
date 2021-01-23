    public Form1()
    {
        InitializeComponent();
        InitializeChart();
    }
    private void InitializeChart()
    {
        Steema.TeeChart.Styles.Surface surfa1 = new Steema.TeeChart.Styles.Surface(tChart1.Chart);
        tChart1.Legend.Visible = false;
        this.Text = tChart1.ProductVersion;
        surfa1.FillSampleValues(50);
        surfa1.UsePalette = true;
        surfa1.UseColorRange = false;
        Steema.TeeChart.Tools.LegendPalette legendP = new Steema.TeeChart.Tools.LegendPalette(tChart1.Chart);
        legendP.Series = surfa1;
        legendP.Axis = Steema.TeeChart.Tools.LegendPaletteAxis.laOther;
        legendP.Axes.Right.Labels.Font.Bold = false;
        tChart1.Panel.MarginRight = 20;
        tChart1.Draw();
        legendP.Left = tChart1.Axes.Bottom.IEndPos + 10;
        legendP.Top = tChart1.Axes.Right.IStartPos;
        legendP.Pen.Visible = false;
    }
