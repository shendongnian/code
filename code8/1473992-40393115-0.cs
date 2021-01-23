    public class ViewModel
    {
    	public DataTable Persons { get; set; }
    	public DataTable Gender { get; set; }
    	public ViewModel()
    	{
    		Persons = new DataTable();
    		Persons.Columns.Add("FirstName", typeof(string));
    		Persons.Columns.Add("GenderID", typeof(int));
    
    		Persons.Rows.Add("Mathew",1);
    		Persons.Rows.Add("Gil", 2);
    
    		Gender = new DataTable();
    		Gender.Columns.Add("Name", typeof(string));
    		Gender.Columns.Add("GenderID", typeof(int));
    
    		Gender.Rows.Add("Male", 1);
    		Gender.Rows.Add("Female", 2);
    	}
    }
