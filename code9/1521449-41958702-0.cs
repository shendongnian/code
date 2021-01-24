    var q = from original in originalShapes
            join edited in editedShapes on original.Id equals edited.Id
            select new
            {
               original,
               edited
            };
    
    foreach(var item in q)
    {
        if (item.original.TextFrame.TextRange.Font.Color.RGB != item.edited.TextFrame.TextRange.Font.Color.RGB)
        {
           item.original.TextFrame2.TextRange.Font.StrikeThrough.ToString();
        }
    }
