                string connectionProfileInfo = string.Empty;
                ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                if (InternetConnectionProfile == null)
                {
                    rootPage.NotifyUser("Not connected to Internet\n", NotifyType.StatusMessage);
                }
                else
                {
                    connectionProfileInfo = GetConnectionProfile(InternetConnectionProfile);
                    OutputText.Text = connectionProfileInfo;
                    rootPage.NotifyUser("Success", NotifyType.StatusMessage);
                }
                // Which calls this function, that allows you to determine how strong the signal is and the associated bandwidth
                string GetConnectionProfile(ConnectionProfile connectionProfile)
                {
                    // ...
                        if (connectionProfile.GetSignalBars().HasValue)
                        {
                            connectionProfileInfo += "====================\n";
                            connectionProfileInfo += "Signal Bars: " + connectionProfile.GetSignalBars() + "\n";
                        }
                    // ...
                } 
