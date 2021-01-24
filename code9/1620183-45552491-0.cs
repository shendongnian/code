    class Person
    {	
    	public Person()
    	{
    
    	}
    
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string BloodGroup { get; set; }
    	public string Address { get; set; }
    }
    
    class Student : Person
    {
    	//unique Student properties go here
    }
    class Teacher : Person
    {
    	//unique teacher properties go here
    }
    
    class GenericClassTest
    {
        public List<T> getInformation<T>(List<T> infos )
    		where T : Person, new()
        {
            var infoList = new List<T>(); // It's not working
            foreach (T item in infos)
            {
                T info = new T();
                info.Id = item.Id;
                info.Name = item.Name;
                info.BloodGroup = item.BloodGroup;
                info.Address = item.Address;
                infoList.Add(info);
            }
            return infoList;
        }
    }
