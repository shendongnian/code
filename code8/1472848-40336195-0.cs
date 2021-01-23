    public static IDisposable BeginSupress(this HtmlHelper htmlHelper, bool suppress)
    {
        StringBuilder stringBuilder = null;
        StringBuilder backupStringBuilder = null;
        return new DisposableHelper(
            () =>
            {
                if (suppress)
                {
                    stringBuilder = ((StringWriter)htmlHelper.ViewContext.Writer).GetStringBuilder();
                    backupStringBuilder = new StringBuilder(stringBuilder.Length).Append(stringBuilder);
                }
            },
            () =>
            {
                if (suppress)
                {
                    stringBuilder.Length = 0;
                    stringBuilder.Append(backupStringBuilder);
                }
            });
    }
