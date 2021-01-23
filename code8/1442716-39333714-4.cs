    Private Shared Function GetImage(ByVal URL As String) As Byte()
        GetImage = Nothing
        ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True
        Dim Request As HttpWebRequest = Nothing
        Dim Response As HttpWebResponse = Nothing
        Try
            Request = WebRequest.Create(URL)
            'request.Proxy = New WebProxy("127.0.0.1", 8888)    'Proxy Entry for Tracing with Fiddler
            Request.Credentials = CredentialCache.DefaultCredentials
            Response = CType(Request.GetResponse, WebResponse)
            If Request.HaveResponse Then
                If Response.StatusCode = Net.HttpStatusCode.OK Then
                    GetImage = convertStreamToByte(Response.GetResponseStream)
                End If
            End If
        Catch e As WebException
            MsgBox(e.Message)
        End Try
        Return GetImage
    End Function
