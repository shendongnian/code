    private List<Bitmap> loadAssets(String character, String icon_state)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        result.Add(character, icon_state);
        return Character_Spreadsheet[result];
    }
