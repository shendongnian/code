    string xml = @"<Employees xmlns=""http://company.com/schemas"">
    	<Employee>
    		<FirstName>name1</FirstName>
    		<LastName>surname1</LastName>
    	</Employee>
    	<Employee>
    		<FirstName>name2</FirstName>
    		<LastName>surname2</LastName>
    	</Employee>
    	<Employee>
    		<FirstName>name3</FirstName>
    		<LastName>surname3</LastName>
    	</Employee>
    </Employees>
    ";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoXmlReader.LoadText(xml)
    	)
    {
    	using (var w = new ChoJSONWriter(sb))
    		w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());
