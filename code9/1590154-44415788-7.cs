    
    sealed class TextureAllocator : IMFAsyncCallback, IDisposable
    {
        private ConcurrentStack<SharpDX.Direct3D11.Texture2D> m_freeStack;
        private static readonly Guid s_IID_ID3D11Texture2D = new Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c");
        // If all textures are the exact same size and color format,
        // consider making those parameters private class members and
        // requiring they be specified as arguments to the constructor.
        public TextureAllocator()
        {
            m_freeStack = new ConcurrentStack<SharpDX.Direct3D11.Texture2D>();
        }
        private bool disposedValue = false;
        private void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    // Dispose managed resources here
                }
                
                if(m_freeStack != null)
                {
                    SharpDX.Direct3D11.Texture2D texture;
                    while(m_freeStack.TryPop(out texture))
                    {
                        texture.Dispose();
                    }
                    m_freeStack = null;
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~TextureAllocator()
        {
            Dispose(false);
        }
        private SharpDX.Direct3D11.Texture2D InternalAllocateNewTexture()
        {
            // Allocate a new texture with your format, size, etc here.
        }
        public SharpDX.Direct3D11.Texture2D AllocateTexture()
        {
            SharpDX.Direct3D11.Texture2D existingTexture;
            if(m_freeStack.TryPop(out existingTexture))
            {
                return existingTexture;
            }
            else
            {
                return InternalAllocateNewTexture();
            }
        }
        public IMFSample CreateSampleAndAllocateTexture()
        {
            IMFSample pSample;
            IMFTrackedSample pTrackedSample;
            HResult hr;
            
            // Create the video sample. This function returns an IMFTrackedSample per MSDN
            hr = MFExtern.MFCreateVideoSampleFromSurface(null, out pSample);
            MFError.ThrowExceptionForHR(hr);
            // Query the IMFSample to see if it implements IMFTrackedSample
            pTrackedSample = pSample as IMFTrackedSample;
            if(pTrackedSample == null)
            {
                // Throw an exception if we didn't get an IMFTrackedSample
                // but this shouldn't happen in practice.
                throw new InvalidCastException("MFCreateVideoSampleFromSurface returned a sample that did not implement IMFTrackedSample");
            }
            
            // Use our own class to allocate a texture
            SharpDX.Direct3D11.Texture2D availableTexture = AllocateTexture();
            // Convert the texture's native ID3D11Texture2D pointer into
            // an IUnknown (represented as as System.Object)
            object texNativeObject = Marshal.GetObjectForIUnknown(availableTexture.NativePointer);
            
            // Create the media buffer from the texture
            IMFMediaBuffer p2DBuffer;
            hr = MFExtern.MFCreateDXGISurfaceBuffer(s_IID_ID3D11Texture2D, texNativeObject, 0, false, out p2DBuffer);
            // Release the object-as-IUnknown we created above
            COMBase.SafeRelease(texNativeObject);
            // If media buffer creation failed, throw an exception
            MFError.ThrowExceptionForHR(hr);
            // Set the owning instance of this class as the allocator
            // for IMFTrackedSample to notify when the sample is released
            pTrackedSample.SetAllocator(this, null);
            // Attach the created buffer to the sample
            pTrackedSample.AddBuffer(p2DBuffer);
            return pTrackedSample;
        }
        // This is public so any textures you allocate but don't make IMFSamples 
        // out of can be returned to the allocator manually.
        public void ReturnFreeTexture(SharpDX.Direct3D11.Texture2D freeTexture)
        {
            m_freeStack.Push(freeTexture);
        }
        
        // IMFAsyncCallback.GetParameters
        // This is allowed to return E_NOTIMPL as a way of specifying
        // there are no special parameters.
        public HResult GetParameters(out MFAsync pdwFlags, out MFAsyncCallbackQueue pdwQueue)
        {
            pdwFlags = MFAsync.None;
            pdwQueue = MFAsyncCallbackQueue.Standard;
            return HResult.E_NOTIMPL;
        }
        public HResult Invoke(IMFAsyncResult pResult)
        {
            object pUnkObject;
            IMFSample pSample = null;
            IMFMediaBuffer pBuffer = null;
            IMFDXGIBuffer pDXGIBuffer = null;
            
            // Get the IUnknown out of the IMFAsyncResult if there is one
            HResult hr = pResult.GetObject(out pUnkObject);
            if(Succeeded(hr))
            {
                pSample = pUnkObject as IMFSample;
            }
            
            if(pSample != null)
            {
                // Based on your implementation, there should only be one 
                // buffer attached to one sample, so we can always grab the
                // first buffer. You could add some error checking here to make
                // sure the sample has a buffer count that is 1.
                hr = pSample.GetBufferByIndex(0, out pBuffer);
            }
            
            if(Succeeded(hr))
            {
                // Query the IMFMediaBuffer to see if it implements IMFDXGIBuffer
                pDXGIBuffer = pBuffer as IMFDXGIBuffer;
            }
            if(pDXGIBuffer != null)
            {
               // Got an IMFDXGIBuffer, so we can extract the internal 
               // ID3D11Texture2D and make a new SharpDX.Texture2D wrapper.
               hr = pDXGIBuffer.GetResource(s_IID_ID3D11Texture2D, out pUnkObject);
            }
            if(Succeeded(hr))
            {
               // If we got here, pUnkObject is the native D3D11 Texture2D as
               // a System.Object, but it's unlikely you have an interface 
               // definition for ID3D11Texture2D handy, so we can't just cast
               // the object to the proper interface.
               
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
                   // Now you can add "texture" back to the allocator's free list
                   ReturnFreeTexture(texture);
               }
            }
        }
    }
