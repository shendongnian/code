    foreach (var item in allNegatives)
    {
      for (int index = _items.Count() - 1; index >= 0; --index)
      {
          if (_items[index].Title.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0)
          {
            _items.RemoveAt(index);
          }
       }
    }
