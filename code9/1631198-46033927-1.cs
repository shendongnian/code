    public static Child Child1 { get; set; } = new Child
    		{
    			Name = "Child1"
    		};
    
    		public static Parent Parent1 { get; set; } = new Parent
    		{
    			Name = "Parent1"
    		};
    
    		public static Parent Parent2 { get; set; } = new Parent
    		{
    			Name = "Parent2"
    		};
    
    		private static void Main(string[] args)
    		{
    			var result = GetData(Child1, new List<Parent> {Parent1, Parent2});
    			Console.WriteLine(result);
    		}
    
    		/// <summary>
    		///     This is the magic: convert dictionary of properties to object with preperties
    		/// </summary>
    		public static ExpandoObject DicTobj(Dictionary<string, object> properties)
    		{
    			var eo = new ExpandoObject();
    			var eoColl = (ICollection<KeyValuePair<string, object>>) eo;
    
    			foreach (var childColumn in properties)
    				eoColl.Add(childColumn);
    
    			return eo;
    		}
    
    		public static string GetData(Child model, List<Parent> parents)
    		{
    			var childColumns = GetColumns(model);
    			dynamic child = DicTobj(childColumns);
    
    			var parentsList = new List<object>();
    			foreach (var parent in parents)
    			{
    				var parentColumns = GetColumns(parent);
    				var parentObj = DicTobj(parentColumns);
    				parentsList.Add(parentObj);
    			}
    
    			child.Parents = parentsList;
    
    			return JsonConvert.SerializeObject(child);
    		}
    
    
    		/// <summary>
    		///     this is STUB method for example
    		///     I change return type from string[] to Dictionary[columnName,ColumnValue], becouse u need not only column names, but
    		///     with it values, i gues. If not, look commented example at the end of this method
    		/// </summary>
    		public static Dictionary<string, object> GetColumns(object model)
    		{
    			var result = new Dictionary<string, object>();
    			if (model == Child1)
    			{
    				result.Add("Id", "1");
    				result.Add("Name", "Child1");
    				result.Add("Location", "SomeLocation");
    			}
    
    			if (model == Parent1)
    			{
    				result.Add("Id", "2");
    				result.Add("Name", "Parent1");
    				result.Add("SomeProperty1", "SomeValue1");
    			}
    
    			if (model == Parent2)
    			{
    				result.Add("Id", "3");
    				result.Add("Name", "Parent1");
    				result.Add("SomeProperty3", "SomeValue2");
    			}
    
    			//if u have only columNames and dont need values u can do like this
    			//var columns = new[] {"Id", "Name", "SomeProperty1"};//this u get from DB
    			//return columns.ToDictionary(c => c, c => new object());
    
    			return result;
    		}
    	}
    
    	public class Child
    	{
    		public string Name { get; set; } // Contains Employee
    		//Other properties and info related to process sql query and connection string
    	}
    
    	public class Parent
    	{
    		public string Name { get; set; } // Contains Company,Department.
    
    		public string SqlQuery { get; set; } // query related to Company and Department.
    		//Other properties and info related to connection string
    	}
