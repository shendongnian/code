    Class MainWindow
    
        Private _devices As New Dictionary(Of Integer, TouchDeviceEmulator)()
    
        Public Sub New()
    
            ' This call is required by the designer.
            InitializeComponent()
    
            ' Add any initialization after the InitializeComponent() call.
    
            For i As Integer = 1 To 19
                Dim myComboBoxItem As ComboBoxItem = New ComboBoxItem
                myComboBoxItem.Content = "ComboBoxItem " & i.ToString()
                comboBox1.Items.Add(myComboBoxItem)
    
            Next
    
            For i As Integer = 65 To 90
                Dim c As Char = ChrW(i)
                For j As Integer = 1 To 10
                    textBlock1.Text += " ".PadLeft(10, c)
                Next
                textBlock1.Text += vbCrLf
            Next
    
        End Sub
    
        Protected Overrides Sub OnSourceInitialized(e As EventArgs)
            MyBase.OnSourceInitialized(e)
    
            Dim source As Interop.HwndSource = TryCast(PresentationSource.FromVisual(Me), Interop.HwndSource)
            source.AddHook(New Interop.HwndSourceHook(AddressOf WndProc))
    
            Dim presentation = DirectCast(PresentationSource.FromDependencyObject(Me), Interop.HwndSource)
            If presentation Is Nothing Then
                Throw New Exception("Unable to find the parent element host.")
            End If
    
            RegisterTouchWindow(presentation.Handle, TouchWindowFlag.WantPalm)
        End Sub
    
        Private Function WndProc(hwnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr, ByRef handled As Boolean) As IntPtr
    
            ' Handle messages...
            If msg = WM_TOUCH Then
                handled = HandleTouch(wParam, lParam)
                Return New IntPtr(1)
            End If
    
            Return IntPtr.Zero
    
        End Function
    
        Private Function HandleTouch(wParam As IntPtr, lParam As IntPtr) As Boolean
            Dim handled As Boolean = False
            Dim inputCount = wParam.ToInt32() And &HFFFF
            Dim inputs = New TOUCHINPUT(inputCount - 1) {}
    
            If GetTouchInputInfo(lParam, inputCount, inputs, Runtime.InteropServices.Marshal.SizeOf(inputs(0))) Then
    
                For i As Integer = 0 To inputCount - 1
                    Dim input As TOUCHINPUT = inputs(i)
                    'TOUCHINFO point coordinates and contact size is in 1/100 of a pixel; convert it to pixels.
                    'Also convert screen to client coordinates.
                    Dim position As Point = PointFromScreen(New System.Windows.Point((input.x * 0.01), (input.y * 0.01)))
    
                    Dim device As TouchDeviceEmulator = Nothing
                    If Not _devices.TryGetValue(input.dwID, device) Then
                        device = New TouchDeviceEmulator(input.dwID)
                        _devices.Add(input.dwID, device)
                    End If
    
                    device.Position = position
    
                    If (input.dwFlags And TOUCHEVENTF_DOWN) > 0 Then
                        device.SetActiveSource(PresentationSource.FromVisual(Me))
                        device.Activate()
                        device.ReportDown()
                    ElseIf device.IsActive AndAlso (input.dwFlags And TOUCHEVENTF_UP) > 0 Then
                        device.ReportUp()
                        device.Deactivate()
                        _devices.Remove(input.dwID)
                    ElseIf device.IsActive AndAlso (input.dwFlags And TOUCHEVENTF_MOVE) > 0 Then
                        device.ReportMove()
                    End If
                Next
    
                CloseTouchInputHandle(lParam)
                handled = True
            End If
    
            Return handled
        End Function
    
    
    
        Private Class TouchDeviceEmulator
            Inherits TouchDevice
    
            Public Position As System.Windows.Point
    
            Public Sub New(deviceId As Integer)
                MyBase.New(deviceId)
            End Sub
    
            Public Overrides Function GetTouchPoint(relativeTo As IInputElement) As TouchPoint
                Dim pt As System.Windows.Point = Position
                If relativeTo IsNot Nothing Then
                    pt = ActiveSource.RootVisual.TransformToDescendant(DirectCast(relativeTo, Visual)).Transform(Position)
                End If
    
                Dim rect = New Rect(pt, New Size(1.0, 1.0))
                Return New TouchPoint(Me, pt, rect, TouchAction.Move)
            End Function
    
            Public Overrides Function GetIntermediateTouchPoints(relativeTo As IInputElement) As TouchPointCollection
                Throw New NotImplementedException()
            End Function
    
            Public Overloads Sub SetActiveSource(activeSource As PresentationSource)
                MyBase.SetActiveSource(activeSource)
            End Sub
    
            Public Overloads Sub Activate()
                MyBase.Activate()
            End Sub
    
            Public Overloads Sub ReportUp()
                MyBase.ReportUp()
            End Sub
    
            Public Overloads Sub ReportDown()
                MyBase.ReportDown()
            End Sub
    
            Public Overloads Sub ReportMove()
                MyBase.ReportMove()
            End Sub
    
            Public Overloads Sub Deactivate()
                MyBase.Deactivate()
            End Sub
    
        End Class
    
    
    
        Private Const WM_TOUCH As Integer = &H240
    
        Private Enum TouchWindowFlag As UInteger
            FineTouch = &H1
            WantPalm = &H2
        End Enum
    
        ' Touch event flags ((TOUCHINPUT.dwFlags) [winuser.h]
        Private Const TOUCHEVENTF_MOVE As Integer = &H1
        Private Const TOUCHEVENTF_DOWN As Integer = &H2
        Private Const TOUCHEVENTF_UP As Integer = &H4
        Private Const TOUCHEVENTF_INRANGE As Integer = &H8
        Private Const TOUCHEVENTF_PRIMARY As Integer = &H10
        Private Const TOUCHEVENTF_NOCOALESCE As Integer = &H20
        Private Const TOUCHEVENTF_PEN As Integer = &H40
        Private Const TOUCHEVENTF_PALM As Integer = &H80
    
        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)>
        Private Structure TOUCHINPUT
            Public x As Int32
            Public y As Int32
            Public hSource As IntPtr
            Public dwID As Int32
            Public dwFlags As Int32
            Public dwMask As Int32
            Public dwTime As Int32
            Public dwExtraInfo As IntPtr
            Public cxContact As Int32
            Public cyContact As Int32
        End Structure
    
        <Runtime.InteropServices.DllImport("user32")>
        Private Shared Function RegisterTouchWindow(hWnd As System.IntPtr, flags As TouchWindowFlag) As Boolean
        End Function
    
        <Runtime.InteropServices.DllImport("user32")>
        Private Shared Function GetTouchInputInfo(hTouchInput As IntPtr, cInputs As Int32, <Runtime.InteropServices.[In], Runtime.InteropServices.Out> pInputs As TOUCHINPUT(), cbSize As Int32) As <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> [Boolean]
        End Function
    
        <Runtime.InteropServices.DllImport("user32")>
        Private Shared Sub CloseTouchInputHandle(lParam As System.IntPtr)
        End Sub
    
    End Class
