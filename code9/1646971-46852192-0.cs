            Dim ProcessFireFox As Process() = Process.GetProcessesByName("firefox")
            If ProcessFireFox.Count = 0 Then
                MsgBox("firefox not found", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
            For Each Firefox As Process In ProcessFireFox
                If Firefox.MainWindowHandle = IntPtr.Zero Then Continue For
                Dim AutomationElement As System.Windows.Automation.AutomationElement = System.Windows.Automation.AutomationElement.FromHandle(Firefox.MainWindowHandle)
                For Each Elm As System.Windows.Automation.AutomationElement In AutomationElement.FindAll(TreeScope.Descendants, New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document))
                    Dim BAutomationPattern As System.Windows.Automation.AutomationPattern() = Elm.GetSupportedPatterns()
                    Dim BValuePattern As System.Windows.Automation.ValuePattern = DirectCast(Elm.GetCurrentPattern(BAutomationPattern(0)), System.Windows.Automation.ValuePattern)
                    MsgBox(BValuePattern.Current.Value.ToString)
                Next
            Next
