    public class UWPHidDevice : UWPDeviceBase<HidDevice>
    {
        #region Public Properties
        public bool DataHasExtraByte { get; set; } = true;
        #endregion
        #region Public Override Properties
        /// <summary>
        /// TODO: These vales are completely wrong and not being used anyway...
        /// </summary>
        public override ushort WriteBufferSize => 64;
        /// <summary>
        /// TODO: These vales are completely wrong and not being used anyway...
        /// </summary>
        public override ushort ReadBufferSize => 64;
        #endregion
        #region Event Handlers
        private void _HidDevice_InputReportReceived(HidDevice sender, HidInputReportReceivedEventArgs args)
        {
            HandleDataReceived(InputReportToBytes(args));
        }
        #endregion
        #region Constructors
        public UWPHidDevice()
        {
        }
        public UWPHidDevice(string deviceId) : base(deviceId)
        {
        }
        #endregion
        #region Private Methods
        private byte[] InputReportToBytes(HidInputReportReceivedEventArgs args)
        {
            byte[] bytes;
            using (var stream = args.Report.Data.AsStream())
            {
                bytes = new byte[args.Report.Data.Length];
                stream.Read(bytes, 0, (int)args.Report.Data.Length);
            }
            if (DataHasExtraByte)
            {
                bytes = RemoveFirstByte(bytes);
            }
            return bytes;
        }
        public override async Task InitializeAsync()
        {
            //TODO: Put a lock here to stop reentrancy of multiple calls
            //TODO: Dispose but this seems to cause initialization to never occur
            //Dispose();
            Logger.Log("Initializing Hid device", null, nameof(UWPHidDevice));
            await GetDevice(DeviceId);
            if (_ConnectedDevice != null)
            {
                _ConnectedDevice.InputReportReceived += _HidDevice_InputReportReceived;
                RaiseConnected();
            }
            else
            {
                throw new Exception($"The device {DeviceId} failed to initialize");
            }
        }
        protected override IAsyncOperation<HidDevice> FromIdAsync(string id)
        {
            return HidDevice.FromIdAsync(id, FileAccessMode.ReadWrite);
        }
        #endregion
        #region Public Methods
        public override async Task WriteAsync(byte[] data)
        {
            byte[] bytes;
            if (DataHasExtraByte)
            {
                bytes = new byte[data.Length + 1];
                Array.Copy(data, 0, bytes, 1, data.Length);
                bytes[0] = 0;
            }
            else
            {
                bytes = data;
            }
            var buffer = bytes.AsBuffer();
            var outReport = _ConnectedDevice.CreateOutputReport();
            outReport.Data = buffer;
            try
            {
                var operation = _ConnectedDevice.SendOutputReportAsync(outReport);
                await operation.AsTask();
                Tracer?.Trace(false, bytes);
            }
            catch (ArgumentException ex)
            {
                //TODO: Check the string is nasty. Validation on the size of the array being sent should be done earlier anyway
                if (ex.Message == "Value does not fall within the expected range.")
                {
                    throw new Exception("It seems that the data being sent to the device does not match the accepted size. Have you checked DataHasExtraByte?", ex);
                }
                throw;
            }
        }
        #endregion
    }
    public class UWPUsbDevice : UWPDeviceBase<UsbDevice>
    {
        #region Fields
        /// <summary>
        /// TODO: It should be possible to select a different configuration/interface
        /// </summary>
        private UsbInterface _DefaultConfigurationInterface;
        private UsbInterruptOutPipe _DefaultOutPipe;
        private UsbInterruptInPipe _DefaultInPipe;
        #endregion
        #region Public Override Properties
        public override ushort WriteBufferSize => (ushort)_DefaultOutPipe.EndpointDescriptor.MaxPacketSize;
        public override ushort ReadBufferSize => (ushort)_DefaultInPipe.EndpointDescriptor.MaxPacketSize;
        #endregion
        #region Constructors
        public UWPUsbDevice() : base()
        {
        }
        public UWPUsbDevice(string deviceId) : base(deviceId)
        {
        }
        #endregion
        #region Private Methods
        public override async Task InitializeAsync()
        {
            await GetDevice(DeviceId);
            if (_ConnectedDevice != null)
            {
                var usbInterface = _ConnectedDevice.Configuration.UsbInterfaces.FirstOrDefault();
                if (usbInterface == null)
                {
                    _ConnectedDevice.Dispose();
                    throw new Exception("There was no Usb Interface found for the device.");
                }
                var interruptPipe = usbInterface.InterruptInPipes.FirstOrDefault();
                if (interruptPipe == null)
                {
                    throw new Exception("There was no interrupt pipe found on the interface");
                }
                interruptPipe.DataReceived += InterruptPipe_DataReceived;
                //TODO: Fill in the DeviceDefinition...
                // TODO: It should be possible to select a different configurations, interface, and pipes
                _DefaultConfigurationInterface = _ConnectedDevice.Configuration.UsbInterfaces.FirstOrDefault();
                //TODO: Clean up this messaging and move down to a base class across platforms
                if (_DefaultConfigurationInterface == null) throw new Exception("Could not get the default interface configuration for the USB device");
                _DefaultOutPipe = _DefaultConfigurationInterface.InterruptOutPipes.FirstOrDefault();
                if (_DefaultOutPipe == null) throw new Exception("Could not get the default out pipe for the default USB interface");
                _DefaultInPipe = _DefaultConfigurationInterface.InterruptInPipes.FirstOrDefault();
                if (_DefaultOutPipe == null) throw new Exception("Could not get the default in pipe for the default USB interface");
                RaiseConnected();
            }
            else
            {
                throw new Exception($"Could not connect to device with Device Id {DeviceId}. Check that the package manifest has been configured to allow this device.");
            }
        }
        protected override IAsyncOperation<UsbDevice> FromIdAsync(string id)
        {
            return UsbDevice.FromIdAsync(id);
        }
        #endregion
        #region Event Handlers
        private void InterruptPipe_DataReceived(UsbInterruptInPipe sender, UsbInterruptInEventArgs args)
        {
            HandleDataReceived(args.InterruptData.ToArray());
        }
        #endregion
        #region Public Methods
        public override async Task WriteAsync(byte[] bytes)
        {
            if (_DefaultOutPipe == null) throw new Exception("The device has not been initialized.");
            if (bytes.Length > WriteBufferSize) throw new Exception("The buffer size is too large");
            await _DefaultOutPipe.OutputStream.WriteAsync(bytes.AsBuffer());
            Tracer?.Trace(false, bytes);
        }
        #endregion
    }
