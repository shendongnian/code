    public static Bitmap getBitmapFromAssemblyPath(string assemblyPath, string resourceId) {
        Assembly assemb = Assembly.LoadFrom(assemblyPath);
        Stream stream = assemb.GetManifestResourceStream(resourceId);
        Bitmap bmp = new Bitmap(stream);
        return bmp;
    }
