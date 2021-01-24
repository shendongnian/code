        mTextureView.SurfaceTextureListener = new TextureViewListener( this );
    }
    private class TextureViewListener : Java.Lang.Object, TextureView.ISurfaceTextureListener
    {
         readonly Camera camera;
         TextureViewListener( Camera camera )
         {
             this.camera = camera;
         }
        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            camera.OpenCamera(width, height); //Error Occurring Here 
        }
    }
    public void OpenCamera(int width, int height)
    {
        //Codes 
    }
