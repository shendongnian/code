	public class MyComparer : IComparer<double>
	{
		public int Compare( double x, double y )
		{
			if( x < 0 )
			{
				if( y >= 0 ) return 1;
				return -x.CompareTo( y );
			}
			else
			{
				if( y < 0 ) return -1;
				return x.CompareTo( y );
			}
		}
        public static MyComparer Instance{ get; } = new MyComparer();
        private MyComparer() {}
	}
