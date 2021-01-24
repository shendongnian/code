     public partial class Form1 : Form
        {
            private ChartArea _myArea;
    
            public Form1()
            {
                InitializeComponent();
                _myArea = new ChartArea("chartArea");
                _myArea.AxisX.Minimum = -500;            
                chart1.ChartAreas.Add(_myArea);
                chart1.Series.FirstOrDefault().ChartArea = "chartArea"; //comment this line and behavior reproduced
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                _myArea.AxisX.Minimum = _myArea.AxisX.Minimum - 50;            
                chart1.Update();
            }
        }
