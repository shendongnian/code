	public class MyViewModel : MyModel
	{
	  public int Age { get; set; }
	}
	public class MyModel
	{
	  public string FirstName { get; set; }
	  
	  public string LastName { get; set; }
	}
	[HttpGet]
	public MyViewModel GetTheViewModel() { ... }
	[HttpPost]
	public void ModifyTheViewModel(MyModel input)
