    using System;
    using System.Management;
    public class OpticalDriveWatcher
    {
        private ManagementEventWatcher _wmiWatcher = new ManagementEventWatcher();
        public ManagementEventWatcher WmiWatcher
        {
            get { return _wmiWatcher; }
        }
        private void OnWmiEventReceived(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("WMI event!");
        }
        public void WatchWithWMI(string path)
        {
            string queryString = "Select * From __InstanceOperationEvent "
                               + "WITHIN 2 "
                               + "WHERE TargetInstance ISA 'CIM_DataFile' "
                               + $"And TargetInstance.Drive='{path}'";
            WqlEventQuery wmiQuery = new WqlEventQuery(queryString);
            WmiWatcher.Query = wmiQuery;
            WmiWatcher.Start();
        }
    }
