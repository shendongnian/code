	JToken currentContainer = null;
    foreach (var item in lftIndustries)
    		{
    			
    				//not good enough, need to get deepest, empty "children" node
    				// and add "industry" to it
    			if (currentContainer != null)
    			{
    				var node = ((JContainer)currentContainer).Last;
    				var childArray = (JArray)((JContainer) node).Last;
    	
    				var industry = new JObject(new JProperty("name", item.Value.Name), new JProperty("children", new JArray()));
    	
    				childArray.Add(industry);
    				currentContainer = industry;
    			}
    			else
    			{
    				var node = ((JContainer)relationship).Last;
    				var childArray = (JArray)((JContainer) node).Last;
    	
    				var industry = new JObject(new JProperty("name", item.Value.Name), new JProperty("children", new JArray()));
    	
    				childArray.Add(industry);
    				currentContainer = industry;
    			}
    			    
    		
    		}
