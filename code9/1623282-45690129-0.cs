    PeopleJobsEntities db;
    
    public FormTest()
    {
    	InitializeComponent();
    	db = new PeopleJobsEntities();
    	db.Database.Log = Console.Write;
    	db.People.Load();
    	List<People> peoplelist = db.People.Local.ToList();
    	listBox1.DataSource = peoplelist;
    }
    
    private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
    {
       if (db != null)
    		db.Dispose();
      
    }
    
    private void listBox1_SelectedValueChanged(object sender, EventArgs e)
    {
    	People p = (People)listBox1.SelectedItem;
    	if(p != null)
    	{
    		List<Job> oldlist = db.Job.Local.ToList();
    		foreach (Job j in oldlist)
    		{
    			db.Entry(j).State = EntityState.Detached;
    		}
    		db.Entry(p).Collection(b => b.Job).Load();
    		jobBindingSource.DataSource = db.Job.Local.ToBindingList();
    	}
    }
    
    private void jobBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
    	foreach(DataGridViewRow row in jobDataGridView.Rows)
    	{
    		if(row != null && row.DataBoundItem != null)
    		{
    			Job j = (Job)row.DataBoundItem;
    			if(db.Entry(j).State == EntityState.Added)
    			{
    				if(j.People.Count == 0)
    				{
    					People people = (People)listBox1.SelectedItem;
    					if (people != null)
    						j.People.Add(people);
    				}
    			}
    		}
    	}
    	db.SaveChanges();
    }
