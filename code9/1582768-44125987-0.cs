	public class CompareImageName : IComparer<string>
	{
	    public int Compare(string x, string y)
	    {
	        if (x == null || y == null) return 0;
			
			var regex = new Regex(@"/(((?<prefix>\w*)_)|)((?<number>\d+))\.jpg$");
			
			var mx = regex.Match(x);
			var my = regex.Match(y);
			
			var r = mx.Groups["prefix"].Value.CompareTo(my.Groups["prefix"].Value);
			if (r == 0)
			{
				r = int.Parse(mx.Groups["number"].Value).CompareTo(int.Parse(my.Groups["number"].Value));
			}
	        return r;
	    }
	}
