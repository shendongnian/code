	List<string> SegmentName = new List<string>();
	SegmentName.Add("A");
	SegmentName.Add("A");
	SegmentName.Add("B");
	SegmentName.Add("B");
	SegmentName.Add("C");
	List<string> newlist = SegmentName.GroupBy(x => x).Where(g => g.Count() <= 1).Select(y => y.Key).ToList();
