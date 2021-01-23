            static void Main(string[] args)
            {
                var xml1 = XElement.Parse(@"<function>
        <subfunction id=""s1"" value=""s1"">
            <display id=""1"" value=""a""></display>
            <display id=""2"" value=""b""></display>
            <display id=""3"" value=""c""></display>
            <display id=""4"" value=""d""></display>
        </subfunction>
    </function>");
                var xml2 = XElement.Parse(@"<function>
        <subfunction id=""s1"" some-value=""other"">
            <display id=""1"" another-data=""something""></display>
            <display id=""2"" another-data=""something""></display>
            <display id=""3"" another-data=""something""></display>
            <display id=""4"" another-data=""something""></display>
        </subfunction>
    </function>");
                var xml3 = Merge(xml1, xml2);
                Console.WriteLine(xml3.ToString());
                Console.ReadLine();
            }
    
            private static XElement Merge(XElement thisElement, XElement otherElement)
            {
                if(thisElement.Name == otherElement.Name)
                {
                    var merged = new XElement(thisElement.Name);
                    merged.ReplaceAttributes(Attributes(thisElement, otherElement).ToArray());
                    var thisChildren = thisElement.Elements().Where(e => e.Attribute("id") != null);
                    if(thisChildren.Any())
                    {
                        var children = thisChildren.Select(thisChild => {
                            var otherChild = otherElement
                                .Elements()
                                .Where(e => e.Attribute("id") != null && e.Attribute("id").Value == thisChild.Attribute("id").Value)
                                .FirstOrDefault();
                            if(otherChild != null)
                            {
                                return Merge(thisChild, otherChild);
                            }
                            return null;
                        }).Where(child => child != null);
                        merged.Add(children.ToArray());
                    }
                    return merged;
                }
                return null;
            }
    
            private static IEnumerable<XAttribute> Attributes(XElement thisElement, XElement otherElement)
            {
                return thisElement
                    .Attributes()
                    .Concat(otherElement.Attributes())
                    .GroupBy(a => a.Name)
                    .Select(g => g.FirstOrDefault())
                    .Where(a => a != null);
            }
