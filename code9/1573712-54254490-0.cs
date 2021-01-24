		//
		//
		///<summary>Create a new array as concatenation of all given arrays.</summary>
		public static T[] Concatenate<T>( params T[][] args ) {
			if ( null == args ) return null;
			// Get argument lengths
			var count = args.Length;
			if ( 0 == count ) return null;
			var lengths = new int[ count ];
			// Compute all and total lengths
			var total = 0;
			for ( int i = 0; i < count; i++ ) {
				lengths[ i ] = null == args[ i ] ? 0 : args[ i ].Length;
				total += lengths[ i ];
			}
			if ( 1 > total ) return null;
			// Create target array
			T[] a = new T[ total ];
			// Copy all together
			total = 0;
			for ( int i = 0; i < count; i++ ) {
				if ( null != args[ i ] ) {
					args[ i ].CopyTo( a, total );
				}
				total += lengths[ i ];
			}
			return a;
		}
