    class Program
    {
        static void Main(string[] args)
        {
            var volumeInfo = VolumeInformation.GetVolumeInformation("c");
        }
    }
    [DebuggerDisplay("{ Volume,nq} ({ Name,nq })")]
    class VolumeInformation
    {
        #region Fields
        private const int BufferLength = 256;
        #endregion
        #region Properties
        public string Volume
        {
            get;
        }
        public string Name
        {
            get;
        }
        public uint SerialNumber
        {
            get;
        }
        public string SystemName
        {
            get;
        }
        #endregion
        #region Constructors
        private VolumeInformation(string volume, string name, uint serialNumber, string systemName)
        {
            Volume = volume;
            Name = name;
            SerialNumber = serialNumber;
            SystemName = systemName;
        }
        #endregion
        #region Methods
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetVolumeInformation(string letter, StringBuilder name, uint nameSize, out uint serialNumber, out uint serialNumberLength, out uint flags, StringBuilder systemName, uint systemNameSize);
        public static VolumeInformation GetVolumeInformation(string volume)
        {
            var name = new StringBuilder(BufferLength);
            var systemName = new StringBuilder(BufferLength);
            var serialNumber = 0u;
            var serialNumberLength = 0u;
            var flags = 0u;
            volume = (volume ?? String.Empty).Trim();
            if(volume.Length == 1)
            {
                volume = $"{volume}:\\";
            }
            if(!volume.EndsWith(@"\"))
            {
                volume = $"{volume}\\";
            }
            if (GetVolumeInformation(volume, name, BufferLength, out serialNumber, out serialNumberLength, out flags, systemName, BufferLength))
            {
                return new VolumeInformation(volume, name.ToString(), serialNumber, systemName.ToString());
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
