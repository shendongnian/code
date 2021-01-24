    using System;
    using System.Collections.Generic;
    
    public class Program
    {
	public static void Main()
	{
		
		List<Student> list =  new List<Student>();
		list.Add(new Student{name= "name1", age= 21, city= "city1"});
		list.Add(new Student{name= "name2", age= 22, city= "city2"});
		list.Add(new Student{name= "name3", age= 24, city= "city3"});
		
		getList(list);
	}
	
	static void getList(List<Student> list)
	{
	  foreach(var s in list)
	  {
	    Console.WriteLine("name = "+s.name + ", age= " + s.age +", city = "+ s.city);
	  }
	
	  }
    }
    public class Student{
    
    	public string name  {set; get;}
    	public int age  {set; get;}
    	public string city  {set; get;}
    
    }
