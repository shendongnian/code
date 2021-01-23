    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Person
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
            public Sex Sex { get; set; }
        }
        public enum Sex { Male, Female, Other };
        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<Person> persons = new BindingList<Person>();
            persons.Add(new Person() { Name = "Joe", Lastname = "Doe" , Sex = Sex.Male});
            persons.Add(new Person() { Name = "Nancy", Lastname = "Foo" , Sex = Sex.Female});
            dataGridView1.DataSource = persons;
        }
    }
