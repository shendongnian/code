    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Person> people = new List<Person>()
                {
                    new Person() { FirstName = "Donald", LastName = "Duck" },
                    new Person() { FirstName = "Mickey", LastName = "Mouse" }
                };
            BindingSource bs = new BindingSource();
            bs.DataSource = people;
            comboBox1.DataSource = bs;
            comboBox1.DisplayMember = "FullName";
            textBox1.DataBindings.Add(new Binding("Text", bs, "FirstName", false, DataSourceUpdateMode.OnPropertyChanged));
            textBox2.DataBindings.Add(new Binding("Text", bs, "LastName", false, DataSourceUpdateMode.OnPropertyChanged));
        }
    }
