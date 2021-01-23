    <WebMethod>
    Public Function GetAllSpeakers(SubSite As String, MyUsername As String, MyPassword As String) As String
        If ValidateUser(MyUsername, MyPassword) Then
            If (HttpRuntime.Cache("CacheSpeakers") Is Nothing) Then
                Try
                    Dim passWordEnc As SecureString = New SecureString()
                    For Each c As Char In Password.ToCharArray()
                        passWordEnc.AppendChar(c)
                    Next
                    Dim subContext As ClientContext = New ClientContext("url")
                    subContext.Credentials = New SharePointOnlineCredentials(Username, passWordEnc)
                    Dim json As String = JsonConvert.SerializeObject(LibraryMethods.Methods.GetSpeakers(subContext))
                    HttpRuntime.Cache.Insert("CacheSpeakers", json, Nothing,
                    Cache.NoAbsoluteExpiration, New TimeSpan(0, 30, 0),
                    CacheItemPriority.NotRemovable, Nothing)
                    Return json
                Catch ex As Exception
                    Return "ERROR: " & ex.InnerException.ToString
                End Try
            Else
                Return HttpRuntime.Cache("CacheSpeakers").ToString()
            End If
        Else
            Return "AUTHENTICATION FAILED"
        End If
    End Function
