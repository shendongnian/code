    Imports System.Security.Cryptography
    Imports System.Collections.Specialized
    Imports System.IO
    
    Public Shared Sub HttpUploadFile(url As String, file As String, paramName As String, contentType As String, nvc As NameValueCollection)
    	Dim boundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
    	Dim boundarybytes As Byte() = Text.Encoding.ASCII.GetBytes((Convert.ToString(vbCr & vbLf & "--") & boundary) + vbCr & vbLf)
    
    	Dim wr As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
    	wr.ContentType = Convert.ToString("multipart/form-data; boundary=") & boundary
    	wr.Method = "POST"
    	wr.KeepAlive = True
    	wr.Credentials = Net.CredentialCache.DefaultCredentials
    
    	Dim rs As Stream = wr.GetRequestStream()
    
    	Dim formdataTemplate As String = "Content-Disposition: form-data; name=""{0}""" & vbCrLf & vbCrLf & "{1}"
    	For Each key As String In nvc.Keys
    		rs.Write(boundarybytes, 0, boundarybytes.Length)
    		Dim formitem As String = String.Format(formdataTemplate, key, nvc(key))
    		Dim formitembytes As Byte() = Text.Encoding.UTF8.GetBytes(formitem)
    		rs.Write(formitembytes, 0, formitembytes.Length)
    	Next
    	rs.Write(boundarybytes, 0, boundarybytes.Length)
    
    	Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCrLf & "Content-Type: {2}" & vbCrLf & vbCrLf
    	Dim header As String = String.Format(headerTemplate, paramName, file, contentType)
    	Dim headerbytes As Byte() = Text.Encoding.UTF8.GetBytes(header)
    	rs.Write(headerbytes, 0, headerbytes.Length)
    
    	Dim fileStream As New FileStream(file, FileMode.Open, FileAccess.Read)
    	Dim buffer As Byte() = New Byte(4095) {}
    	Dim bytesRead As Integer = 0
    	While (InlineAssignHelper(bytesRead, fileStream.Read(buffer, 0, buffer.Length))) <> 0
    		rs.Write(buffer, 0, bytesRead)
    	End While
    	fileStream.Close()
    
    	Dim trailer As Byte() = Text.Encoding.ASCII.GetBytes((Convert.ToString(vbCr & vbLf & "--") & boundary) + "--" & vbCr & vbLf)
    	rs.Write(trailer, 0, trailer.Length)
    	rs.Close()
    
    	Dim wresp As WebResponse = Nothing
    	Try
    		wresp = wr.GetResponse()
    		Dim stream2 As Stream = wresp.GetResponseStream()
    
    		Dim reader2 As New StreamReader(stream2)
    	Catch ex As Exception
    
    		If wresp IsNot Nothing Then
    			wresp.Close()
    			wresp = Nothing
    		End If
    	Finally
    		wr = Nothing
    	End Try
    End Sub
    
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
    	target = value
    	Return value
    End Function
