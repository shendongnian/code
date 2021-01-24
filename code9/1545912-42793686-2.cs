    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Http;
    using Windows.ApplicationModel.Background;
    using Windows.Devices.Enumeration;
    using Windows.Devices.SerialCommunication;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace BackgroundApplication2
    {
        public sealed class StartupTask : IBackgroundTask
        {
            private SerialDevice serialPort = null;
            public void Run(IBackgroundTaskInstance taskInstance)
            {
                //This tells IBackgroundTask you will be doing some extra work in the background and it should not shut down.
                var deferral = taskInstance.GetDeferral();
                try
                {
                    await FindDevice();
                    Debug.WriteLine("test1");
        
                    if (serialPort == null)
                    {
                        Debug.WriteLine("null");
                    }
                    await FindDevice();
                }
                finally
                {
                    //This tells IBackgroundTask that you are done with the last await.
                    deferral.Complete();
                }
            }
    
    
            private async Task FindDevice()
            {
                Debug.WriteLine("begintest");
                UInt16 vid = 0x2341;
                UInt16 pid = 0x0001;
    
                string aqs = SerialDevice.GetDeviceSelectorFromUsbVidPid(vid, pid);
    
                var myDevices = await DeviceInformation.FindAllAsync(aqs);
    
                if (myDevices.Count == 0)
                {
                    Debug.WriteLine("Device not found!");
                    return;
                }
    
                try
                {
                    Debug.WriteLine("testrange");
                    Debug.WriteLine(myDevices[0].Id);
                    serialPort = await SerialDevice.FromIdAsync(myDevices[0].Id);
                    if (serialPort == null)
                    {
                        Debug.WriteLine("null2");
                        return;
                    }
                    Debug.WriteLine("ok");
                    serialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
                    serialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
                    serialPort.BaudRate = 9600;
                    serialPort.Parity = SerialParity.None;
                    serialPort.StopBits = SerialStopBitCount.One;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = SerialHandshake.None;
                    Debug.WriteLine("ok2");
                    /*String debugtest = "Serial port configured successfully: ";
                    debugtest += serialPort.BaudRate + "-";
                    debugtest += serialPort.DataBits + "-";
                    debugtest += serialPort.Parity.ToString() + "-";
                    debugtest += serialPort.StopBits;
                    debugtest += (DeviceInformation)myDevices[0];
    
                    Debug.WriteLine("debugtest1");
                    Debug.WriteLine(debugtest);*/
                    Debug.WriteLine("debugtest2");
                    await Listen();
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message.ToString());
                    Debug.WriteLine("error");
                }
                finally
                {
                    Debug.WriteLine("Opened device for communication.");
                }
                Debug.WriteLine("test2");
            }
            private async Task Listen()
            {
                Debug.WriteLine("gelukt");
            }
        }
    }
