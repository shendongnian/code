    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    
    namespace Motor
    {
    
          public partial class Form1 : Form
          {
    
    
                public Form1()
                {
                      InitializeComponent();
                      ComPort.DataReceived += new
                      System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
                      plot1.Model = GridLinesHorizontal();
                      //create new LineSeries and add it to the PlotView
                      Line1 = new LineSeries
                      {
                            Title = "Test Series",
                            Color = OxyColors.Red,
                            TextColor = OxyColors.Red,
                            BrokenLineColor = OxyColors.Red
                      };
                      plot1.Model.Series.Add(Line1);
    
                }
    
                LineSeries Line1; // declare Line1 as global
    
                public static PlotModel GridLinesHorizontal()
                {
                      var plotModel = new PlotModel();
                      plotModel.Title = "Horizontal";
                      var linearAxis1 = new LinearAxis();
    
                      linearAxis1.MajorGridlineStyle = LineStyle.Solid;
                      linearAxis1.MinorGridlineStyle = LineStyle.Dot;
                      linearAxis1.Maximum = 5;
                      linearAxis1.Minimum = -5;
                      plotModel.Axes.Add(linearAxis1);
    
                      return plotModel;
    
                }
    
    
                private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
                {
    
                      InputData = ComPort.ReadLine();
    
                      if (InputData != String.Empty)
                      {
                            this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
                      }
                }
                int plotIndex = 0;
                private void SetText(string text)
                {
                      dVal = double.Parse(text, CultureInfo.InvariantCulture); // convert to double
                      ///// plotIndex is the x value of the new point, not sure if OxyPlot offers an auto increment option
                      Line1.Points.Add(new DataPoint(plotIndex, dVal));
                      plotIndex++;
                      plot1.Invalidate();
                }
    
          }
    
    }
