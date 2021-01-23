    var all_elements = xmldoc.DocumentElement.SelectNodes("//catalog/book/author");
            foreach(XmlNode sub_elements in all_elements)
            {
                if(sub_elements.InnerText != "")
                {
                    string answer = sub_elements.InnerText;
                }
                else
                {
                    //null text
                }
            }
