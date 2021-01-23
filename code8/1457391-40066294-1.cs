            private void IdentifyMatchingItems(ObservableCollection<GenericObject> groupedCollection)
        {
            foreach (var collectionObject in groupedCollection)
            {
                int x = collectionObject.Properties.Count;
                int propertyCount = x - 1;
                string masterValue = collectionObject.Properties[2].Value.ToString();
                //           string ObjectNotNull = collectionObject.Properties[propertyNumber].Value.ToString();
                for (int i = 2; i <= propertyCount; i++)
                {
                    if (collectionObject.Properties[i].Value.Equals(masterValue))
                    {
                        collectionObject.Properties[i].Latest = "yes";
                    }
                }
            }
        }
