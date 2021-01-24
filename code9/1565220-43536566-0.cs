	public class XMLComparer : IEqualityComparer<XNode>
	{
		public bool Equals(XNode e1, XNode e2)
		{
			if (!(e1 is XElement)) return true;
			if (!(e2 is XElement)) return false;
			var el1 = e1 as XElement;
			var el2 = e2 as XElement;
			return Tuple.Create(el1.Name, el1.Value).Equals(Tuple.Create(el2.Name, el2.Value));
		}
		public int GetHashCode(XNode n)
		{
			if (!(n is XElement)) return 0;
			var el = n as XElement;
			return Tuple.Create(el.Name, el.Value).GetHashCode();
		}
	}
	public class XMLDifference
	{
		public bool IsNew { get; set; }
		public XElement Node { get; set; }
	}
	public class XMLDifferenceComparer
	{
		public List<XMLDifference> GetDifferences(string original, string changed)
		{
			List<XMLDifference> ret = new List<XMLDifference>();
			var originalDoc = XDocument.Parse(original);
			var changedDoc = XDocument.Parse(changed);
			//Get differences that are present in new xml version
			var differences = changedDoc.Root.Descendants().Except(originalDoc.Root.Descendants(), new XMLComparer());
			ret.AddRange(GetList(differences, true));
			//Get differences that have changed since the old xml version
			var oldValues = originalDoc.Root.Descendants().Except(changedDoc.Root.Descendants(), new XMLComparer());
			ret.AddRange(GetList(oldValues, false));
			return ret;
		}
		private List<XMLDifference> GetList(IEnumerable<XNode> nodes, bool isNew)
		{
			List<XMLDifference> ret = new List<XMLDifference>();
			foreach (XNode d in nodes)
			{
				var diff = new XMLDifference();
				diff.IsNew = isNew;
				var el = d as XElement;
				diff.Node = el;
				ret.Add(diff);
			}
			return ret;
		}
	}
