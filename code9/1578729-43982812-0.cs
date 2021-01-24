	public static int FindMaxIndex<T>( IEnumerable<T> source ) where T : IComparable<T>
	{
		using( var e = source.GetEnumerator() )
		{
			if( !e.MoveNext() ) return -1;
			
			T maxValue = e.Current;
			int maxIndex = 0;
			
			for( int i = 1; e.MoveNext(); ++i )
			{
				if( maxValue.CompareTo( e.Current ) < 0 )
				{
					maxIndex = i;
					maxValue = e.Current;
				}
			}
			
			return maxIndex;
		}
	}
