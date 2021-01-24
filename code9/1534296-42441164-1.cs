      public Form1()
        {
            InitializeComponent();
            InitializeChart();
        }
    
        Steema.TeeChart.Axis axis1;
        DateTime dt; 
        private void InitializeChart()
        {
            tChart1 = new Steema.TeeChart.TChart();
            tChart1.Dock = DockStyle.Fill;
            this.Controls.Add(tChart1);
            tChart1.Aspect.View3D = false;
            axis1 = new Steema.TeeChart.Axis();
            tChart1.Axes.Custom.Add(axis1);
            axis1.Horizontal = false;
    
            tChart1.Axes.Right.StartPosition = 0;
            tChart1.Axes.Right.EndPosition = 50;
    
            axis1.StartPosition = 51;
            axis1.EndPosition = 100;
    
            axis1.OtherSide = true;
            axis1.AxisPen.Visible = false;
            dt = DateTime.Now;
            tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MM";
            tChart1.Axes.Bottom.Labels.Style = Steema.TeeChart.AxisLabelStyle.Value;
            InitializeSeries();
            tChart1.Draw();
            
            tChart1.AfterDraw += TChart1_AfterDraw;
        }
    
        private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
           for (int i=0; i<tChart1[0].Count; i++)
            {
                Point point1, point2;
                point1= new Point(tChart1.Axes.Bottom.CalcPosValue(tChart1[0].XValues[i]),tChart1.Axes.Right.CalcYPosValue(tChart1[0].YValues[i]));
                point2= new Point(tChart1.Axes.Bottom.CalcPosValue(tChart1[0].XValues[i]), axis1.CalcYPosValue(tChart1[0].YValues[i]));
                g.Line(point1, point2);
            }
        }
    
        private void InitializeSeries()
        {
            for (int i=0; i<10; i++)
            {
                if (i==0)
                {
                    new Steema.TeeChart.Styles.Area(tChart1.Chart);
                    tChart1.Series[i].XValues.DateTime = true;
                    (tChart1.Series[i] as Steema.TeeChart.Styles.Area).AreaLines.Visible = false;
                    (tChart1.Series[i] as Steema.TeeChart.Styles.Area).Color = Color.BlueViolet;
                    (tChart1.Series[i] as Steema.TeeChart.Styles.Area).Transparency = 20;
                    Random rnd = new Random();
                    for (int j=0; j<10; ++j)
                    {
                        tChart1.Series[i].Add(dt, rnd.Next(100));
                        dt = dt.AddDays(1);
                    }
                    
                    tChart1.Series[i].Marks.Visible = false;
                    tChart1.Series[i].VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right;
                }
                else if(i==1)
                {
                    new Steema.TeeChart.Styles.Volume(tChart1.Chart);
                    tChart1.Series[i].DataSource = tChart1.Series[i - 1];
                    tChart1.Series[i].CustomVertAxis = axis1;
                }
            }          
        }
