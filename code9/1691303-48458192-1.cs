    messages.SelectMany(outer => outer.Value.Select(inner => new
    {
       Column1 = outer.Key,
       Column2 = inner.Key,
       Column3 = string.Join(", ", inner.Value) 
    }); 
