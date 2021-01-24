        if (Properties.Settings.Default.loginUname != null)
                {
                    //Sends credentials from appsettings
                    uName.SendKeys(Properties.Settings.Default.loginUname);
                    pWord.SendKeys(Properties.Settings.Default.loginPword);
                    loginButton.Click();
                }
                else
                {
                    //Displays modal login popup form.
                    using (popupForm popup = new popupForm())
                    {
                        //Displays the popup form to get login info.
                        popup.ShowDialog();
                        //Sets appsettings for credentials.
                        Properties.Settings.Default.loginUname = userUname;
                        Properties.Settings.Default.loginPword = userPword;
                        Properties.Settings.Default.Save();
                        uName.SendKeys(Properties.Settings.Default.loginUname);
                        pWord.SendKeys(Properties.Settings.Default.loginPword);
                        loginButton.Click();
                    }
                }
