       private void GetNextChildren(HashSet<XmlSchemaElement> searchedElements, List<XmlSchemaElement> allChildren, string dataType, string elementName, string parentName = "")
        {
            try
            {
                foreach (XmlSchemaElement e in allChildren)
                {
                    if (searchedElements.Contains(e) == false)
                    {
                        searchedElements.Add(e);
                       // Search for it
                       // GetNextChildren(searchedElements, ....);
                    }
                }
            }
            catch (Exception ex)
            { Debug.WriteLine("GetNextChildren: " + ex.Message); }
        }
