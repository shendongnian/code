     string xml = @"
    <DBSimulatorConfigurations>
      <Configurations>
        <DBSimulatorConfiguration>
          <Key>Test1</Key>
          <Submit>0</Submit>
          <Amend>0</Amend>
          <Update>0</Update>
          <Delete>1</Delete>
        <ResponseTimeInSeconds>100</ResponseTimeInSeconds>
        </DBSimulatorConfiguration>
        <DBSimulatorConfiguration>
          <Key>Test2</Key>
          <Submit>0</Submit>
          <AutoUpdate>0</AutoUpdate>
          <Amend>0</Amend>
          <Update>0</Update>
          <Delete>1</Delete>
        <ResponseTimeInSeconds>100</ResponseTimeInSeconds>
        </DBSimulatorConfiguration>
        <DBSimulatorConfiguration>
        </DBSimulatorConfiguration>
      </Configurations> 
    </DBSimulatorConfigurations>";
    
    XDocument xdoc = XDocument.Parse(xml);
    //search for  all nodes with <DBSimulatorConfiguration> element
    var elements = xdoc.Root.Elements().Elements().Where(x => x.Name == "DBSimulatorConfiguration");
    //iterate through all those eleemnt
    foreach (var element in elements)
    {
    	//now find it's child named Submit
    	var submitElement = element.Elements().FirstOrDefault(x => x.Name == "Submit");
    	//if such element is found
    	if (submitElement != null)
    	{
    		//here you can change Submit element, like this:
    		// submitElement.Value = "abc";
    		//or you can check for something
    		if (submitElement.ElementsBeforeSelf().Any(x=> x.Name == "Key" && x.Value== "Test2"))
    		{
    			//this is submitElement which is after element named Key with value Test2
    			submitElement.Value = "some specific value";
    		}
    	}
    	else
    		element.Add(new XElement("Submit", 999));
    }
