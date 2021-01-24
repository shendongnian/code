    foreach (XElement a in resx.Root.Descendants(ns + "root"))
    {
        if (a.Elements(ns + "parentofelement1").Any())
        {
            IEnumerable<XElement> axl = a.Descendants(ns + "parentofelement1");
            foreach (var axc in axl.Elements())
            {
                idnum = 0;
                IEnumerable<XElement> exl = a.Descendants(ns + "element1");
                foreach (var elex in exl)
                {
                    //  Now we can put in a breakpoint and see if we really have 
                    //  the attribute and what's in it, before we try to parse it.
                    var attr = elex.Attribute("idnum");
                    idnum = int.Parse(attr.Value);
                    //do more stuff
                }
            }
        }
        if (a.Elements(ns + "parentofelement2").Any())
        {
            IEnumerable<XElement> bxl = a.Descendants(ns + "parentofelement2");
            foreach (var bxc in bxl.Elements())
            {
                idnum = 0;
                IEnumerable<XElement> fxl = a.Descendants(ns + "element2");
                foreach (var elfx in fxl)
                {
                    var attr = elfx.Attribute("idnum");
                    idnum = int.Parse(attr.Value);
                    // do more stuff
                }
            }
        }
    }
