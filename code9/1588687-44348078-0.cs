    if (receivedList.Count < AuthorFacets.Count)
    {
      AuthorFacets.RemoveAll(a=>!receivedList.Contains(a))
    }
    else
    {
      AuthorFactets.AddRange(receivedList.Where(r=> !AuthorFacets.Contains(r)))
    }
