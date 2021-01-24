    public partial class Form1 : Form
    {
    	public Form()
    	{
    		InitializeComponent();
    	}
    
    	public Form(string something)
    	{
            InitializeComponent();
    		listBox.Items.Add(something);
    	}
    }
