    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete(IsError = true, Message = "A string is a sequence of characters, but is not intended to be shown as a list")]
    public static void ShowList(this string text)
    {
        throw new NotSupportedException();
    }
