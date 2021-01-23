    if (sourceList != null && sourceList.Count > 0)
    {
         destinationList.AddRange(sourceList);
    }
    else
    {
         //destinationList = sourceList;
         // If the sourceList is ever null it will make every subsequent call
         // destinationList fail with a NullReference exception.
         destinationList.Clear();
    }
