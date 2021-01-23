    string[] separators = new string[] { "-", ".", "/" };
    void DetectCurrentSeparator(string dbDateFormat)
    {
        for (int i = 0; i < separators.Length; i++)
        {
            if (dbDateFormat.IndexOf(separators[i]) >= 0)
            {
                // Assuming the above array corresponds with the order of the divider combobox
                combobox_DateFormatDivider.SelectedIndex = i;
                break;
            }
        }
    }
