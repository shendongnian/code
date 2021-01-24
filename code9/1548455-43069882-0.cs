    private void Button_Click_1(object sender, RoutedEventArgs e) {
                var p = Process.GetProcessesByName(ProcName).FirstOrDefault(x => x != null);
                if (p == null) {
                    Console.WriteLine("proccess: {0} was not found", ProcName); return;
                }
                var root = AutomationElement.RootElement.FindChildByProcessId(p.Id);
                AutomationElement devexGridAutomationElement = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, DevexGridAutomationId));
                if (devexGridAutomationElement == null) {
                    Console.WriteLine("No AutomationElement was found with id: {0}", DevexGridAutomationId);
                    return;
                }
                
                var cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem);
                var devexGridItems = devexGridAutomationElement.FindAll(TreeScope.Descendants, cond);
                GridPattern gridPat = devexGridAutomationElement.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
                Console.WriteLine("number of elements in the grid: {0}", gridPat.Current.RowCount);
            }
