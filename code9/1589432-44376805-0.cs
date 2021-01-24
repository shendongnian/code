    public List<dynamic> GetFilteredLocationData(List<dynamic> locationData, string searchTerm){
    				List<dynamic> totalResults = new List<dynamic>();
    				List<string> locationProperties = new List<string> {"dynamic properties here, this was filled by call to DB for info pertaining to certain location combined with unique data"}
    				foreach (var locData in locationData)
    				{
    					var currentLoc = locData;
    					var currentLocDict = (IDictionary<string, object>)currentLoc;
    
    					bool containsSearchTerm = CheckIfLocationContainsSearch(currentLocDict, allLocationProperties, searchTerm);
    					if (containsSearchTerm)
    					{
    						totalResults.Add(locData);
    					}
    				}
    			}
    			
    			public bool CheckIfLocationContainsSearch(IDictionary<string,object> location, List<string> locationProperties, string searchTerm){
            
                foreach (var locProp in locationProperties)
                {
                    if (location[locProp].ToString().ToLower().Contains(searchTerm))
                    {
                        return true;
                    }
                }
                return false;
            }
