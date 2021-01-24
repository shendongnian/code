    public partial class Form2 : Form
    {
        public string[] strarray { get; set; } //add this.
    
        public Form2()
        {
            InitializeComponent();
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
    		//You can also use foreach to avoid out of bound index
    		foreach(var strItem in strarray)
    		{
    			label.Text = "Hello " + strItem;
    		}
        }
    }
