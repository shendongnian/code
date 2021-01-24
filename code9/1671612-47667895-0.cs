    public FontAwesome.WPF.FontAwesomeIcon GetUIFontAwesome(string strIcon)
    {
        FontAwesome.WPF.FontAwesomeIcon item;
        if (Enum.TryParse(strIcon, out item))
            return item;
        else 
            return FontAwesome.WPF.FontAwesomeIcon.None; 
    }
