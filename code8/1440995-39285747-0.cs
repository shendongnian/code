    private void EIN_Click(object sender, EventArgs e)
        {
          try
                {
                    #region Code to start the service
              
                    string serviceName = "TeamViewer";
                    string IP="actual-IP-address";
                    string username ="actual-username";
                    string password ="actual-password";
                    ConnectionOptions connectoptions = new ConnectionOptions();
                    //connectoptions.Impersonation = ImpersonationLevel.Impersonate;
                    connectoptions.Username = username;
                    connectoptions.Password = password;
                    //IP Address of the remote machine
                 
                    ManagementScope scope = new ManagementScope(@"\\" + IP + @"\root\cimv2");
                    scope.Options = connectoptions;
                    //WMI query to be executed on the remote machine
                    SelectQuery query = new SelectQuery("select * from Win32_Service where name = '" + serviceName + "'");
                    using (ManagementObjectSearcher searcher = new
                                ManagementObjectSearcher(scope, query))
                    {
                        ManagementObjectCollection collection = searcher.Get();
                        foreach (ManagementObject service in collection)
                        {
                            if (service["Started"].Equals(false))
                            {
                                //Start the service
                                service.InvokeMethod("StartService", null);
                                //here i added a picture box which shows a green button when the service is started
                                pictureBox1.Image = Properties.Resources._120px_Green_Light_I_svg;
                          }
                        }
                    }
                  
           #endregion
                }
                catch (NullReferenceException)
                {
                 
                }
        }
