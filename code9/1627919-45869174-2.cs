            // use temporary variable to increase performance of item.Element, I'm not sure that all 'Obj' element contains 'Id'
            XElement idElement = null;
            var values = doc.Descendants("Obj")
                .Where(item => (idElement = item.Element("Id")) != null && idElement.Value == "12345")
                .Descendants("NameValuePair")
                .ToLookup(o => o.Element("Name").Value, o => new { Id = idElement.Value, Value = o.Element("Value").Value });
            foreach (var valuesByProp in values)
            {
                foreach (var prop in valuesByProp)
                {
                    Console.WriteLine($"{prop.Id}, {valuesByProp.Key}, {prop.Value}");
                }
            }
