	var newsDatas = xdoc.Descendants("new")
	                .Select(
	                    element =>
	                        new 
	                        {
	                            Company = element.Element("Company").Value,
	                            DateTime = element.Element("DateTime").Value,
	                            Message = element.Element("Message").Value,
	                            Node = element
	                        });
