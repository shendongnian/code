    using System.Linq;
    using System.Diagnostics;
    ...
	var words = value.Split(' ');
	var groupedByLength = words.GroupBy(w => w.Length).OrderBy(x => x.Key);
	foreach (var grp in groupedByLength)
	{
		Debug.WriteLine(string.Format("{0} letter words: {1}", grp.Key, grp.Count()));
	}
