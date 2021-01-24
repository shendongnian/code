            // use temporary variable to increase performance of item.Element, I'm not sure that all 'Obj' element contains 'Id'
            XElement temp = null;
            var values = doc.Descendants("Obj")
                .Where(item => (temp = item.Element("Id")) != null && temp.Value == "12345")
                .Descendants("NameValuePair")
                .ToLookup(o => o.Element("Name"), o => o.Element("Value"));
            foreach (var valuesByProp in values)
            {
                foreach (var prop in valuesByProp)
                {
                    Console.WriteLine($"{valuesByProp.Key.Value}, {prop.Value}");
                }
            }
