            var values = doc.Descendants("Obj")
                .ToLookup(o => o.Element("Id").Value, 
                    o => o.Descendants("NameValuePair").ToLookup(p => p.Element("Name").Value, p => p.Element("Value").Value));
            foreach (var groupById in values)
            {
                foreach (var groupByProp in groupById)
                {
                    foreach (var valuesByProp in groupByProp)
                    {
                        foreach (var value in valuesByProp)
                        {
                            Console.WriteLine($"{groupById.Key}, {valuesByProp.Key}, {value}");
                        }
                    }
                }
            }
