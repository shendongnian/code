    public T FindAsset<T>(string assetName) {
        T match;
    
        foreach (AssetBundle bundle in assets) {
            if (bundle.Contains(assetName)) {
                match = bundle.LoadAsset<T>(assetName);
            }
        }
    
        return match;
    }
