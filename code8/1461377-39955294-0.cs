                string xml =
                "<Root>" +
                    "<Style Name=\"TextBox2\" Type=\"TEXT\">" +
                        "<Alignment>LEFT</Alignment>" +
                        "<BorderColor>blue</BorderColor>" +
                        "<BorderStyle>Solid</BorderStyle>" +
                        "<BackGroundColor>red</BackGroundColor>" +
                        "<Options>VISIBLE</Options>" +
                        "<TextColor>Black</TextColor>" +
                        "<TextSize>10</TextSize>" +
                        "<MaxCharacterLength>50</MaxCharacterLength>" +
                    "</Style>" +
                "</Root>";
                XDocument doc = XDocument.Parse(xml);
                var style = doc.Descendants("Style").Where(x => (string)x.Attribute("Name") == "TextBox2").Select(x => new
                {
                    type = (string)x.Attribute("Type"),
                    alignment = (string)x.Element("Alignment"),
                    borderColor = (string)x.Element("BorderColor"),
                    borderStyle = (string)x.Element("BorderStyle"),
                    background = (string)x.Element("BackGroundColor"),
                    options = (string)x.Element("Options"),
                    textColor = (string)x.Element("TextColor"),
                    textSize = (string)x.Element("TextSize"),
                    maxCharacters = (int)x.Element("MaxCharacterLength"),
                }).FirstOrDefault();
