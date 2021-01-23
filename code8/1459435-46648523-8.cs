                    public static IReplyMarkup CreateInlineKeyboardButton(Dictionary<string, string> buttonList, int columns)
        {
            int rows = (int)Math.Ceiling((double)buttonList.Count / (double)columns);
            InlineKeyboardButton[][] buttons = new InlineKeyboardButton[rows][];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = buttonList
                    .Skip(i * columns)
                    .Take(columns)
                    .Select(direction => new InlineKeyboardCallbackButton(
                        direction.Key, direction.Value
                    ) as InlineKeyboardCallbackButton)
                    .ToArray();
            }
            return new InlineKeyboardMarkup(buttons);
        }
