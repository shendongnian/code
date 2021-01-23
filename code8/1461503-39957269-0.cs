    public class Data : INotifyPropertyChanged
    {
        public string Name
        {
            get { return color.Name; }
        }
        private Color color;
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                if( PropertyChanged != null )
                    this.PropertyChanged( this, new PropertyChangedEventArgs( "Color" ) );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Form1 : Form
    {
        private ComboBox comboBox1;
        private ListBox listBox1;
        private Button button1;
        public Form1()
        {
            InitializeComponent();
            List<Data> dataList = new List<Data>
            {
                new Data { Color = Color.Red },
                new Data { Color = Color.Yellow },
                new Data { Color = Color.Green },
                new Data { Color = Color.Blue },
            };
            comboBox1.DataSource = dataList;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Color";
        }
        public Data Current
        {
            get { return comboBox1.SelectedItem as Data; }
        }
        private void button1_Click( object sender, EventArgs e )
        {
            listBox1.BackColor = Current.Color;
        }
        private void InitializeComponent()
        {
            //...
        }
    }
