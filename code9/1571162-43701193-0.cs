    try
    {
        Output.Text = TextEditor.Text.Split(new []{'+'}, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s.Trim())).Sum().ToString();
    }
    catch (Exception e)
    {
        Output.Text = "Wrong input!";
    }
