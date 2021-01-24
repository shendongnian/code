    public List<Plate> MyPlates { get; set; }
    
    public MyViewModel() //Constructor
    {
    	MyPlates = ((App)Application.Current).MyGlobalListofPlates;
    }
