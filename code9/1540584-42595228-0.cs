    public partial class Form1 : Form
    {
    	//declare new persons list here, not in method which loads data into list.
    	BindingList<Person> persons = new BindingList<Person>();
    
    	public Form1()
    	{ 
    		InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		//your initial loading is here, I  guess
    		people = new BindingList<Person>();
    		
    		foreach (var tag in names)
    		{
    			people.Add(new Person
    			{
    				Id = tag.ID,
    				Name = tag.Name,
    				Tag = tag.Ref
    			});
    		}
    		dataGridView1.DataSource = people;
    	}
    	
    	private void button1_Click(object sender, EventArgs e)
    	{
    		Person p = new Person() 
    		{
    			Id = 10,
    			Name = "NewPersonName",
    			Tag = 123
    		}
    		//you can see that I'm not making new instance of person list, just adding new Person inside
    		persons.Add(p);
    		dataGridView1.DataSource = people;
    	}
    	
    }
