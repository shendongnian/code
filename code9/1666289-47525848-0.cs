    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // This is a standard Form. I have added a TreeView control and an ImageList to the Form.
            // The image list is bound to the treeview, with ColorDepth set to Depth32Bit
            var classes = DeviceClass.Load(DeviceFiter.AllClasses | DeviceFiter.Present);
            foreach (var cls in classes)
            {
                var classNode = treeView1.Nodes.Add(cls.Description);
                imageList1.Images.Add(cls.Icon);
                classNode.ImageIndex = imageList1.Images.Count - 1;
                classNode.SelectedImageIndex = classNode.ImageIndex;
                foreach (var device in cls.Devices)
                {
                    var deviceNode = classNode.Nodes.Add(device.Name);
                    imageList1.Images.Add(device.Icon);
                    deviceNode.ImageIndex = imageList1.Images.Count - 1;
                    deviceNode.SelectedImageIndex = deviceNode.ImageIndex;
                }
                classNode.Expand();
            }
            // dispose (icons)
            foreach (var cls in classes)
            {
                foreach (var device in cls.Devices)
                {
                    device.Dispose();
                }
                cls.Dispose();
            }
        }
    }
    public class DeviceClass : IDisposable, IComparable, IComparable<DeviceClass>
    {
        private List<Device> _devices = new List<Device>();
        private Icon _icon;
        internal DeviceClass(Guid classId, string description)
        {
            ClassId = classId;
            Description = description;
        }
        public Guid ClassId { get; }
        public string Description { get; }
        public Icon Icon => _icon;
        public IReadOnlyList<Device> Devices => _devices;
        public static IReadOnlyList<DeviceClass> Load(DeviceFiter fiter)
        {
            var list = new List<DeviceClass>();
            var hdevinfo = SetupDiGetClassDevs(IntPtr.Zero, null, IntPtr.Zero, fiter);
            try
            {
                var data = new SP_DEVINFO_DATA();
                data.cbSize = Marshal.SizeOf<SP_DEVINFO_DATA>();
                int index = 0;
                while (SetupDiEnumDeviceInfo(hdevinfo, index, ref data))
                {
                    index++;
                    var classId = GetGuidProperty(hdevinfo, ref data, DEVPKEY_Device_ClassGuid);
                    if (classId == Guid.Empty)
                        continue;
                    string classDescription = GetClassDescription(classId);
                    var cls = list.FirstOrDefault(c => c.ClassId == classId);
                    if (cls == null)
                    {
                        cls = new DeviceClass(classId, classDescription);
                        list.Add(cls);
                        SetupDiLoadClassIcon(ref classId, out IntPtr clsIcon, out int mini);
                        if (clsIcon != IntPtr.Zero)
                        {
                            cls._icon = Icon.FromHandle(clsIcon);
                        }
                    }
                    string name = GetStringProperty(hdevinfo, ref data, DEVPKEY_Device_FriendlyName);
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        name = GetStringProperty(hdevinfo, ref data, DEVPKEY_Device_DeviceDesc);
                    }
                    Icon icon = null;
                    SetupDiLoadDeviceIcon(hdevinfo, ref data, 16, 16, 0, out IntPtr devIcon);
                    if (devIcon != IntPtr.Zero)
                    {
                        icon = Icon.FromHandle(devIcon);
                    }
                    var dev = new Device(cls, name, icon);
                    cls._devices.Add(dev);
                }
            }
            finally
            {
                if (hdevinfo != IntPtr.Zero)
                {
                    SetupDiDestroyDeviceInfoList(hdevinfo);
                }
            }
            foreach (var cls in list)
            {
                cls._devices.Sort();
            }
            list.Sort();
            return list;
        }
        int IComparable.CompareTo(object obj) => CompareTo(obj as DeviceClass);
        public int CompareTo(DeviceClass other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            return Description.CompareTo(other.Description);
        }
        public void Dispose()
        {
            if (_icon != null)
            {
                _icon.Dispose();
                _icon = null;
            }
        }
        private static string GetClassDescription(Guid classId)
        {
            SetupDiGetClassDescription(ref classId, IntPtr.Zero, 0, out int size);
            if (size == 0)
                return null;
            var ptr = Marshal.AllocCoTaskMem(size * 2);
            try
            {
                if (!SetupDiGetClassDescription(ref classId, ptr, size, out size))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                return Marshal.PtrToStringUni(ptr, size - 1);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }
        private static string GetStringProperty(IntPtr hdevinfo, ref SP_DEVINFO_DATA data, DEVPROPKEY pk)
        {
            SetupDiGetDeviceProperty(hdevinfo, ref data, ref pk, out int propertyType, IntPtr.Zero, 0, out int size, 0);
            if (size == 0)
                return null;
            var ptr = Marshal.AllocCoTaskMem(size);
            try
            {
                if (!SetupDiGetDeviceProperty(hdevinfo, ref data, ref pk, out propertyType, ptr, size, out size, 0))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                return Marshal.PtrToStringUni(ptr, (size / 2) - 1);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }
        private static Guid GetGuidProperty(IntPtr hdevinfo, ref SP_DEVINFO_DATA data, DEVPROPKEY pk)
        {
            SetupDiGetDeviceProperty(hdevinfo, ref data, ref pk, out int propertyType, out Guid guid, 16, out int size, 0);
            return guid;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid ClassGuid;
            public int DevInst;
            public IntPtr Reserved;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct DEVPROPKEY
        {
            public Guid fmtid;
            public int pid;
        }
        private const int ERROR_NOT_FOUND = 118;
        private const int ERROR_INSUFFICIENT_BUFFER = 122;
        private static readonly DEVPROPKEY DEVPKEY_Device_DeviceDesc = new DEVPROPKEY { fmtid = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pid = 2 };
        private static readonly DEVPROPKEY DEVPKEY_Device_FriendlyName = new DEVPROPKEY { fmtid = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pid = 14 };
        private static readonly DEVPROPKEY DEVPKEY_Device_Class = new DEVPROPKEY { fmtid = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pid = 9 };
        private static readonly DEVPROPKEY DEVPKEY_Device_ClassGuid = new DEVPROPKEY { fmtid = new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), pid = 10 };
        [DllImport("setupapi", CharSet = CharSet.Unicode)]
        private static extern IntPtr SetupDiGetClassDevs(IntPtr ClassGuid, [MarshalAs(UnmanagedType.LPWStr)] string Enumerator, IntPtr hwndParent, DeviceFiter Flags);
        [DllImport("setupapi", SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);
        [DllImport("setupapi", SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, int MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);
        [DllImport("setupapi", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetupDiGetClassDescription(ref Guid ClassGuid, IntPtr ClassDescription, int ClassDescriptionSize, out int RequiredSize);
        [DllImport("setupapi", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetupDiLoadClassIcon(ref Guid ClassGuid, out IntPtr LargeIcon, out int MiniIconIndex);
        [DllImport("setupapi", SetLastError = true)]
        private static extern bool SetupDiLoadDeviceIcon(IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData,
            int cxIcon, int cyIcon, int Flags, out IntPtr hIcon);
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetupDiGetDeviceProperty(IntPtr DeviceInfoSet,
              ref SP_DEVINFO_DATA DeviceInfoData,
              ref DEVPROPKEY PropertyKey,
              out int PropertyType,
              IntPtr PropertyBuffer,
              int PropertyBufferSize,
              out int RequiredSize,
              int Flags);
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetupDiGetDeviceProperty(IntPtr DeviceInfoSet,
              ref SP_DEVINFO_DATA DeviceInfoData,
              ref DEVPROPKEY PropertyKey,
              out int PropertyType,
              out Guid PropertyBuffer,
              int PropertyBufferSize,
              out int RequiredSize,
              int Flags);
    }
    [Flags]
    public enum DeviceFiter // DIGCF_* flags
    {
        Default = 1,
        Present = 2,
        AllClasses = 4,
        Profile = 8,
        DeviceInterface = 16
    }
    public class Device : IDisposable, IComparable, IComparable<Device>
    {
        internal Device(DeviceClass cls, string name, Icon icon)
        {
            Class = cls;
            Name = name;
            Icon = icon;
        }
        public string Name { get; }
        public DeviceClass Class { get; }
        public Icon Icon { get; private set; }
        public override string ToString() => Name;
        public void Dispose()
        {
            if (Icon != null)
            {
                Icon.Dispose();
                Icon = null;
            }
        }
        int IComparable.CompareTo(object obj) => CompareTo(obj as Device);
        public int CompareTo(Device other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            return Name.CompareTo(other.Name);
        }
    }
