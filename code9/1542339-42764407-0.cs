    dim PixelsPerMMofScreen as double 
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim monitorSizesMM As List(Of PointF) = GetDesktopMonitors()
        If monitorSizesMM.Count > 0 Then
            PixelsPerMMofScreen = Screen.PrimaryScreen.Bounds.Height / monitorSizesMM(0).Y
        end if    
        Label1.Width = mm2px(50)
        Label1.Height = mm2px(50)
    End Sub
    Function mm2px(mm As Integer) As Integer
        Return mm * pixelsPerMMofScreen
    End Function
    Public Shared Function GetDesktopMonitors() As List(Of PointF)
        Dim screenSizeList As New List(Of PointF)()
        '''///////////////////////////////////////////////////////////////////////
        Try
            Dim searcher As New System.Management.ManagementObjectSearcher("root\WMI", "SELECT * FROM WmiMonitorID")
            For Each queryObj As ManagementObject In searcher.[Get]()
                Debug.WriteLine("-----------------------------------------------")
                Debug.WriteLine("WmiMonitorID instance")
                Debug.WriteLine("----------------")
                '   Console.WriteLine("Active: {0}", queryObj["Active"]);
                Debug.WriteLine("InstanceName: {0}", queryObj("InstanceName"))
                '   dynamic snid = queryObj["SerialNumberID"];
                '   Debug.WriteLine("SerialNumberID: (length) {0}", snid.Length);
                Debug.WriteLine("YearOfManufacture: {0}", queryObj("YearOfManufacture"))
                '
                '                foreach (PropertyData data in queryObj.Properties)
                '                {
                '                    Debug.WriteLine(data.Value.ToString());
                '                }
                '                
                Dim code As Object = queryObj("ProductCodeID")
                Dim pcid As String = ""
                For i As Integer = 0 To code.Length - 1
                    'pcid = pcid +code[i].ToString("X4");
                    pcid = pcid & [Char].ConvertFromUtf32(code(i))
                Next
                Debug.WriteLine(Convert.ToString("ProductCodeID: ") & pcid)
                Dim xSize As Integer = 0
                Dim ySize As Integer = 0
                Dim PNP As String = queryObj("InstanceName").ToString()
                PNP = PNP.Substring(0, PNP.Length - 2)
                ' remove _0
                If PNP IsNot Nothing AndAlso PNP.Length > 0 Then
                    Dim displayKey As String = "SYSTEM\CurrentControlSet\Enum\"
                    Dim strSubDevice As String = (displayKey & PNP) + "\" + "Device Parameters\"
                    ' e.g.
                    ' SYSTEM\CurrentControlSet\Enum\DISPLAY\LEN40A0\4&1144c54c&0&UID67568640\Device Parameters
                    ' SYSTEM\CurrentControlSet\Enum\DISPLAY\LGD0335\4&1144c54c&0&12345678&00&02\Device Parameters
                    '
                    Debug.WriteLine(Convert.ToString("Register Path: ") & strSubDevice)
                    Dim regKey As RegistryKey = Registry.LocalMachine.OpenSubKey(strSubDevice, False)
                    If regKey IsNot Nothing Then
                        If regKey.GetValueKind("edid") = RegistryValueKind.Binary Then
                            Debug.WriteLine("read edid")
                            Dim edid As Byte() = DirectCast(regKey.GetValue("edid"), Byte())
                            Const edid_x_size_in_mm As Integer = 21
                            Const edid_y_size_in_mm As Integer = 22
                            xSize = (CInt(edid(edid_x_size_in_mm)) * 10)
                            ySize = (CInt(edid(edid_y_size_in_mm)) * 10)
                            Debug.WriteLine("Screen size cx=" + xSize.ToString() + ", cy=" + ySize.ToString())
                        End If
                        regKey.Close()
                    End If
                End If
                Debug.WriteLine("-----------------------------------------------")
                Dim pt As New PointF()
                pt.X = CSng(xSize)
                pt.Y = CSng(ySize)
                screenSizeList.Add(pt)
            Next
        Catch e As ManagementException
            Console.WriteLine("An error occurred while querying for WMI data: " + e.Message)
        End Try
        Return screenSizeList
    End Function
