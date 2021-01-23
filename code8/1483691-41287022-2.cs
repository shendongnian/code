        private static void FecthMACAddressInternal()
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
                                Trace.WriteLine(mo["Index"] + " Mac " + mo["Caption"] + " : " + mo["MacAddress"] + " Enabled " + (bool)mo["IPEnabled"]);
                                if (string.IsNullOrEmpty(_macAdderss))  // only return MAC Address from first card
                                {
                                    if ( mo["MacAddress"] != null && mo["IPEnabled"] != null && (bool)mo["IPEnabled"] == true)
                                    {
                                        _macAdderss = mo["MacAddress"].ToString();
                                    }
                                }
                                mo.Dispose();
                            }
                        }
                    }
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
            if (_macAdderss != null)
                _macAdderss = _macAdderss.Replace(":", "");
        }
