    void Main()
    {    	
    	bool copyreference = true;
 
   	var allLists = new List<Base>();
    	var studentList  = new List<Student>();   
    	studentList.Add(new Student("Alf", "Bedrock", 123));
    	studentList.Add(new Student("Alfine", "Bedrock", 456));	
    	var teacherList  = new List<Teacher>();    
    	teacherList.Add(new Teacher("Brad", "Gulp", "MATH"));
    	teacherList.Add(new Teacher("Evelyn", "Gulp", "BIO"));
    	
    
    	if (copyreference)
    	{
    		allLists.AddRange(studentList);
    		allLists.AddRange(teacherList);
    	}
    	else
    	{
    		foreach (var item in studentList)
    		{
    			allLists.Add(new Student(item.Name, item.Surname, item.StudentID));
    		}
    	}
    		
    	Console.WriteLine(String.Join(Environment.NewLine, allLists));
    	// TEST changing a value in the original list
    	studentList[0].Name = "Harry";
        // if you copied references you will see the change in the final list
    	Console.WriteLine(Environment.NewLine + String.Join(Environment.NewLine, allLists));
    }
