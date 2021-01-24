    private Dictionary<Tuple<string, string>, IEnumerable<System.Drawing.Bitmap>> _assets;
    public IEnumerable<Bitmap> loadAssets(string character, string iconState)
    {
        return _assets[new Tuple<string, string>(character, iconState)];
    }
