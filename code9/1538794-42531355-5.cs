    public partial class Form2 : Form
    {
        List<CityListItems> valuesTo = new List<CityListItems>();
        List<CityListItems> valuesFrom = new List<CityListItems>();
        Stopwatch sw = new Stopwatch();
        public Form2()
        {
            InitializeComponent();
            sw.Start();
            for (int i = 0; i < 30000; i++)
            {
                valuesTo.Add(new CityListItems("TO Value " + i));
            }
            for (int i = 0; i < 30000; i++)
            {
                valuesFrom.Add(new CityListItems("From Value " + i));
            }
 
            // just uncomment the part that you would like to measure
            // and comment out the other 2
            //comboBox1.Items.AddRange(valuesTo.ToArray());
            //comboBox2.Items.AddRange(valuesFrom.ToArray());
            //listBox1.DataSource = valuesTo;
            //listBox2.DataSource = valuesFrom;
            dataGridView1.DataSource = valuesTo;
            dataGridView2.DataSource = valuesFrom;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            sw.Stop();
            textBox1.Text = "TIME: " + sw.ElapsedMilliseconds;
        }
    }
