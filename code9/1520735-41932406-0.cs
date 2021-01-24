    protected void Page_Load(object sender, EventArgs e)
    {
        string theText = "some_very_long_text_here_that_is_too_long_to_fit_nicely_in_the_ui";
        test.Text = LimitText(theText, 15);
        test.ToolTip = theText;
    }
    public string LimitText(object input, int nrChars)
    {
        string inputAsString = input as string;
        if (inputAsString == null)
            return "";
        if (inputAsString.Length <= nrChars)
            return inputAsString;
        return inputAsString.Substring(0, nrChars - 1) + "…";
    }
