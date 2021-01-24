    public void SortingList(List<string> list,string keyword)
    		{
    			IEnumerable<string> filterLst = list.Where(s => s.StartsWith(keyword[0].ToString(), StringComparison.OrdinalIgnoreCase));
    
    			var result = filterLst.OrderBy(s => !s.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
    				 .ThenBy(s => !s.ToLower().Contains(keyword));
    
    			foreach (string s in result)
    			{
    				Console.WriteLine(s);
    			}
    
    		}
