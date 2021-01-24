    Imports System.Collections.Specialized
    Imports System.IO
    Imports System.Net
    Public Class DataUpload
    Dim res As String
    Public Function sendHttpRequest(url As String, values As 
    NameValueCollection, Optional files As NameValueCollection = Nothing) As 
    String
        Dim boundary As String = "----------------------------" + 
      DateTime.Now.Ticks.ToString("x")
        Dim boundaryBytes As Byte() = System.Text.Encoding.UTF8.GetBytes((Convert.ToString(vbCr & vbLf & "--") & boundary) + vbCr & vbLf)
        Dim trailer As Byte() = System.Text.Encoding.UTF8.GetBytes((Convert.ToString(vbCr & vbLf & "--") & boundary) + "--" & vbCr & vbLf)
        Dim boundaryBytesF As Byte() = System.Text.Encoding.ASCII.GetBytes((Convert.ToString("--") & boundary) + vbCr & vbLf)
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        request.ContentType = Convert.ToString("multipart/form-data; boundary=") & boundary
        request.Method = "POST"
        request.KeepAlive = True
        request.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim requestStream As Stream = request.GetRequestStream()
        For Each key As String In values.Keys
            Dim cntDisp = "Content-Disposition: form-data; name=""{0}"";" & vbCr & vbLf & vbCr & vbLf & "{1}"
            Dim formItemBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(String.Format(cntDisp, key, values(key)))
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)
            requestStream.Write(formItemBytes, 0, formItemBytes.Length)
        Next
        Dim count = 0
        If files IsNot Nothing Then
            For Each key As String In files.Keys
                If File.Exists(files(key)) Then
                    Dim bytesRead As Integer = 0
                    Dim buffer As Byte() = New Byte(2048) {}
                    Dim cnt As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCr & vbLf
                    Dim cntype As String = "Content-Type: application/octet-stream" & vbCr & vbLf & vbCr & vbLf
                    Dim formItemBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(String.Format(cnt & cntype, key, files(key)))
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)
                    requestStream.Write(formItemBytes, 0, formItemBytes.Length)
                    Using fileStream As New FileStream(files(key), FileMode.Open, FileAccess.Read)
                        While (BytesDataHelper(bytesRead, fileStream.Read(buffer, 0, buffer.Length))) <> 0
                            requestStream.Write(buffer, 0, bytesRead)
                        End While
                    End Using
                End If
            Next
        End If
        requestStream.Write(trailer, 0, trailer.Length)
        requestStream.Close()
        Dim reader As New StreamReader(request.GetResponse().GetResponseStream())
        res = reader.ReadToEnd()
        Return res
    End Function
    Private Shared Function BytesDataHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function
     End Class
