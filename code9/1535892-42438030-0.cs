    public partial class Form1 : Form
    {
        class MyData
        {
            public string Somestring { get; set; }
            public string Anotherstring { get; set; }
            public MyData(string some, string another) {
                Somestring = some;
                Anotherstring = another;
            }
        }
        public Form1()
        {
            InitializeComponent();
            var data = new List<MyData> {
                new MyData("First Row, First Column", "First Row, Second Column"), 
                new MyData("Second Row, First Column", "Second Row, Second Column"),
                new MyData("Third Row, First Column", "Third Row, Second Column"),
                new MyData("Fourth Row, First Column", "Fourth Row, Second Column")
            };
            var source = new BindingSource();
            source.DataSource = data;
            this.dataGridView1.DataSource = source;
        }
    }
