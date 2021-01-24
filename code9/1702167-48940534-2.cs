        private bool ReplaceId(XDocument doc, string id, string newValue)
        {
            var ns = doc.Root.GetDefaultNamespace();
            var assetElements = doc.Descendants(ns + "Asset");
            var result = false;
            foreach (var element in assetElements)
            {
                var idElement = element.Descendants(ns + "Id").First();
                if (!idElement.Value.Equals(id))
                    continue;
                // for xml model #1
                SetNewValue(element, ns + "Path", newValue);
                // for xml model #2
                SetNewValue(element, ns + "OriginalFileName", newValue);
                
                result = true;
            }
            
            return result;
        }
