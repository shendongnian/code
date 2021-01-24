    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Test
    {
    	public class GrandParent{
    		public List<Parent> parentList{ get; set; }
    		public string name{ get; set; }
    		public GrandParent(string name){
    			this.name = name;
    			this.parentList = new List<Parent>();
    		}
    	}
    	public class Parent{
    		public List<Child> childList{ get; set;}
    		public string name{ get; set; }
    		public Parent(string name){
    			this.name = name;
    			this.childList = new List<Child>();
    		}
    	}
    	public class Child{
    		public string city{ get; set;}
    		public Child(string city){
    			this.city = city;
    		}
    	}
    	public static void Main()
    	{
    		Child c1 = new Child("ABC"), c2 = new Child("123"), c3 = new Child("tmp");
    		Parent p1 = new Parent("p1"), p2 = new Parent("p2"), p3 = new Parent("p3");
    		GrandParent g1 = new GrandParent("g1"), g2 = new GrandParent("g2"), g3 = new GrandParent("g3");
    		
    		p1.childList.Add(c1); p1.childList.Add(c2); 
    		p2.childList.Add(c2); 
    		p3.childList.Add(c3);
    		
    		g1.parentList.Add(p1); g1.parentList.Add(p2); g1.parentList.Add(p3);
    		g2.parentList.Add(p2);
    		g3.parentList.Add(p3);
    		
    		List<GrandParent> repo = new List<GrandParent>{g1, g2, g3};
    		
    		var filteredParents = from g in repo
                        		  from p in g.parentList
                        		  where p.childList.Any(c => c.city == "tmp")
                        		  select new Parent(p.name){
                        		 	 childList = p.childList.Where(c => c.city == "tmp").ToList()
                        		  };
                        		 
         	var filteredGrandParents = from g in repo
         							   from p in g.parentList
         							   where filteredParents.Any(fp => fp.name == p.name)
         							   select new GrandParent(g.name){
         							   	   parentList = g.parentList.Where(pp => filteredParents.Any(fp => fp.name == pp.name)).ToList()
         							   };
                        		 
            foreach(var g in filteredGrandParents){
            	Console.WriteLine(g.name);
            	foreach(var p in g.parentList){
            		Console.WriteLine("\t" + p.name);
            		foreach(var c in p.childList){
            			Console.WriteLine("\t\t" + c.city);
            		}
            	}
            	Console.WriteLine();
            }
    	}
    }
