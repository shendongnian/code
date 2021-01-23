    public class CsvFormatter
    {
    	public string Format(IEnumerable<Person> persons)
    	{
    		var sb = new StringBuilder();
    
    		sb.AppendLine("FirstName,LastName,Username");
    		
    		foreach(var person in persons)
    		{
    			sb.Append(person.Firstname + ",");
    			sb.Append(person.Lastname + ",");	
    			sb.Append(person.Username);
    			
    			sb.AppendLine();
    		}
    		
    		return sb.ToString().Trim();
    	}
    }
