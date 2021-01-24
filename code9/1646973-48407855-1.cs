      Process[] lFFs = Process.GetProcessesByName("firefox");
            
                        for (int i = 0; i < lEs.Length; i++)
                        {
                            UIAutomationClient.IUIAutomationElement ee = lEs.GetElement(i);
                            if (ee != null && ee.CurrentName  != null &&
     (ee.CurrentName.Contains("search") || ee.CurrentName.Contains("navigation")))                       
        { // For spanish you can use: (ee.CurrentName.Contains("de búsqueda") || ee.CurrentName==  "Barra de navegación")
    
                                lEs = ee.FindAll(UIAutomationClient.TreeScope.TreeScope_Children, c);
                                if (lEs.Length > 0)
                                    i = 0;
                                else
                                {
                                    try
                                    {
                                        object obj = ee.GetCurrentPattern(10002); // 10002: ValuePattern
        
                                        if (obj != null)
                                        {
                                            string sUrl = ((UIAutomationClient.IUIAutomationValuePattern)obj).CurrentValue;
                                            return  sUrl;
                                        }
                                    }
                                    catch
                                    { }
                                }
                            }
                        }
