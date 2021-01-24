	public class B : IStructEnumerable<object, BE>
	{
		public BE GetEnumerator()
		{
			return new BE();
		}
	}
		
	public struct BE : IStructEnumerator<object>
	{
		public object Current {
			get {
				throw new NotImplementedException();
			}
		}
		
		public bool MoveNext()
		{
			throw new NotImplementedException();
		}
		
		public void Reset()
		{
			throw new NotImplementedException();
		}
	}
	
	public interface IStructEnumerable<TItem, TEnumerator> where TEnumerator : struct, IStructEnumerator<TItem>
	{
		TEnumerator GetEnumerator();
	}
	
	public interface IStructEnumerator<TItem>
	{
		TItem Current {get;}
		bool MoveNext();
		void Reset();
	}
	
	public static void TestEnumerator<TEnumerable, TEnumerator>(TEnumerable b) where TEnumerable : IStructEnumerable<object, TEnumerator> where TEnumerator : struct, IStructEnumerator<object>
	{
		foreach(object obj in b)
		{
			
		}
	}
