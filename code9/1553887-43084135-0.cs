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
