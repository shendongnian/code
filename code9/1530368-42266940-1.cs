<!-- -->
    					    			
    		var xml = XElement.Parse(@s);
    			    			
    		var lastLvl = xml.Descendants("Variable").Where(x => !x.HasElements);
    				
            Console.WriteLine(String.Join(Environment.NewLine, lastLvl));
    		
    		var names = lastLvl.Select(x => String.Join(".", x.AncestorsAndSelf("Variable").Select(e=>(string)e.Attribute("Name")).Reverse()));
    		
    		Console.WriteLine();
    		Console.WriteLine(String.Join(Environment.NewLine, names));
    	}
    }
