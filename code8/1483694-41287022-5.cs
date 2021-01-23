        private static void FetchCpuIdInternal()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_Processor"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            if (mo.Properties["UniqueId"] != null && mo.Properties["UniqueId"].Value != null)
                            {
                                // only return cpuInfo from first CPU
                                Trace.WriteLine("CPU ID = " + mo.Properties["UniqueId"].Value.ToString());
                                _cpuID = mo.Properties["UniqueId"].Value.ToString();
                            }
                            mo.Dispose();
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
                Trace.TraceWarning("Failed to read CPUID\r\n" + ex.Message);
            }
        }
