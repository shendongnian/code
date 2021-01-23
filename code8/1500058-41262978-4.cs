    public static Image FromFile(String filename,
                                 bool useEmbeddedColorManagement) {
        if (!File.Exists(filename)) {
            IntSecurity.DemandReadFileIO(filename);
            throw new FileNotFoundException(filename);
        }
 
        // GDI+ will read this file multiple times.  Get the fully qualified path
        // so if our app changes default directory we won't get an error
        filename = Path.GetFullPath(filename);
 
        IntPtr image = IntPtr.Zero;
        int status;
        
        if (useEmbeddedColorManagement) {
            status = SafeNativeMethods.Gdip.GdipLoadImageFromFileICM(filename, out image);
        }
        else {
            status = SafeNativeMethods.Gdip.GdipLoadImageFromFile(filename, out image);
        }
        
        if (status != SafeNativeMethods.Gdip.Ok)
            throw SafeNativeMethods.Gdip.StatusException(status);
 
        status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, image));
 
        if (status != SafeNativeMethods.Gdip.Ok) {
            SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, image));
            throw SafeNativeMethods.Gdip.StatusException(status);
        }
 
        Image img = CreateImageObject(image);
 
        EnsureSave(img, filename, null);
 
        return img;
    }
