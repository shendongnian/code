    interface IMyStorage
    {
        ImageInfo SaveImage(ImageData);
    }
    
    class RootData
    {
        ...
        RootInfo SaveTo(IMyStorage storage);
    }
    
    ...
    
    class ImageData
    {
        ...
        ImageInfo SaveTo(IMyStorage storage)
        {
            return storage.SaveImage(this);
        }
    }
