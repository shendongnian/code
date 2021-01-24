    //using System.Linq;
    public static int UseLinq(int[] input)
	{
		return input
			.GroupBy( n => n )
			.Where( g => g.Count() %2 == 1)
			.Select( g => g.Key )
			.Single();
	}
