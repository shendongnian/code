        XmlDocument dom = new XmlDocument();
        dom.LoadXml("<Pricing><PriceGuide id=\"e4c3db5c\"><Name>Price Guide A</Name><Products><Product id=\"1\"><Name>Product 1</Name><Prices><Price><Region id=\"40\">Chicago</Region><PriceLow>48</PriceLow><PriceHigh>52</PriceHigh><UnitOfMeasure>MT</UnitOfMeasure></Price><Price><Region id=\"71\">Dallas</Region><PriceLow>45.5</PriceLow><PriceHigh>47</PriceHigh><UnitOfMeasure>MT</UnitOfMeasure></Price></Prices></Product><Product id=\"2\"><Name>Product 2</Name><Prices><Price><Region id=\"40\">Chicago</Region><PriceLow>48</PriceLow><PriceHigh>49</PriceHigh><UnitOfMeasure>MT</UnitOfMeasure></Price><Price><Region id=\"101\">Los Angeles </Region><PriceLow>43</PriceLow><PriceHigh>45</PriceHigh><UnitOfMeasure>MT</UnitOfMeasure></Price><Price><Region id=\"71\">Dallas</Region><PriceLow>45.5</PriceLow><PriceHigh>48.5</PriceHigh><UnitOfMeasure>MT</UnitOfMeasure></Price></Prices></Product></Products></PriceGuide></Pricing>");
        List<KeyValuePair<int, String>> result = FlattenXML(dom.DocumentElement, "", 0);
        var q = result.Where(c => c.Key == result.Max(b => b.Key)).Select(b => b.Value.Substring(0, b.Value.Length - 1)).ToArray();
        Console.WriteLine(String.Join(System.Environment.NewLine, q));
		private List<KeyValuePair<int, String>> FlattenXML(XmlElement node, String parent, int level)
        {
            List<KeyValuePair<int, String>> result = new List<KeyValuePair<int, String>>();
            String detail = "";
            if (node.HasAttribute("id"))
                parent += node.Attributes["id"].InnerText + ",";
            if (node.InnerText == node.InnerXml && node.InnerText != "")
            {
                parent += node.InnerText + ",";
            }
            foreach (XmlElement child in node.ChildNodes)
            {
                if (child.InnerText == child.InnerXml && child.InnerText != "")
                {
                    detail += child.InnerText + ",";
                    level++;
                }
                if (child.FirstChild != child.LastChild)
                {
                    List<KeyValuePair<int, String>> childResult = FlattenXML(child, parent + detail, level);
                    result.AddRange(childResult);
                }
            }
            result.Add(new KeyValuePair<int, String>(level, parent + detail));
            return result;
        }
