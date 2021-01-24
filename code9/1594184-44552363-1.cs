    public class FooCarrier
    {
        public Foo Foo { get; set; }
        public String Title { get { return Foo.settings.Title; } }
    }
...
    public Form1()
    {
        InitializeComponent();
        comboBox1.DataSource = new List<Foo> {
            new Foo("MASTER 5DAY"),
            new Foo("5 Day Reminder"),
            new Foo("MASTER Welcome"),
            new Foo("Welcome Letter")
        }.Select(f => new FooCarrier { Foo = f }).ToList();
        comboBox1.DisplayMember = "Title";
        comboBox1.ValueMember = "Foo";
        comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
    }
    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  comboBox1.SelectedItem will be FooCarrier, but since we set 
        //  ValueMember to "Foo", SelectedValue is the Foo property of the selected
        //  item. 
        Foo selectedFoo = (Foo)comboBox1.SelectedValue;
    }
