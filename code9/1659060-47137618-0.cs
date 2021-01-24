    public static bool HasPrintToVerb(string filename)
    {
        try
        {
            var ext = Path.GetExtension(filename);
            var value = Registry.GetValue("HKEY_CLASSES_ROOT\\" + ext, string.Empty, null);
            var printToValue = Registry.GetValue(string.Format(@"HKEY_CLASSES_ROOT\{0}\shell\Printto\command", value), string.Empty, null);
            return printToValue != null;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
