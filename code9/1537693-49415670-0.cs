    You can grab all the column headers and as well the row data by the below code:
    Happy coding =
     //// Grab the table
                IWebElement grid;
                grid = _browserInstance.Driver.FindElement(By.Id("tblVoucherLookUp"));
                IWebElement headercolumns = grid.FindElement(By.Id("tblVoucherLookUp"));
              _browserInstance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(75));
                _browserInstance.ScreenCapture("Voucher LookUp Grid");
             
                    //// get the column headers
                char[] character = "\r\n".ToCharArray();
                string[] Split = headercolumns.Text.Split(character);
    
                for (int i = 0; i < Split.Length; i++)
                {
                    if (Split[i] != "")
                    {
                        _log.LogEntry("INFO", "Voucher data", true,
                        Split + " Text matches the expected:" + Split[i]);
                    }
                }
