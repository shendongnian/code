    items.TakeWhile(item => item.Order != 5 || item.Type != "General").Concat(
        items.SkipWhile(item => item.Order != 5 || item.Type != "General")
            .TakeWhile(item =>  item.Order == 5 && item.Type == "General")
            .OrderBy(item => item.Date)).Concat(
        items.SkipWhile(item => item.Order != 5 || item.Type != "General")
            .SkipWhile(item => item.Order == 5 && item.Type == "General"))
