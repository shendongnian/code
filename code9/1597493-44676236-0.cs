	namespace ConsoleApp3.Domain
	{
		public class Element1
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element2
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element3
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element4
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element5
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element6
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element7
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element8
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element9
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Element10
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Category1
		{
			public Element1 Element1 { get; set; }
			public Element2 Element2 { get; set; }
			public Element3 Element3 { get; set; }
			public Element4 Element4 { get; set; }
			public Element5 Element5 { get; set; }
			public Element6 Element6 { get; set; }
			public Element7 Element7 { get; set; }
			public Element8 Element8 { get; set; }
			public Element9 Element9 { get; set; }
			public Element10 Element10 { get; set; }
		}
		public class Short
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Medium
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Long
		{
			public string url { get; set; }
			public string name { get; set; }
		}
		public class Category2
		{
			public Short @short { get; set; }
			public Medium medium { get; set; }
			public Long @long { get; set; }
		}
		public class Packs
		{
			public Category1 category1 { get; set; }
			public Category2 category2 { get; set; }
		}
		public class RootObject
		{
			public Packs packs { get; set; }
		}
	}
