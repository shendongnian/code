    Imports System.IO
    Imports System.Net
    
    Partial Class TestWebRequest
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("https://en.wikipedia.org"), HttpWebRequest)
                request.Timeout = 30000
                Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Dim receiveStream As Stream = response.GetResponseStream()
                Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)
                webRequestResponse.Text = "Result: " + readStream.ReadToEnd() + Environment.NewLine
                response.Close()
                readStream.Close()
            Catch ex As Exception
                webRequestResponse.Text = "Error Message: " + ex.ToString()
            End Try
        End Sub
    End Class
