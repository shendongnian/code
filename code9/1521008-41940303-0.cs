    if (m.Msg == WM_HOTKEY)
    {
        string result = string.Empty;
        string ARMguid = Clipboard.GetText();
        string[] lines = ARMguid.Split('\n');
        foreach(var line in lines)
            result += "\"" + ARMguid + "\",\n";
        Clipboard.SetText(result);
    }
