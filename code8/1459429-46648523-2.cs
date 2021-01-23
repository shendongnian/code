            public static IReplyMarkup CreateInlineKeyboardButton(Dictionary<string, string> buttonList, int columns)
        {
                int rows = (int)Math.Ceiling((double)buttonList.Count / (double)columns);
                InlineKeyboardButton[][] buttons = new InlineKeyboardButton[rows][];
                int i = 0, j = 0;
                buttons[j] = new InlineKeyboardButton[columns];
                foreach (var item in buttonList)
                {
                    buttons[j][i] = new InlineKeyboardCallbackButton(item.Key, item.Value);
                    i++;
                    if (i == columns)
                    {
                        j++;
                        if (j != rows)
                            buttons[j] = new InlineKeyboardButton[columns];
                    }
                }
                return new InlineKeyboardMarkup(buttons);
            }
