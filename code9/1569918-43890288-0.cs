    using (var bmp = WicBitmapSource.Load("input.png"))
    {
        bmp.Scale(1357, 584, WicBitmapInterpolationMode.NearestNeighbor);
        bmp.Save("output.png");
    }
    
    ...
    public enum WicBitmapInterpolationMode
    {
        NearestNeighbor = 0,
        Linear = 1,
        Cubic = 2,
        Fant = 3,
        HighQualityCubic = 4,
    }
    public sealed class WicBitmapSource : IDisposable
    {
        private IWICBitmapSource _source;
        private WicBitmapSource(IWICBitmapSource source, Guid format)
        {
            _source = source;
            Format = format;
            Stats();
        }
        public Guid Format { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public double DpiX { get; private set; }
        public double DpiY { get; private set; }
        private void Stats()
        {
            if (_source == null)
            {
                Width = 0;
                Height = 0;
                DpiX = 0;
                DpiY = 0;
                return;
            }
            int w, h;
            _source.GetSize(out w, out h);
            Width = w;
            Height = h;
            double dpix, dpiy;
            _source.GetResolution(out dpix, out dpiy);
            DpiX = dpix;
            DpiY = dpiy;
        }
        private void CheckDisposed()
        {
            if (_source == null)
                throw new ObjectDisposedException(null);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~WicBitmapSource()
        {
            Dispose(false);
        }
        private void Dispose(bool disposing)
        {
            if (_source != null)
            {
                Marshal.ReleaseComObject(_source);
                _source = null;
            }
        }
        public void Save(string filePath)
        {
            Save(filePath, Format, Guid.Empty);
        }
        public void Save(string filePath, Guid pixelFormat)
        {
            Save(filePath, Format, pixelFormat);
        }
        public void Save(string filePath, Guid encoderFormat, Guid pixelFormat)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            if (encoderFormat == Guid.Empty)
            {
                string ext = Path.GetExtension(filePath).ToLowerInvariant();
                // we support only png & jpg
                if (ext == ".png")
                {
                    encoderFormat = new Guid(0x1b7cfaf4, 0x713f, 0x473c, 0xbb, 0xcd, 0x61, 0x37, 0x42, 0x5f, 0xae, 0xaf);
                }
                else if (ext == ".jpeg" || ext == ".jpe" || ext == ".jpg" || ext == ".jfif" || ext == ".exif")
                {
                    encoderFormat = new Guid(0x19e4a5aa, 0x5662, 0x4fc5, 0xa0, 0xc0, 0x17, 0x58, 0x02, 0x8e, 0x10, 0x57);
                }
            }
            if (encoderFormat == Guid.Empty)
                throw new ArgumentException();
            using (var file = File.OpenWrite(filePath))
            {
                Save(file, encoderFormat, pixelFormat);
            }
        }
        public void Save(Stream stream)
        {
            Save(stream, Format, Guid.Empty);
        }
        public void Save(Stream stream, Guid pixelFormat)
        {
            Save(stream, Format, pixelFormat);
        }
        public void Save(Stream stream, Guid encoderFormat, Guid pixelFormat)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            CheckDisposed();
            Save(_source, stream, encoderFormat, pixelFormat, WICBitmapEncoderCacheOption.WICBitmapEncoderNoCache, null);
        }
        public void Scale(int? width, int? height, WicBitmapInterpolationMode mode)
        {
            if (!width.HasValue && !height.HasValue)
                throw new ArgumentException();
            int neww;
            int newh;
            if (width.HasValue && height.HasValue)
            {
                neww = width.Value;
                newh = height.Value;
            }
            else
            {
                int w = Width;
                int h = Height;
                if (w == 0 || h == 0)
                    return;
                if (width.HasValue)
                {
                    neww = width.Value;
                    newh = (width.Value * h) / w;
                }
                else
                {
                    newh = height.Value;
                    neww = (height.Value * w) / h;
                }
            }
            if (neww <= 0 || newh <= 0)
                throw new ArgumentException();
            CheckDisposed();
            _source = Scale(_source, neww, newh, mode);
            Stats();
        }
        // we support only 1-framed files (unlike TIF for example)
        public static WicBitmapSource Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            return LoadBitmapSource(filePath, 0, WICDecodeOptions.WICDecodeMetadataCacheOnDemand);
        }
        public static WicBitmapSource Load(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            return LoadBitmapSource(stream, 0, WICDecodeOptions.WICDecodeMetadataCacheOnDemand);
        }
        private static WicBitmapSource LoadBitmapSource(string filePath, int frameIndex, WICDecodeOptions metadataOptions)
        {
            var wfac = (IWICImagingFactory)new WICImagingFactory();
            IWICBitmapDecoder decoder = null;
            try
            {
                decoder = wfac.CreateDecoderFromFilename(filePath, null, GenericAccessRights.GENERIC_READ, metadataOptions);
                return new WicBitmapSource(decoder.GetFrame(frameIndex), decoder.GetContainerFormat());
            }
            finally
            {
                Release(decoder);
                Release(wfac);
            }
        }
        private static WicBitmapSource LoadBitmapSource(Stream stream, int frameIndex, WICDecodeOptions metadataOptions)
        {
            var wfac = (IWICImagingFactory)new WICImagingFactory();
            IWICBitmapDecoder decoder = null;
            try
            {
                decoder = wfac.CreateDecoderFromStream(new ManagedIStream(stream), null, metadataOptions);
                return new WicBitmapSource(decoder.GetFrame(frameIndex), decoder.GetContainerFormat());
            }
            finally
            {
                Release(decoder);
                Release(wfac);
            }
        }
        private static IWICBitmapScaler Scale(IWICBitmapSource source, int width, int height, WicBitmapInterpolationMode mode)
        {
            var wfac = (IWICImagingFactory)new WICImagingFactory();
            IWICBitmapScaler scaler = null;
            try
            {
                scaler = wfac.CreateBitmapScaler();
                scaler.Initialize(source, width, height, mode);
                Marshal.ReleaseComObject(source);
                return scaler;
            }
            finally
            {
                Release(wfac);
            }
        }
        private static void Save(IWICBitmapSource source, Stream stream, Guid containerFormat, Guid pixelFormat, WICBitmapEncoderCacheOption cacheOptions, WICRect rect)
        {
            var wfac = (IWICImagingFactory)new WICImagingFactory();
            IWICBitmapEncoder encoder = null;
            IWICBitmapFrameEncode frame = null;
            try
            {
                encoder = wfac.CreateEncoder(containerFormat, null);
                encoder.Initialize(new ManagedIStream(stream), cacheOptions);
                encoder.CreateNewFrame(out frame, IntPtr.Zero);
                frame.Initialize(IntPtr.Zero);
                if (pixelFormat != Guid.Empty)
                {
                    frame.SetPixelFormat(pixelFormat);
                }
                frame.WriteSource(source, rect);
                frame.Commit();
                encoder.Commit();
            }
            finally
            {
                Release(frame);
                Release(encoder);
                Release(wfac);
            }
        }
        private static void Release(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
            }
        }
        [ComImport]
        [Guid("CACAF262-9370-4615-A13B-9F5539DA4C0A")]
        private class WICImagingFactory
        {
        }
        [StructLayout(LayoutKind.Sequential)]
        private class WICRect
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }
        [Flags]
        private enum WICDecodeOptions
        {
            WICDecodeMetadataCacheOnDemand = 0x0,
            WICDecodeMetadataCacheOnLoad = 0x1,
        }
        [Flags]
        private enum WICBitmapEncoderCacheOption
        {
            WICBitmapEncoderCacheInMemory = 0x0,
            WICBitmapEncoderCacheTempFile = 0x1,
            WICBitmapEncoderNoCache = 0x2,
        }
        [Flags]
        private enum GenericAccessRights : uint
        {
            GENERIC_READ = 0x80000000,
            GENERIC_WRITE = 0x40000000,
            GENERIC_EXECUTE = 0x20000000,
            GENERIC_ALL = 0x10000000,
            GENERIC_READ_WRITE = GENERIC_READ | GENERIC_WRITE
        }
        [Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICImagingFactory
        {
            IWICBitmapDecoder CreateDecoderFromFilename([MarshalAs(UnmanagedType.LPWStr)] string wzFilename, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] Guid[] pguidVendor, GenericAccessRights dwDesiredAccess, WICDecodeOptions metadataOptions);
            IWICBitmapDecoder CreateDecoderFromStream(IStream pIStream, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] Guid[] pguidVendor, WICDecodeOptions metadataOptions);
            void NotImpl2();
            void NotImpl3();
            void NotImpl4();
            IWICBitmapEncoder CreateEncoder([MarshalAs(UnmanagedType.LPStruct)] Guid guidContainerFormat, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] Guid[] pguidVendor);
            void NotImpl6();
            void NotImpl7();
            IWICBitmapScaler CreateBitmapScaler();
            // not fully impl...
        }
        [Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapSource
        {
            void GetSize(out int puiWidth, out int puiHeight);
            Guid GetPixelFormat();
            void GetResolution(out double pDpiX, out double pDpiY);
            void NotImpl3();
            void NotImpl4();
        }
        [Guid("00000302-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapScaler : IWICBitmapSource
        {
            #region IWICBitmapSource
            new void GetSize(out int puiWidth, out int puiHeight);
            new Guid GetPixelFormat();
            new void GetResolution(out double pDpiX, out double pDpiY);
            new void NotImpl3();
            new void NotImpl4();
            #endregion IWICBitmapSource
            void Initialize(IWICBitmapSource pISource, int uiWidth, int uiHeight, WicBitmapInterpolationMode mode);
        }
        [Guid("9EDDE9E7-8DEE-47ea-99DF-E6FAF2ED44BF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapDecoder
        {
            void NotImpl0();
            void NotImpl1();
            Guid GetContainerFormat();
            void NotImpl3();
            void NotImpl4();
            void NotImpl5();
            void NotImpl6();
            void NotImpl7();
            void NotImpl8();
            void NotImpl9();
            IWICBitmapFrameDecode GetFrame(int index);
        }
        [Guid("3B16811B-6A43-4ec9-A813-3D930C13B940"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapFrameDecode : IWICBitmapSource
        {
            // not fully impl...
        }
        [Guid("00000103-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapEncoder
        {
            void Initialize(IStream pIStream, WICBitmapEncoderCacheOption cacheOption);
            Guid GetContainerFormat();
            void NotImpl2();
            void NotImpl3();
            void NotImpl4();
            void NotImpl5();
            void NotImpl6();
            void CreateNewFrame(out IWICBitmapFrameEncode ppIFrameEncode, IntPtr encoderOptions);
            void Commit();
            // not fully impl...
        }
        [Guid("00000105-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapFrameEncode
        {
            void Initialize(IntPtr pIEncoderOptions);
            void SetSize(int uiWidth, int uiHeight);
            void SetResolution(double dpiX, double dpiY);
            void SetPixelFormat([MarshalAs(UnmanagedType.LPStruct)] Guid pPixelFormat);
            void NotImpl4();
            void NotImpl5();
            void NotImpl6();
            void NotImpl7();
            void WriteSource(IWICBitmapSource pIBitmapSource, WICRect prc);
            void Commit();
            // not fully impl...
        }
        private class ManagedIStream : IStream
        {
            private Stream _stream;
            public ManagedIStream(Stream stream)
            {
                _stream = stream;
            }
            public void Read(byte[] buffer, int count, IntPtr pRead)
            {
                int read = _stream.Read(buffer, 0, count);
                if (pRead != IntPtr.Zero)
                {
                    Marshal.WriteInt32(pRead, read);
                }
            }
            public void Seek(long offset, int origin, IntPtr newPosition)
            {
                long pos = _stream.Seek(offset, (SeekOrigin)origin);
                if (newPosition != IntPtr.Zero)
                {
                    Marshal.WriteInt64(newPosition, pos);
                }
            }
            public void SetSize(long newSize)
            {
                _stream.SetLength(newSize);
            }
            public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG stg, int flags)
            {
                const int STGTY_STREAM = 2;
                stg = new System.Runtime.InteropServices.ComTypes.STATSTG();
                stg.type = STGTY_STREAM;
                stg.cbSize = _stream.Length;
                stg.grfMode = 0;
                if (_stream.CanRead && _stream.CanWrite)
                {
                    const int STGM_READWRITE = 0x00000002;
                    stg.grfMode |= STGM_READWRITE;
                    return;
                }
                if (_stream.CanRead)
                {
                    const int STGM_READ = 0x00000000;
                    stg.grfMode |= STGM_READ;
                    return;
                }
                if (_stream.CanWrite)
                {
                    const int STGM_WRITE = 0x00000001;
                    stg.grfMode |= STGM_WRITE;
                    return;
                }
                throw new IOException();
            }
            public void Write(byte[] buffer, int count, IntPtr written)
            {
                _stream.Write(buffer, 0, count);
                if (written != IntPtr.Zero)
                {
                    Marshal.WriteInt32(written, count);
                }
            }
            public void Clone(out IStream ppstm) { throw new NotImplementedException(); }
            public void Commit(int grfCommitFlags) { throw new NotImplementedException(); }
            public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten) { throw new NotImplementedException(); }
            public void LockRegion(long libOffset, long cb, int dwLockType) { throw new NotImplementedException(); }
            public void Revert() { throw new NotImplementedException(); }
            public void UnlockRegion(long libOffset, long cb, int dwLockType) { throw new NotImplementedException(); }
        }
    }
