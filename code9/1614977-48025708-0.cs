    using (var key = Registry.ClassesRoot.OpenSubKey(@"Excel.Application\\CurVer"))
    {
        var defvalue = key?.GetValue("");
        if (defvalue != null)
        {
        }
    }
