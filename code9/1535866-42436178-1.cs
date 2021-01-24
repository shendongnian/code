    try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_IP4RouteTable");
                ListViewItem buf;
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string destination = queryObj["Destination"].ToString();
                    string mask = queryObj["Mask"].ToString();
                    string metric = queryObj["Metric1"].ToString();
                    string interfaceIndex = queryObj["InterfaceIndex"].ToString();
                    string nexthop = queryObj["NextHop"].ToString();
                    string protocol =queryObj["Protocol"].ToString();
                    string type = queryObj["Type"].ToString();
                    string status;
                    if (queryObj["Status"]!=null)
                    {
                      status = queryObj["Status"].ToString();
                    }
                    else
                    {
                       status = string.Empty;
                    }
                    buf = new ListViewItem(new string[] {destination,mask,metric,interfaceIndex,nexthop,protocol,status,typ});
                    list_route.Items.Add(buf);
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }
