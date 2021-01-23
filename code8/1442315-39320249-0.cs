    public partial class Form1 : Form
    {
	List<string> _items = new List<string>(); // <-- Add this
	public Form1()
	{
	    InitializeComponent();
	    _items.Add("One"); // <-- Add these
	    _items.Add("Two");
	    _items.Add("Three");
	    listBox1.DataSource = _items;
	}
    public void add()
    {
     _items.Add("four");
     _items.Sort();
    }
    }
