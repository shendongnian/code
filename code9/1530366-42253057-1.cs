	string xml = @"
	<VariableCollection>
	    <Variable Name=""Level1"">
	         <Variable Name=""Level2"">
	               <Variable Name=""Level3"">
	                   <Variable Name=""Level4""/>
	               </Variable>
	         </Variable>
	    </Variable>
	    <Variable Name=""Level1"">
	          <Variable Name=""Level2"">
	               <Variable Name=""Level3""/>
	          </Variable>
	    </Variable>
	    <Variable Name=""Level1"">
	          <Variable Name=""Level2""/>
	    </Variable>
	</VariableCollection>
	";
	
	var root  = XElement.Parse(xml);
	
	var stringList = new List<string>();
	foreach (var child in root.Elements())
	{
		string value = child.DescendantsAndSelf()
			.Select(i => i.Attribute("Name").Value)
			.Aggregate((a, b) => a + "." + b);
			
		stringList.Add(value);
	}
	
	foreach (var str in stringList)
		Console.WriteLine(str.ToString());
