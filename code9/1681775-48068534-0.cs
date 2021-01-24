    public static string GetPath(this IWpfTextView textView) {
        textView.TextBuffer.Properties.TryGetProperty(typeof(IVsTextBuffer), out IVsTextBuffer bufferAdapter);
        var persistFileFormat = bufferAdapter as IPersistFileFormat;
        if (persistFileFormat == null) {
            return null;
        }
        persistFileFormat.GetCurFile(out string filePath, out _);
        return filePath;
    }
