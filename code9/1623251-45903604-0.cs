    public string   PNPDeviceID
        {
            set
            {
                this.m_PNPDeviceID = value;
                this.InstanceName = null;
                this.QueryObjATAPISmartData = null;
                SearcherPnPDeviceId = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSWmi_PnPDeviceId");
                foreach (ManagementObject queryObj in SearcherPnPDeviceId.Get())
                {
                    if (queryObj["PNPDeviceID"] != null)
                    {
                        if (this.PNPDeviceID.ToUpper() == queryObj.GetPropertyValue("PNPDeviceID").ToString().ToUpper())
                        {
                            if (queryObj["InstanceName"] != null)
                            {
                                this.InstanceName = queryObj["InstanceName"].ToString();
                                break;
                            }
                        }
                    }
                }
                
                if (this.InstanceName != null)
                {
                    
                    SearcherATAPISmartData = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");
                    foreach (ManagementObject queryObj in SearcherATAPISmartData.Get())
                    {
                        if (queryObj["InstanceName"] != null)
                        {
                            if (this.InstanceName.ToUpper() != queryObj.GetPropertyValue("InstanceName").ToString().ToUpper())
                            {
                                continue;
                            }
                        }
                        this.QueryObjATAPISmartData  = queryObj;
                        break;
                    }  
          }
