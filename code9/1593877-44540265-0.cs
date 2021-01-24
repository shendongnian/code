    public string SetText(Control control)
    {
        text = control.Text;
        text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        return text;
    }
