            public void TerminateExecutingEXE(string fileName)
        {
            try
            {
                 if ((scope == null))
                    throw new NotConnectedException("No WMI connection exists");
                ObjectQuery objObjectQuery = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name = '"+fileName+"'");
                ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(scope, objObjectQuery);
                foreach (ManagementObject queryObj in objSearcher.Get())
                {
                       if (queryObj["Name"].ToString().ToLower() == fileName.ToLower())
                        {
                            object[] obj = new object[] { 0 };
                            queryObj.InvokeMethod("Terminate", obj);
                        }
                 }
                objSearcher = null;
                objObjectQuery = null;
            }
            catch (Exception ex) 
            {
                ex.Data.Add("Filename", fileName);
                throw;
            }
        }
