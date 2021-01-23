            public static IReplyMarkup CreateInlineKeyboardButton(Dictionary<string, string> buttonList, int columns)
        {
                int rows = (int)Math.Ceiling((double)buttonList.Count / (double)columns);
                InlineKeyboardCallbackButton[][] buttons = new InlineKeyboardCallbackButton[rows][];
                int i = 0, j = 0;
                buttons[j] = new InlineKeyboardCallbackButton[columns];
                foreach (var item in buttonList)
                {
                    buttons[j][i] = new InlineKeyboardCallbackButton(item.Key, item.Value);
                    i++;
                    if (i == columns)
                    {
                        j++;
                        if (j != rows)
                            buttons[j] = new InlineKeyboardCallbackButton[columns];
                    }
                }
                return new InlineKeyboardMarkup(buttons);
            }
