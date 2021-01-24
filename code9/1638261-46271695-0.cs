    class Compare : IEqualityComparer<Person>
    	{
    		public bool Equals(Person x, Person y)
    		{
    			if (x == null || y == null)
    			{
    				return false;
    			}
    			return x.ID == y.ID && x.IDSecond == y.IDSecond;
    		}
    
    		public int GetHashCode(Person obj)
    		{
    			return 1;
    		}
    	}
    
    	class FullCompare : IEqualityComparer<Person>
    	{
    		public bool Equals(Person x, Person y)
    		{
    			if (x == null || y == null)
    			{
    				return false;
    			}
    			return x.ID == y.ID && x.IDSecond == y.IDSecond && x.IDThird == y.IDThird;
    		}
    
    		public int GetHashCode(Person obj)
    		{
    			return 1;
    		}
    	}
    
    	class Person
    	{
    		public int ID { get; set; }
    		public int IDSecond { get; set; }
    		public int IDThird { get; set; }
    	}
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			IList<Person> lstOne = new List<Person>();
    			lstOne.Add(new Person()
    			{
    				ID = 1,
    				IDSecond = 2,
    				IDThird = 2
    			});
    			lstOne.Add(new Person()
    			{
    				ID = 2,
    				IDSecond = 3,
    				IDThird = 2
    			});
    
    			IList<Person> lstFinal = new List<Person>();
    			lstFinal.Add(new Person()
    			{
    				ID = 1,
    				IDSecond = 2,
    				IDThird = 2
    			});
    			lstFinal.Add(new Person()
    			{
    				ID = 3,
    				IDSecond = 4,
    				IDThird = 2
    			});
    			lstFinal.Add(new Person()
    			{
    				ID = 4,
    				IDSecond = 5,
    				IDThird = 2
    			});
    
    
    			var a = lstFinal.Except(lstOne, new Compare());
    			var b = lstFinal.Except(lstOne, new FullCompare());
    			a.ToList().ForEach(s => Console.WriteLine(s.ID));
    			b.ToList().ForEach(s => Console.WriteLine(s.ID));
    
    			Console.ReadLine();
    			//Console.WriteLine();
    		}
    	}
