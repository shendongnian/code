    private static void ShowHideEmailContents(?? hl, ?? txt, string email, string format, string tooltip, bool isReadOnly)
    {
        if (isReadOnly)
        {
            hl.NavigateUrl = string.Format(format, email);
            hl.Text = email;
            ...
        }
        else
        {
            txt.Text = email;
        }
    }
