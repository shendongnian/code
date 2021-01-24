    public static List<PropertyModel> GetAll()
    {
        List<PropertyModel> myList= new List<PropertyModel>();
        myList.Add(new PropertyModel(){Name = "Anna", Value = "500$"});
        myList.Add(new PropertyModel(){Name = "Michellen", Value = "520$"});
    
        return myList;
    }
    //to use the function
    public static void Main()
    {
       foreach(var item in GetAll())
       {
           Console.WriteLine("Name {0} - Value {1}",item.Name,item.Value);
       }
       Console.Read();
    }
