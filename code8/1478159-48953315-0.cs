        private static void RemoveAllNamespaces(XElement element)
        {
            element.Name = element.Name.LocalName;
            foreach (var node in element.DescendantNodes())
            {
                var xElement = node as XElement;
                if (xElement != null)
                {
                    RemoveAllNamespaces(xElement);
                }
            }
        } 
