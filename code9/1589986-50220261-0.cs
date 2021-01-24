    private Bitmap[] GetResourceImages(out String[] names)
    {
        PropertyInfo[] props = typeof(Properties.Resources).GetProperties(BindingFlags.NonPublic | BindingFlags.Static)
            .Where(prop => prop.PropertyType == typeof(Bitmap)).ToArray();
        Bitmap[] images = new Bitmap[props.Length];
        names = new String[props.Length];
        for(Int32 i = 0; i < props.length; i++)
        {
            images[i] = prop.GetValue(null, null) as Bitmap;
            names[i] = prop.Name;
        }
        return images;
    }
