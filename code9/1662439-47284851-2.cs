    public partial class Wdw_graph : Window
    {
        public Wdw_graph(List<dated_value> serie)
        {
            InitializeComponent();         
			cartesian_chart.AxisX.Add(new Axis
            {
                Name = "xAxis",
                Title = "Date and Time",
                FontSize = 20,
                Foreground = System.Windows.Media.Brushes.Black,
                MinValue = 0,
                MaxValue = serie.Count,
                Labels = new String[serie.Count],
            });
            cartesian_chart.AxisY.Add(new Axis
            {
                Name = "yAxis",
                Title = "Currency",
                FontSize = 20,
                Foreground = System.Windows.Media.Brushes.Black,
                MinValue = 0,
                MaxValue = 10,
            });
            cartesian_chart.AxisX[0].Separator.Step = 1;
            cartesian_chart.AxisX[0].LabelsRotation = 80;
                        
            ColumnSeries col_serie = new ColumnSeries {
            		Values = new ChartValues<double>(),
            		DataLabels = true };
                       
            for(int i = 0; i < serie.Count; i++)
            {
                col_serie.Values.Add(serie[i].value);
                cartesian_chart.AxisX[0].Labels[i] = serie[i].date;
            }
			cartesian_chart.Series.Add(col_serie);
            
            DataContext = this;
        }
    }
