        Private soc As Socket
        Private ep As EndPoint
        Private connected As Boolean
        Private efSent As Boolean
        Private are As New AutoResetEvent(False)
    #End Region
    
    #Region "Network"
        Public Sub Connect(Optional ip As String = "149.154.167.40", Optional port As Integer = 443)
            soc = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) With {.SendBufferSize = BUFFER_SIZE, .SendTimeout = 3000}
    
            Try
                ep = GetIPEndPointFromHostName(ip, port)
    
                Dim arg = New SocketAsyncEventArgs With {.RemoteEndPoint = ep, .UserToken = "Connect_ARGS"}
                AddHandler arg.Completed, AddressOf IO_Handler
    
                While Not connected
                    Try
                        If Not soc.ConnectAsync(arg) Then
                            IO_Handler(soc, arg)
                        End If
    
                        are.WaitOne(4000)
                    Catch ex As Exception
                        Thread.Sleep(1000)
                    End Try
                End While
    
            Catch ex As Exception
                Log("Connect: " & ex.ToString, ConsoleColor.Red, True)
            End Try
    
            ReadData()
        End Sub
    
        Public Sub Disconnect()
            connected = False
            loggedin = False
    
            soc.Disconnect(False)
            soc = Nothing
    
            Log("Disconnect", ConsoleColor.DarkYellow, True, True, True)
        End Sub
    
        Private Sub Send(m As PlainMessage)
            SendData(m.data, True)
        End Sub
    
        Private Sub Send(m As EncryptedMessage)
            SendData(m.data, True)
        End Sub
    
        Private Sub SendData(b() As Byte, Optional read As Boolean = False)
            b = TCPPack(b)
    
            Dim arg = New SocketAsyncEventArgs With {.RemoteEndPoint = ep, .UserToken = "Send_ARGS"}
            AddHandler arg.Completed, AddressOf IO_Handler
            arg.SetBuffer(b, 0, b.Length)
    
            Try
                If Not soc.SendAsync(arg) Then
                    IO_Handler(soc, arg)
                End If
            Catch ex As Exception
                Log("SendData: " & ex.ToString, ConsoleColor.Red)
            End Try
        End Sub
    
        Private Sub IO_Handler(sender As Object, e As SocketAsyncEventArgs)
            Select Case e.SocketError
                Case SocketError.Success
                    Select Case e.LastOperation
                        Case SocketAsyncOperation.Connect 'A socket Connect operation.
                            connected = True
                            Log("Connected to " & e.ConnectSocket.RemoteEndPoint.ToString, ConsoleColor.Green)
                            are.Set()
                        Case SocketAsyncOperation.Disconnect
                            connected = False
                            RaiseEvent Disconneted()
                        Case SocketAsyncOperation.Receive 'A socket Receive operation.
                            If e.BytesTransferred = 0 Then 'no pending data
                                Log("The remote end has closed the connection.")
                                If connected Then
                                    ReadData()
                                End If
    
                                connected = False
                                loggedin = False
    
                                Exit Sub
                            End If
                            HandleData(e)
                    End Select
                Case SocketError.ConnectionAborted
                    RaiseEvent Disconneted()
            End Select
        End Sub
    
        Private Function GetIPEndPointFromHostName(hostName As String, port As Integer) As IPEndPoint
            Dim addresses = System.Net.Dns.GetHostAddresses(hostName)
            If addresses.Length = 0 Then
                Log("Unable to retrieve address from specified host name:  " & hostName, ConsoleColor.Red)
                Return Nothing
            End If
            Return New IPEndPoint(addresses(0), port)
        End Function
    
        Private Function TCPPack(b As Byte()) As Byte()
            Dim a = New List(Of Byte)
            Dim len = CByte(b.Length / 4)
    
            If efSent = False Then 'TCP abridged version
                efSent = True
                a.Add(&HEF)
            End If
    
            If len >= &H7F Then
                a.Add(&H7F)
                a.AddRange(BitConverter.GetBytes(len)) '
            Else
                a.Add(len)
            End If
    
            a.AddRange(b) 'data, no sequence number, no CRC32
    
            Return a.ToArray
        End Function
    
        Private Sub ReadData()
            Dim arg = New SocketAsyncEventArgs With {.RemoteEndPoint = ep, .UserToken = "Read_ARGS"}
            AddHandler arg.Completed, AddressOf IO_Handler
    
            Dim b(BUFFER_SIZE - 1) As Byte
            arg.SetBuffer(b, 0, BUFFER_SIZE)
    
            Try
                If Not soc.ReceiveAsync(arg) Then
                    IO_Handler(soc, arg)
                End If
            Catch ex As Exception
                Log("ReadMessages: " & ex.ToString, ConsoleColor.Red)
            End Try
        End Sub
    
        Private Sub HandleData(e As SocketAsyncEventArgs)
            Log("<< " & B2H(e.Buffer, 0, e.BytesTransferred), ConsoleColor.DarkGray, True, logTime:=False)
            Try
                Dim len As Integer = e.Buffer(0)
                Dim start = 1
    
                If len = &H7F Then
                    len = e.Buffer(1)
                    len += e.Buffer(2) << 8
                    len += e.Buffer(3) << 16
                    start = 4
                End If
    
                len = 4 * len
    
                Dim d(len - 1) As Byte
                Array.Copy(e.Buffer, start, d, 0, len)
    
                ProcessResponse(d)
            Catch ex As Exception
    
            End Try
    
            ReadData()
        End Sub
    
        Private Sub ProcessResponse(data As Byte())
            'process the data received - identify the TL types returned from Telegram, then store / handle each as required
        End Sub
    #End Region
     
