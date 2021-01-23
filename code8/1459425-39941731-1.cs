    public static InlineKeyboardMarkup InlineKeyboardMarkupMaker(Dictionary<int, string> items)
    {
         InlineKeyboardButton[][] ik = items.Select(item => new[]
         {
               new InlineKeyboardButton(item.Key, item.Value)
         }).ToArray();
         return new InlineKeyboardMarkup(ik);
    }
