    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Data> data = new List<Data>();
            data.Add(new Data("Set1", 1, 2, 3));
            data.Add(new Data("Set2", 3, 2, 3));
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Name";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var set = comboBox1.SelectedValue as Data;
            var val1 = 1;
            float zFormula = (set.A * val1) + (set.B * val1) + (set.C * val1);
            textbox1.Text = Convert.ToString(zFormula);
        }
    }
    public class Data
    {
        public Data(string name, float a, float b, float c)
        {
            Name = name;
            A = a; B = b; C = c;
        }
        public string Name { get; protected set; }
        public float A { get; protected set; }
        public float B { get; protected set; }
        public float C { get; protected set; }
    }
