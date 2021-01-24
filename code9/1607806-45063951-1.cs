            var nodeList = xmlDoc.GetElementsByTagName("Barcode");
            if (nodeList != null)
            {
                if (nodeList.Count > 0)
                {
                    var element = nodeList[0];
                    string value = element.InnerText;
                }
            }
