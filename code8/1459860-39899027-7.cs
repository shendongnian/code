    abstract class CaptureDevice : ADevice<CaptureDevice>
    {
        public CaptureDevice(CaptureDevice device, string filename)
            : base(device, filename)
        {
        }
        // Or (But still same comment)
        public CaptureDevice(CaptureDevice device)
            : base(device, defaultFilename)
        {
        }
    }
