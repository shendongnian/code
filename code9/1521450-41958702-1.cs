    var q = from original in originalShapes
            join editedTmp in editedShapes on original.Id equals editedTmp.Id into g
            from edited in g.DefaultIfEmpty()
            select new
            {
               original,
               edited
            };
    
    foreach(var item in q)
    {
        //item.edited might be null if no matching original was found.
        if (item.edited == null || item.original.TextFrame.TextRange.Font.Color.RGB != item.edited.TextFrame.TextRange.Font.Color.RGB)
        {
           item.original.TextFrame2.TextRange.Font.StrikeThrough.ToString();
        }
    }
