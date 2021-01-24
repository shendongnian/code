    <TextBox x:Name="textBox1" Text="{Binding SomeProperty, UpdateSourceTrigger=PropertyChanged, StringFormat='{}{0}%'}" />
----------
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            textBox1.DataContext = this;
        }
        public int SomeProperty { get; set; }
    }
