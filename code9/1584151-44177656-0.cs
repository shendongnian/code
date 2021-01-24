    private static void ReplaceElementsWithAttributes()
    {
        string xmlData = @"<Dress>
                                <ID>001</ID>
                                <shirts>
                                    <product>
                                        <ID>345</ID>
                                        <Name>tee</Name>
                                        <Serial>5678</Serial>
                                    </product>
                                    <product>
                                        <ID>456</ID>
                                        <Name>crew</Name>
                                        <Serial>4566</Serial>
                                    </product>       
                                </shirts>
                                <pants>
                                    <product>
                                        <ID>123</ID>
                                        <Name>jeans</Name>
                                        <Serial>1234</Serial>
                                        <Color>blue</Color>
                                    </product>
                                    <product>
                                        <ID>137</ID>
                                        <Name>skirt</Name>
                                        <Serial>3455</Serial>
                                        <Color>black</Color>
                                    </product>
                                </pants>
                            </Dress>";
        var doc = XDocument.Parse(xmlData);
        var replaceElementTargets = new string[] { "shirts", "pants" };
        foreach (var target in replaceElementTargets)
        {
            var product = doc.Root.Elements(target).Elements("product").ToList();
            product.ForEach(p => p.Elements().ToList().ForEach(e => { p.SetAttributeValue(e.Name, e.Value); e.Remove(); }));
        }
        var outputXML = doc.ToString();
    }
