    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		    //Create List of Model
		    var lst = new List<Model>();
            //Insert Elements into List
		    lst.Add(new Model{ ID = 1, Name = "ABC"});
		    lst.Add(new Model{ ID = 2, Name = "DEF"});
		    lst.Add(new Model{ ID = 3, Name = "GHI"});
		    lst.Add(new Model{ ID = 4, Name = "JKL"});
		    lst.Add(new Model{ ID = 5, Name = "MNO"});
		
            //Actual Logic to get proper output
		    int count = 0;
		    string output = @"";
		    foreach(var currentModel in lst){
			
			if(count == lst.Count - 1){
				output = output + "and " + "<a href='link'>" + currentModel.Name + "</a>";
			}
			else{
				output = output + "<a href='link'>" + currentModel.Name + "</a>" + ", ";
			}
			count ++;
		}
		    ViewBag.Links = output; //Now you can use it on View
		    Console.WriteLine(output);
	    }
    }
    public class Model{
	    public int ID { get; set; }
	    public string Name { get; set; }
    }
