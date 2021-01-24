	public class ParentObject
	{
		public int id {get;set;}
		public string parent_object_name {get;set;}
		public List<ChildObject> child_objects {get;set;}
	}
	public class ChildObject
	{
		public int id {get;set;}
		public string child_object_name {get;set;}
        
        // add a parent
		public ParentObject parent_object {get;set;}
	}
	
	public static void Main()
	{
		var parent_object = new ParentObject
		{
  			id = 1,
  			parent_object_name = "test name"
		};
		parent_object.child_objects = new List<ChildObject>
		{
			new ChildObject {id = 1, child_object_name = "test name", parent_object = parent_object}
		};
		Console.WriteLine(parent_object.child_objects.First().parent_object.parent_object_name);
	}
