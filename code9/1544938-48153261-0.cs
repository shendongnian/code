            try
            {
                //this.Cursor = Cursors.WaitCursor;
                //ShowStatusBar(string.Empty, true);
                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    //this.Cursor = Cursors.Default;
                    return;
                }
                string ipAddress = txtIPAddress.Text.Trim();
                string port = txtPort.Text.Trim();
                if (ipAddress == string.Empty || port == string.Empty)
                    throw new Exception("The Device IP Address and Port is mandotory !!");
                int portNumber = 4370;
                if (!int.TryParse(port, out portNumber))
                    throw new Exception("Not a valid port number");
                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The Device IP is invalid !!");
                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");
                objZkeeper = new ZkemClient(RaiseDeviceEvent);
                IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);
                if (IsDeviceConnected)
                {
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse(txtMachineNumber.Text.Trim()));
                    //lblDeviceInfo.Text = deviceInfo;
                    lblMessage.Text = deviceInfo + "is Connected";
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            //this.Cursor = Cursors.Default;
        }
