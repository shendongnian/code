    public Bitmap(String filename) {
        IntSecurity.DemandReadFileIO(filename);
 
        // GDI+ will read this file multiple times.  Get the fully qualified path
        // so if our app changes default directory we won't get an error
        filename = Path.GetFullPath(filename);
 
        IntPtr bitmap = IntPtr.Zero;
 
        int status = SafeNativeMethods.Gdip.GdipCreateBitmapFromFile(filename, out bitmap);
 
        if (status != SafeNativeMethods.Gdip.Ok)
            throw SafeNativeMethods.Gdip.StatusException(status);
 
        status = SafeNativeMethods.Gdip.GdipImageForceValidation(new HandleRef(null, bitmap));
 
        if (status != SafeNativeMethods.Gdip.Ok) {
            SafeNativeMethods.Gdip.GdipDisposeImage(new HandleRef(null, bitmap));
            throw SafeNativeMethods.Gdip.StatusException(status);
        }
 
        SetNativeImage(bitmap);
 
        EnsureSave(this, filename, null);
    }
