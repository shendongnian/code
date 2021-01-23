        Try
            Using mos As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=""{4d36e978-e325-11ce-bfc1-08002be10318}""")
                Dim AvailableComPorts = SerialPort.GetPortNames().ToList()
                Dim q As ManagementObjectCollection = mos.Get()
                For Each x As ManagementObject In q
                    Console.WriteLine(x.Properties("Name").Value)
                    Console.WriteLine(x.Properties("DeviceID").Value)
                Next
            End Using
        Catch ex As Exception
            Throw
        End Try
