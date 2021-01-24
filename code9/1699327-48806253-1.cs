        const int LOCK_TIMEOUT = 10000;       // 10 Seconds
        const int LOCK_RETRIES = 20; 
        public static bool LockVolume(IntPtr hVolume)
        {
            int dwBytesReturned;
            int dwSleepAmount;
            int nTryCount;
            dwSleepAmount = LOCK_TIMEOUT / LOCK_RETRIES;
            // Do this in a loop until a timeout period has expired
            for (nTryCount = 0; nTryCount < LOCK_RETRIES; nTryCount++)
            {
                if (DeviceIoControl(hVolume,
                                    FSCTL_LOCK_VOLUME,
                                    IntPtr.Zero, 0,
                                    IntPtr.Zero, 0,
                                    out dwBytesReturned,
                                    IntPtr.Zero))
                    return true;
                Thread.Sleep(dwSleepAmount);
            }
            return false;
        }
        public static bool PreventRemovalOfVolume(IntPtr hVolume, bool fPreventRemoval)
        {
            int retVal;
            IntPtr buffer = new IntPtr((fPreventRemoval) ? 1 : 0);
            return DeviceIoControl(hVolume, IOCTL_STORAGE_MEDIA_REMOVAL, buffer, 1, IntPtr.Zero, 0, out retVal, IntPtr.Zero);
        }
        public static bool DismountVolume(IntPtr hVolume)
        {
            int dwBytesReturned;
            return DeviceIoControl(hVolume,
                                    FSCTL_DISMOUNT_VOLUME,
                                    IntPtr.Zero, 0,
                                    IntPtr.Zero, 0,
                                    out dwBytesReturned,
                                    IntPtr.Zero);
        }
        public static bool  AutoEjectVolume(IntPtr hVolume)
        {
            int  dwBytesReturned;
            return DeviceIoControl(hVolume,
                                    IOCTL_STORAGE_EJECT_MEDIA,
                                    IntPtr.Zero, 0,
                                    IntPtr.Zero, 0,
                                    out dwBytesReturned,
                                    IntPtr.Zero);
        }
        public static bool CloseVolume(IntPtr hVolume)
        {
            return CloseHandle(hVolume);
        }
