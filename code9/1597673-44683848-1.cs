    [StructLayout(LayoutKind.Sequential)]
    public struct MyStruct : IDirect3DSurface {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MipLevels { get; set; }
        public uint ArraySize { get; set; }
        public DirectXPixelFormat Format { get; set; }
        public Direct3DMultisampleDescription SampleDesc { get; set; }
        public Direct3DUsage Usage { get; set; }
        public uint BindFlags { get; set; }
        public uint CPUAccessFlags { get; set; }
        public uint MiscFlags { get; set; }
    
        #region I Do not know about this part
        public Action Disposer { get; set; }
        public void Dispose() {
            Disposer();
        }
        #endregion I Do not know about this part
    
        public Direct3DSurfaceDescription Description => new Direct3DSurfaceDescription {
            Format = Format,
            Height = Height,
            Width = Width,
            MultisampleDescription = SampleDesc
        };
    }
    
