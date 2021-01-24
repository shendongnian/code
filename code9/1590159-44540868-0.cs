    
    // pDevice is a SharpDX.Direct3D11.Texture2D instance
    // pDevice.NativePointer is an IntPtr that refers to the native IDirect3D11Device
    // being wrapped by SharpDX.
    IMFDXGIDeviceManager pDeviceManager;
    object d3dDevice = Marshal.GetIUnknownForObject(pDevice.NativePointer);
    HResult hr = MFExtern.MFCreateDXGIDeviceManager(out resetToken, out pDeviceManager);
    if(Succeeded(hr))
    {
        // The signature of this is:
        // HResult ResetDevice(object d3d11device, int resetToken);
        hr = pDeviceManager.ResetDevice(d3dDevice, resetToken);
    }
