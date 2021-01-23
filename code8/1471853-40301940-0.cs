    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		
		    var lst = new List<Model>();
		    lst.Add(new Model{ ID = 1, Name = "ABC"});
		    lst.Add(new Model{ ID = 2, Name = "DEF"});
		    lst.Add(new Model{ ID = 3, Name = "GHI"});
		    lst.Add(new Model{ ID = 4, Name = "JKL"});
		    lst.Add(new Model{ ID = 5, Name = "MNO"});
		
		    int count = 0;
		    string output = @"";
		    foreach(var currentModel in lst){
			
			    if(count == lst.Count - 1){
				    output = output + "and " + currentModel.Name;
			    }
			    else{
				    output = output + currentModel.Name + ", ";
			    }
			    count ++;
		    }
		
		    Console.WriteLine(output);
	    }
    }
    public class Model{
	    public int ID { get; set; }
	    public string Name { get; set; }
    }
