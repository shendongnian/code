    // inside your allocator class that implements IMFAsyncCallback
    public HResult Invoke(IMFAsyncResult pResult)
    {
        object pUnkObject;
        IMFSample pSample = null;
        IMFMediaBuffer pBuffer = null;
        IMFDXGIBuffer pDXGIBuffer = null;
        HResult hr = pResult.GetObject(out pUnkObject);
        if(Succeeded(hr))
        {
            pSample = pUnkObject as IMFSample;
        }
        if(pSample != null)
        {
            hr = pSample.GetBufferByIndex(0, out pBuffer);
        }
        if(Succeeded(hr))
        {
            pDXGIBuffer = pBuffer as IMFDXGIBuffer;
        }
        if(pDXGIBuffer != null)
        {
           // the GUID is from your above code, should be the same as IID_ID3D11Texture2D
           hr = pDXGIBuffer.GetResource(new Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c"), out pUnkObject);
        }
        if(Succeeded(hr))
        {
           // If we got here, pUnkObject is the native D3D11 Texture2D as
           // a System.Object, but it's unlikely you have an interface 
           // definition for ID3D11Texture2D handy, so we can't just cast
           // it to the proper interface.
           // Happily, SharpDX supports wrapping System.Object within
           // SharpDX.ComObject which makes things pretty easy.
           SharpDX.ComObject comWrapper = new SharpDX.ComObject(pUnkObject);
           // If this doesn't work, or you're using something like SlimDX
           // which doesn't support object wrapping the same way, the below
           // code is an alternative way.
           /*
           IntPtr pD3DTexture2D = Marshal.GetIUnknownForObject(pUnkObject);
           // Create your wrapper object here, like this for SharpDX
           SharpDX.ComObject comWrapper = new SharpDX.ComObject(pD3DTexture2D);
           // or like this for SlimDX
           SlimDX.Direct3D11.Texture2D.FromPointer(pD3DTexture2D);
           Marshal.Release(pD3DTexture2D);
           */
           // You might need to query comWrapper for a SharpDX.DXGI.Resource
           // first, then query that for the SharpDX.Direct3D11.Texture2D.
           SharpDX.Direct3D11.Texture2D texture = comWrapper.QueryInterface<SharpDX.Direct3D11.Texture2D>();
           if(texture != null)
           {
               // Now you can add "texture" back to your allocator's free list
           }
        }
    }
