    public void LogImage(object obj)
    {
        var prop = obj.GetType().GetProperties()[0];
        string name = prop.Name;
        Bitmap bitmap = (Bitmap)prop.GetValue(obj);
        LogImage(bitmap, name);
    }
