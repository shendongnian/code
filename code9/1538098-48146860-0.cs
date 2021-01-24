    private void PasteStyle(object sender, EventArgs e)
    {
        if (_CopiedStyle != null)
        {
            var toggleButton = Control as ZToggleButton;
            if (toggleButton != null)
            {
                toggleButton.Style.FromStyle(_CopiedStyle);
            }
            else
            {
                (Control as ZControl).Style.FromStyle(_CopiedStyle);
            }
        }
    }
    private void CopyStyle(object sender, EventArgs e)
    {
        var toggleButton = Control as ZToggleButton;
        if (toggleButton != null)
        {
            _CopiedStyle = toggleButton.Style;
        }
        else
        {
            _CopiedStyle = (Control as ZControl)?.Style;
        }
    }
