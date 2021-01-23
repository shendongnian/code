        /// <summary>
        /// return Volume Serial Number from hard drive
        /// </summary>
        /// <param name="strDriveLetter">[optional] Drive letter</param>
        /// <returns>[string] VolumeSerialNumber</returns>
        public static string GetVolumeSerial(char driveLetter)
        {
            try
            {
                using (ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + driveLetter + ":\""))
                {
                    if (disk == null)
                        return null;
                    disk.Get();
                    object diskObj = disk["VolumeSerialNumber"];
                    if (diskObj != null)
                        return diskObj.ToString();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Trace.TraceWarning("Failed to read DiskID\r\n" + ex.Message);
            }
            try
            {
                uint serialNum, serialNumLength, flags;
                StringBuilder volumename = new StringBuilder(256);
                StringBuilder fstype = new StringBuilder(256);
                bool ok = GetVolumeInformation(driveLetter.ToString() + ":\\", volumename, (uint)volumename.Capacity - 1, out serialNum, out serialNumLength, out flags, fstype, (uint)fstype.Capacity - 1);
                if (ok)
                {
                    return string.Format("{0:X4}{1:X4}", serialNum >> 16, serialNum & 0xFFFF);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex2)
            {
                Trace.TraceWarning("Failed to read DiskID\r\n" + ex2.Message);
            }
            return null;
        }
