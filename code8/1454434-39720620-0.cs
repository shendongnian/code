        var list = new List<TextAndMessage>()
        {
            new TextAndMessage {TextToCompare = "Home", Message = "Home in Home Menu is missing."},
            new TextAndMessage {TextToCompare = "Users", Message = "Home in Home Menu is missing."}
        };
        var sb = new StringBuilder();
        foreach (var item in list)
        {
            if (!richTextBox1.Text.Contains(item.TextToCompare))
            {
                sb.Append(item.Message);
            }
        }
    //Assigning at the end, as you might falsely check that the string is contained in textbox, that has come from one of the messages.
        result_show.richTextBox1.Text = sb.ToString();
