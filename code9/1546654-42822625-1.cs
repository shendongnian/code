	void Main()
	{
		var config = new SomeConfiguration
		{
			Bugs = new BugList { Items = { "Bug1", "Bug2" } },
			Trees = new TreeList { Items = { "Tree1", "Tree2" } }
		};
		
		// Your config will work as normal.
		Debug.WriteLine(ToXml(config)); // <config> <bugs>.. <trees>..</config>
		// Your collections are now root-ed properly.
		Debug.WriteLine(ToXml(config.Bugs)); // <bugs><bug>Bug1</bug><bug>Bug2</bug></bugs>
		Debug.WriteLine(ToXml(config.Trees)); // <trees><tree>Tree1</tree><tree>Tree2</tree></trees>
	}
	
	public string ToXml<T>(T obj)
	{
		var ser = new XmlSerializer(typeof(T));
		var emptyNs = new XmlSerializerNamespaces();
		emptyNs.Add("","");
		using (var stream = new MemoryStream())
		{
			ser.Serialize(stream, obj, emptyNs);
			return Encoding.ASCII.GetString(stream.ToArray());
		}
	}
	
