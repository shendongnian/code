    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace BluetoothDiagnostics
    {
        public sealed class BluetoothComPort
        {
            /// <summary>
            /// Returns a collection of all the Bluetooth virtual-COM ports on the system.
            /// </summary>
            /// <returns></returns>
            public static IReadOnlyList<BluetoothComPort> FindAll()
            {
                List<BluetoothComPort> ports = new List<BluetoothComPort>();
    
                IntPtr handle = NativeMethods.SetupDiGetClassDevs(ref NativeMethods.GUID_DEVCLASS_PORTS, null, IntPtr.Zero,  NativeMethods.DIGCF.PRESENT);
                if (handle != IntPtr.Zero)
                {
                    try
                    {
    
    
                        NativeMethods.SP_DEVINFO_DATA dat = new NativeMethods.SP_DEVINFO_DATA();
                        dat.cbSize = Marshal.SizeOf(dat);
                        uint i = 0;
    
                        while (NativeMethods.SetupDiEnumDeviceInfo(handle, i++, ref dat))
                        {
                            string remoteServiceName = string.Empty;
                            StringBuilder sbid = new StringBuilder(256);
                            int size;
                            NativeMethods.SetupDiGetDeviceInstanceId(handle, ref dat, sbid, sbid.Capacity, out size);
                            Debug.WriteLine(sbid);
                            long addr = GetBluetoothAddressFromDevicePath(sbid.ToString());
    
                            // only valid if an outgoing Bluetooth port
                            if (addr != long.MinValue && addr != 0)
                            {
                                IntPtr hkey = NativeMethods.SetupDiOpenDevRegKey(handle, ref dat, NativeMethods.DICS.GLOBAL, 0, NativeMethods.DIREG.DEV, 1);
                                var key = Microsoft.Win32.RegistryKey.FromHandle(new Microsoft.Win32.SafeHandles.SafeRegistryHandle(hkey, true));
                                object name = key.GetValue("PortName");
    
                                var pkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\BTHPORT\\Parameters\\Devices\\" + addr.ToString("x12"));
                                if (pkey != null)
                                {
                                    foreach (string nm in pkey.GetSubKeyNames())
                                    {
                                        if (nm.StartsWith("ServicesFor"))
                                        {
                                            var skey = pkey.OpenSubKey(nm);
                                            string s = sbid.ToString();
    
                                            //bluetooth service uuid from device id string
                                            int ifirst = s.IndexOf("{");
                                            string uuid = s.Substring(ifirst, s.IndexOf("}") - ifirst+1);
                                            var ukey = skey.OpenSubKey(uuid);
    
                                            // instance id from device id string
                                            string iid = s.Substring(s.LastIndexOf("_")+1);
                                            var instKey = ukey.OpenSubKey(iid);
    
                                            // registry key contains service name as a byte array
                                            object o = instKey.GetValue("PriLangServiceName");
                                            if(o != null)
                                            {
                                                byte[] chars = o as byte[];
                                                remoteServiceName = Encoding.UTF8.GetString(chars).Trim();
                                            }
                                        }
                                    }
                                }
                                ports.Add(new BluetoothComPort(sbid.ToString(), addr, name.ToString(), remoteServiceName));
                                key.Dispose();
                            }
                        }
    
                    }
                    finally
                    {
                        NativeMethods.SetupDiDestroyDeviceInfoList(handle);
                    }
                }
    
                return ports;
            }
    
            private string _deviceId;
            private long _bluetoothAddress;
            private string _portName;
            private string _remoteServiceName;
    
            internal BluetoothComPort(string deviceId, long bluetoothAddress, string portName, string remoteServiceName)
            {
                _deviceId = deviceId;
                _bluetoothAddress = bluetoothAddress;
                _portName = portName;
                _remoteServiceName = remoteServiceName;
            }
    
            public string DeviceId
            {
                get
                {
                    return _deviceId;
                }
            }
    
            public long BluetoothAddress
            {
                get
                {
                    return _bluetoothAddress;
                }
            }
    
            public string PortName
            {
                get
                {
                    return _portName;
                }
            }
    
            public string RemoteServiceName
            {
                get
                {
                    return _remoteServiceName;
                }
            }
    
    
            private static long GetBluetoothAddressFromDevicePath(string path)
            {
                if (path.StartsWith("BTHENUM"))
                {
                    int start = path.LastIndexOf('&');
                    int end = path.LastIndexOf('_');
                    string addressString = path.Substring(start + 1, (end - start) - 1);
    
                    // may return zero if it is an incoming port (we're not interested in these)
                    return long.Parse(addressString, System.Globalization.NumberStyles.HexNumber);
    
                }
    
                // not a bluetooth port
                return long.MinValue;
            }
    
            private static class NativeMethods
            {
                // The SetupDiGetClassDevs function returns a handle to a device information set that contains requested device information elements for a local machine. 
                [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
                internal static extern IntPtr SetupDiGetClassDevs(
                    ref Guid classGuid,
                    [MarshalAs(UnmanagedType.LPTStr)] string enumerator,
                    IntPtr hwndParent,
                    DIGCF flags);
    
                // The SetupDiEnumDeviceInfo function returns a SP_DEVINFO_DATA structure that specifies a device information element in a device information set. 
                [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
                [return: MarshalAs(UnmanagedType.Bool)]
                internal static extern bool SetupDiEnumDeviceInfo(
                    IntPtr deviceInfoSet,
                    uint memberIndex,
                    ref SP_DEVINFO_DATA deviceInfoData);
    
                // The SetupDiDestroyDeviceInfoList function deletes a device information set and frees all associated memory.
                [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
                [return: MarshalAs(UnmanagedType.Bool)]
                internal static extern bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);
    
                // The SetupDiGetDeviceInstanceId function retrieves the device instance ID that is associated with a device information element.
                [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
                [return: MarshalAs(UnmanagedType.Bool)]
                internal static extern bool SetupDiGetDeviceInstanceId(
                   IntPtr deviceInfoSet,
                   ref SP_DEVINFO_DATA deviceInfoData,
                   System.Text.StringBuilder deviceInstanceId,
                   int deviceInstanceIdSize,
                   out int requiredSize);
    
                //static Guid GUID_DEVCLASS_BLUETOOTH = new Guid("{E0CBF06C-CD8B-4647-BB8A-263B43F0F974}");
                internal static Guid GUID_DEVCLASS_PORTS = new Guid("{4d36e978-e325-11ce-bfc1-08002be10318}");
                
                [DllImport("setupapi.dll", SetLastError = true)]
                internal static extern IntPtr SetupDiOpenDevRegKey(IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData,
                    DICS Scope, int HwProfile, DIREG KeyType, int samDesired);
    
                [Flags]
                internal enum DICS
                {
                    GLOBAL = 0x00000001,  // make change in all hardware profiles
                    CONFIGSPECIFIC = 0x00000002,  // make change in specified profile only
                }
    
                internal enum DIREG
                {
                    DEV = 0x00000001,          // Open/Create/Delete device key
                    DRV = 0x00000002,          // Open/Create/Delete driver key
                }
    
                // changes to follow.
                // SETUPAPI.H
                [Flags()]
                internal enum DIGCF
                {
                    PRESENT = 0x00000002, // Return only devices that are currently present in a system.
                    ALLCLASSES = 0x00000004, // Return a list of installed devices for all device setup classes or all device interface classes. 
                    PROFILE = 0x00000008, // Return only devices that are a part of the current hardware profile.
                }
                
    
                [StructLayout(LayoutKind.Sequential)]
                internal struct SP_DEVINFO_DATA
                {
                    internal int cbSize; // = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
                    internal Guid ClassGuid;
                    internal uint DevInst;
                    internal IntPtr Reserved;
                }
            }
        }
    }
