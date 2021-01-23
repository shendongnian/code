	class Program
	{
		static void Main( String[] args )
		{
			var intCollection = new List<Int32>() { 16, 17, 4, 3, 5, 2 };
			var intResults = new List<Int32>();
			var currentMaxValue = Int32.MinValue;
			for ( Int32 i = intCollection.Count - 1; i >= 0; --i )
			{
				if ( intCollection[ i ] > currentMaxValue )
				{
					currentMaxValue = intCollection[ i ];
					intResults.Insert( 0, intCollection[ i ] );
				}
			}
			Console.WriteLine( "Successful elements are" );
			intResults.ForEach( i => Console.WriteLine( "{0}", i ) );
			Console.ReadKey();
		}
	}
