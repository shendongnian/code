    public static void SetText(string text, TextDataFormat format)
    {
        if (text == null)
        {
            throw new ArgumentNullException("text");
        }
        if (!DataFormats.IsValidTextDataFormat(format))
        {
            throw new InvalidEnumArgumentException("format", (int)format, typeof(TextDataFormat));
        }
        Clipboard.SetDataInternal(DataFormats.ConvertToDataFormats(format), text);
    }
    [SecurityCritical]
    public static void SetDataObject(object data, bool copy)
    {
        SecurityHelper.DemandAllClipboardPermission();
        Clipboard.CriticalSetDataObject(data, copy);
    }
