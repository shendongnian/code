    var raw = @"<NinjaTrader>
        <OpenWorkspaces>
            <OpenWorkspace>OldWorkspace1</OpenWorkspace>
            <OpenWorkspace>OldWorkspace2</OpenWorkspace>
        </OpenWorkspaces>
    </NinjaTrader>";
    var xdoc = XDocument.Parse(raw);
    List<string> newValues = new List<string>{"NewWorkspace1","NewWorkspace2","NewWorkspace3"};
    		
    var ow = xdoc.XPathSelectElement("//OpenWorkspaces");
    
    ow.Descendants("OpenWorkspace").Remove();
    ow.Add(newValues.Select(o => new XElement("OpenWorkspace", o)));
    Console.WriteLine(xdoc.ToString());
