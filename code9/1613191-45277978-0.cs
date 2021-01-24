     public partial class DeviceNotifier : IDisposable
    {
        private ManagementEventWatcher w = null;
        public delegate void NotifyUSBRemoved(object sender, EventArgs e);
        public delegate void NotifyUSBAdded(object sender, EventArgs e);
        public event NotifyUSBRemoved _NotifyUsbRemoved;
        public event NotifyUSBAdded _NotifyUsbAdded;
        public void PublishUsbRemoved(object sender)
        {
            if (_NotifyUsbRemoved != null)
            {
                _NotifyUsbRemoved(sender, new EventArgs());
            }
        }
        public void PublishUsbAdded(object sender)
        {
            if (_NotifyUsbAdded != null)
            {
                _NotifyUsbAdded(sender, new EventArgs());
            }
        }
        public void StartRemoveUSBHandler()
        {
            WqlEventQuery eventQuery;
            ManagementScope managementScope = new ManagementScope("root\\CIMV2");
            managementScope.Options.EnablePrivileges = true;
            try
            {
                eventQuery = new WqlEventQuery();
                eventQuery.EventClassName = "__InstanceDeletionEvent";
                eventQuery.WithinInterval = new TimeSpan(0, 0, 3);
                eventQuery.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
                w = new ManagementEventWatcher(managementScope, eventQuery);
                w.EventArrived += USBRemoved;
                w.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (w != null)
                {
                    w.Stop();
                }
            }
            finally
            {
                Dispose();
            }
        }
        public void StartInsertUSBHandler()
        {
            WqlEventQuery eventQuery;
            ManagementScope managementScope = new ManagementScope("root\\CIMV2");
            managementScope.Options.EnablePrivileges = true;
            try
            {
                eventQuery = new WqlEventQuery();
                eventQuery.EventClassName = "__InstanceCreationEvent";
                eventQuery.WithinInterval = new TimeSpan(0, 0, 3);
                eventQuery.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
                w = new ManagementEventWatcher(managementScope, eventQuery);
                w.EventArrived += USBInserted;
                w.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (w != null)
                {
                    w.Stop();
                }
            }
            finally
            {
                Dispose();
            }
        }
        internal void USBRemoved(object sender, EventArgs e)
        {
            PublishUsbRemoved(sender);
        }
        internal void USBInserted(object sender, EventArgs e)
        {
            PublishUsbAdded(sender);
        }
        #region "Clean up"
        private bool disposed = false;
        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }
        private void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                { w.Dispose(); }
                disposed = true;
            }
        }
        ~DeviceNotifier()
        {
            CleanUp(false);
        }
        #endregion
    }
 
