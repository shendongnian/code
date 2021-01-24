        public static List<string> GetMachineSids()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserProfile");
            var regs = searcher.Get();
            string sid;
            List<string> sids = new List<string>();
            foreach (ManagementObject os in regs)
            {
                if (os["SID"] != null)
                {
                    sid = os["SID"].ToString();
                    sids.Add(sid);
                }
            }
            searcher.Dispose();
            return sids.Count > 0 ? sids : null;
        }
