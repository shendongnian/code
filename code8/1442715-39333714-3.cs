    Public Shared Sub AddImageAttachment(ByVal uri As String, ByVal filePath As Hub.AttachmentElement, ByVal fileParameterName As String, ByVal contentType As String, ByVal otherParameters As Specialized.NameValueCollection)
        ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True
        Dim strFileName As String = filePath.SourceFileName
        Dim strPathAndFileName As String = filePath.SourcePathAndFileName
        Dim boundary As String = "---------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim newLine As String = System.Environment.NewLine
        Dim boundaryBytes As Byte() = Text.Encoding.ASCII.GetBytes(newLine & "--" & boundary & newLine)
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create(uri)
        'request.Proxy = New WebProxy("127.0.0.1", 8888)    'Proxy Entry for Tracing with Fiddler
        request.ContentType = "multipart/form-data; boundary=" & boundary
        request.Headers.Add("X-Atlassian-Token: no-check")
        request.Headers.Add("Authorization", "Basic " & Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credLogonID & ":" & credPassword)))
        request.Method = "POST"
        request.Credentials = Net.CredentialCache.DefaultCredentials
        Try
            Using requestStream As Stream = request.GetRequestStream()
                Dim formDataTemplate As String = "Content-Disposition: form-data; name=""{0}""{1}{1}{2}"
                If otherParameters.Keys.Count > 0 Then
                    For Each key As String In otherParameters.Keys
                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)
                        Dim formItem As String = String.Format(formDataTemplate, key, newLine, otherParameters(key))
                        Dim formItemBytes As Byte() = Text.Encoding.UTF8.GetBytes(formItem)
                        requestStream.Write(formItemBytes, 0, formItemBytes.Length)
                    Next key
                End If
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)
                Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}Content-Type: {3}{2}{2}"
                Dim header As String = String.Format(headerTemplate, fileParameterName, strFileName, newLine, contentType)
                Dim headerBytes As Byte() = Text.Encoding.UTF8.GetBytes(header)
                requestStream.Write(headerBytes, 0, headerBytes.Length)
                Dim byteImage As Byte() = GetImage(strPathAndFileName)
                requestStream.Write(byteImage, 0, byteImage.Length)
                Dim trailer As Byte() = Text.Encoding.ASCII.GetBytes(newLine & "--" + boundary + "--" & newLine)
                requestStream.Write(trailer, 0, trailer.Length)
            End Using
            Dim response As WebResponse = Nothing
        Catch e As Net.WebException
            MsgBox(e.Message)
        End Try
    End Sub
