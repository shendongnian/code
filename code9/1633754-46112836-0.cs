    public sealed class RExampleVidoEffect : IBasicVideoEffect
    {
    
        private static SoftwareBitmap Snap;
        public void SetEncodingProperties(VideoEncodingProperties encodingProperties, IDirect3DDevice device)
        {
    
        }
    
        public void ProcessFrame(ProcessVideoFrameContext context)
        {
            var inputFrameBitmap = context.InputFrame.SoftwareBitmap;
            Snap = inputFrameBitmap;
        }
    
        public static SoftwareBitmap GetSnapShot()
        {
            return Snap;
        }
        public void Close(MediaEffectClosedReason reason)
        {
    
        }
    
        public void DiscardQueuedFrames()
        {
    
        }
    
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
    
        public IReadOnlyList<VideoEncodingProperties> SupportedEncodingProperties
        {
            get { return new List<VideoEncodingProperties>(); }
        }
        public MediaMemoryTypes SupportedMemoryTypes
        {
            get { return MediaMemoryTypes.Cpu; }
        }
    
        public bool TimeIndependent
        {
            get { return true; }
        }
    
    
    
        public void SetProperties(IPropertySet configuration)
        {
    
        }
    }
      
