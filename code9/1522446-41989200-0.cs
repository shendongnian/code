    if (xElementcollection.Count != xDocumentCollection.Count)
    {
      bCompare = false;
    }
    else
    {
       bCompare = true;
       for (int x = 0, y = 0; 
         x < xElementCollection.Count && y < xDocumentCollection.Count; x++, y++)
       {
         if (!xElementCollection[x].DeepEquals(xDocumentCollection[y]))
           bCompare = false;
       }
    }
