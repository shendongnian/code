    using (var xr = XmlReader.Create(fileName))
    {
        while (xr.Read() && success)
        {
            if (xr.NodeType != XmlNodeType.Element)
                continue;
            switch (xr.Name)
            {
                case "A":
                    {
                        // ReadSubtree() positions the reader at the EndElement of the element read, so the 
                        // next call to Read() moves to the next node.
                        using (var subReader = xr.ReadSubtree())
                        {
                            var doc = XDocument.Load(subReader);
                            GetDetails(doc);
                        }
                    }
                    break;
            }
        }
    }
