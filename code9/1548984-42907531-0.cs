    public partial class Form1 : Form
    {
    	public Form()
    	{
    		InitializeComponent();
    	}
    
    	public Form(string something): this()
    	{
    		listBox.Items.Add(something);
    	}
    }
