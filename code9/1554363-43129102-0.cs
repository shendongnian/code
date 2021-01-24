    public static UITestControl FindControl(WinControl myControl, string controlName)
            {
                try
                {
                    UITestControlCollection controls = myControl.FindMatchingControls();
                    foreach (UITestControl currentControl in controls)
                    {
                        if (currentControl.ControlType == ControlType.Button)
                        {
                            WinButton mycont = (WinButton)currentControl;
                            if (mycont.ControlName == controlName)
                            {
                                return mycont;
                            }
                        }
                        if (currentControl.ControlType == ControlType.Edit)
                        {
                            WinEdit mycont = (WinEdit)currentControl;
                            if (mycont.ControlName == controlName)
                            {
                                return mycont;
                            }
                        }
                    }
                    return myControl;
                }
                catch
                {
                    return myControl;
                }
            }
