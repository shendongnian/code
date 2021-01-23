	public class FixedSortedArray<T>
		where T : new()
	{
		T[] _array;
		
		IComparer<T> _comparer;
		
		int _unused;
		
		public FixedSortedArray(int size, IComparer<T> cmp = null)
		{
			_array = new T[size];
			_comparer = cmp ?? Comparer<T>.Default;
			_unused = size;
	    }
	
		public bool Add(T item)
		{
			if (_unused > 0)
	        {
				var pos = _unused-1;
				for (int i = _unused; i < _array.Length; ++i)
				{
					var cmp = _comparer.Compare(item, _array[i]);
					if (cmp < 0)
					{
						_array[i-1] = _array[i];
					}
					else
					{
						pos = i-1;
						break;
					}
				}
				_array[pos] = item;
				--_unused;
	
			}
			else
			{
				var cmp = _comparer.Compare(item, _array[0]);
				if (cmp < 0)
				{
					int pos = 0;
					for (int i = 1; i < _array.Length; ++i)
					{
						cmp = _comparer.Compare(item, _array[i]);
						if (cmp < 0)
						{
							_array[i - 1] = _array[i];
							pos = i;
						}
						else
						{
							break;
						}
					}
					if (pos >= 0)
						_array[pos] = item;
				}
			}
	
			return true;
		}
	
		public T[] GetArray()
		{
			return _array;
		}
	
	}
	
	class ZipDist
	{
		public Zip Zip;
		public double Distance;
	}
	
	class ZipDistCOmparer : IComparer<ZipDist>
	{
		public int Compare(ZipDist lhs, ZipDist rhs)
		{
			return lhs.Distance.CompareTo(rhs.Distance);
		}
	}
	private static ZipDist[] FindClosest(Zip myZip)
	{
		var closestList = new FixedSortedArray<ZipDist>(5, new ZipDistCOmparer());
	
		foreach (var zip in ZipCodes.Where(x => x != myZip))
		{
			//Haversine magic returns distance (double) in km
			var dist = Haversine(myZip.Location, zip.Location);
			closestList.Add(new ZipDist { Zip = zip, Distance = dist});
		}
	
		return closestList.GetArray();
	}
	
	// Stuff I needed to add to get it to compile
	public class Zip
	{
		public string Location;
	}
	
	static public Zip[] ZipCodes;
	
	static double Haversine(string lhs, string rhs) { return 0.0; }
	
 
