          Process[] lFFs = Process.GetProcessesByName("firefox");
    
          foreach (Process ff in lFFs)
                {
                    if (ff.MainWindowHandle == IntPtr.Zero)
                        continue;
    
                    UIAutomationClient.IUIAutomation _Auto = new UIAutomationClient.CUIAutomation();
                    UIAutomationClient.IUIAutomationElement rootElement = _Auto.ElementFromHandle(ff.MainWindowHandle);
                    UIAutomationClient.IUIAutomationCondition c = _Auto.CreateTrueCondition();
                    UIAutomationClient.IUIAutomationElementArray lEs = rootElement.FindAll(UIAutomationClient.TreeScope.TreeScope_Children, c);
                    lEs = lEs.GetElement(18).FindAll(UIAutomationClient.TreeScope.TreeScope_Children, c);
                    lEs = lEs.GetElement(5).FindAll(UIAutomationClient.TreeScope.TreeScope_Children, c);
    
                    for (int j = 1; j < lEs.Length; j++)
                    {
                        UIAutomationClient.IUIAutomationElement ee = lEs.GetElement(j);
                        object obj = ee.GetCurrentPattern(10002); // 10002: ValuePattern
    
                        if (obj != null)
                        {
                            string sUrl =((UIAutomationClient.IUIAutomationValuePattern)obj).CurrentValue;
                            return sUrl;
                        }
                    }
    }
