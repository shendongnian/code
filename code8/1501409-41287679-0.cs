        public static string  GetMACAddress()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        if (moc != null)
                        {
                            foreach (ManagementObject mo in moc)
                            {
                                try
                                {
                                    Trace.WriteLine(mo["Index"] + " Mac " + mo["Caption"] + " : " + mo["MacAddress"] + " Enabled " + (bool)mo["IPEnabled"]);
                                    if (mo["MacAddress"] != null && mo["IPEnabled"] != null && (bool)mo["IPEnabled"] == true)
                                    {
                                        return mo["MacAddress"].ToString();
                                    }
                                }
                                finally
                                {
                                    mo.Dispose();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceWarning("Failed to read DiskID\r\n" + ex.Message);
            }
            return null;
        }
