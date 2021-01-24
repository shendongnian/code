    var ans = ByteStream.Aggregate(new List<List<byte>>(), (sa, b) => {
    	if (b == 0 || sa.Count == 0)
	    	sa.Add(new List<byte>());
		if (b != 0)
		    sa[sa.Count-1].Add(b);
    	return sa;
	});
    foreach (var d in ans.Select(bl => Encoding.UTF8.GetString(bl.ToArray())))
        Console.WriteLine(d);
