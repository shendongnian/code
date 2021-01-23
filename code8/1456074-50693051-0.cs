     private static ManagementObject GetMngObj(string className)
        {
            var wmi = new ManagementClass(className);
            foreach (var o in wmi.GetInstances())
            {
                var mo = (ManagementObject)o;
                if (mo != null) return mo;
            }
            return null;
        }
        public static string GetOsVer()
        {
            try
            {
                ManagementObject mo = GetMngObj("Win32_OperatingSystem");
                if (null == mo)
                    return string.Empty;
                return mo["Version"] as string;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
