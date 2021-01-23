    public static class XObjectExtensions
    {
        public static IEnumerable<string> DumpXmlElementNames(this XDocument doc)
        {
			return doc.Root.DumpXmlElementNames();
        }
		public static IEnumerable<string> DumpXmlElementNames(this XElement root)
        {
            if (root == null)
                return Enumerable.Empty<string>();
            var startCount = root.AncestorsAndSelf().Count();
            return root.DescendantsAndSelf().Select(el => string.Format("{0}\"{1}\"",
                new string(' ', 2 * (el.AncestorsAndSelf().Count() - startCount)), el.Name.ToString()));
        }
	}
