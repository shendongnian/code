    public partial class Form1 : Form
    {
        private ObservableValue value1;
        
        public Form1()
        {
            InitializeComponent();
            //int val1 = int.Parse(Settings.Default.Value1);
            value1 = new ObservableValue(3);
            //...
            cartesianChart1.Series.Add(new LineSeries 
            {
                Values = new ChartValues<ObservableValue> { value1, ... },
            });
        }
        private void changeValue1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value1.Value = 10;
            Settings.Default.Value1 = "10";
            Settings.Default.Save();
            this.Text = Settings.Default.Value1;
        }
    }
