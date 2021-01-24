    using System.IO;
    public class FileSystemInfo
    {
        private readonly Lazy<DriveInfo> dInfo =
            new Lazy<DriveInfo>(() => new DriveInfo(@"C:\"));
        public string CheckTotalFreeSpace()
        {
            return dInfo.Value.TotalFreeSpace.ToString();
        }
        public string CheckVolumeLabel()
        {
            return dInfo.Value.VolumeLabel.ToString();
        }
    }
