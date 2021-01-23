    assetsLibrary = new ALAssetsLibrary();
    photoAssets = new List<ALAsset>();
    
    assetsLibrary.Enumerate (ALAssetsGroupType.Album, (ALAssetsGroup group, ref bool stop) => {
        group.SetAssetsFilter (ALAssetsFilter.AllPhotos);
		group.Enumerate ((ALAsset asset, nint index, ref bool st) => {
            int notfound = Int32.MaxValue;
			if (asset != null && index != notfound) {
			    photoAssets.Add (asset);
            }
        });
    });
