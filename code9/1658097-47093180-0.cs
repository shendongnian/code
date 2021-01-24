    public static void Main()
        {
            var program = new Program();
            var empList = program.GetData();
           
			Func<IEnumerable<Employee>, Employee, IEnumerable<KeyValuePair<Employee, Employee>>> TreeToDict = null;
            TreeToDict = (employees, topParent) => 
            employees.SelectMany(e => 
								 {
									 if(e.childList != null)
									 {
										 return TreeToDict(e.childList, topParent == null ? e : topParent);
									 }
									 else
									 {
										 Dictionary<Employee, Employee> dict = new Dictionary<Employee, Employee>();
										 dict.Add(e, topParent == null ? e : topParent);
										 return dict;
									 }
								 });
			
			foreach(var emp in TreeToDict (empList, null))
			{
				Console.WriteLine("key : {0}, value {1}", emp.Key.Name, emp.Value.Name);
			}
        }
