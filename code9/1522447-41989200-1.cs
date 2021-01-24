    if (xElementCollection.Count != xDocumentCollection.Count)
    {
      bCompare = false;
    }
    else
    {
       bCompare = true;
       for (int x = 0, y = 0; 
         x < xElementCollection.Count && y < xDocumentCollection.Count; x++, y++)
       {
         if (!XNode.DeepEquals(xElementCollection[x], xDocumentCollection[y]))
           bCompare = false;
       }
    }
