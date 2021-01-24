    if (rblType.Enabled == false)
    {
        // rblType.CssClass = "disabledcss";
        rblType.CssClass = rblType.CssClass.Replace("enabledcss", "disabledcss");
    }
    else
    {
        // rblType.CssClass = "enabledcss";
        rblType.CssClass = rblType.CssClass.Replace("disabledcss", "enabledcss");
    } 
