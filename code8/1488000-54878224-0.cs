    Imports System.Net.Http
    Imports System.Web.Http
    Imports System.Net
    Imports System.Threading
    Imports System.Threading.Tasks
    
    Public Class JsonStringResultExtension
      
        Public Shared Function JSONString(Controller As ApiController,
                                                    Optional jsonContent As String = "",
                                                 Optional statusCode As HttpStatusCode = HttpStatusCode.OK) As CustomJsonStringResult
    
            Dim result As New CustomJsonStringResult(Controller.Request, statusCode, jsonContent)
            Return result
            End Function
        
      End Class
        
        Public Class CustomJsonStringResult
            Implements IHttpActionResult
        
        Private json As String
        Private statusCode As HttpStatusCode
        Private request As HttpRequestMessage
    
        Public Sub New(httpRequestMessage As HttpRequestMessage, Optional statusCode As HttpStatusCode = HttpStatusCode.OK, Optional json As String = "")
            Me.request = httpRequestMessage
            Me.json = json
            Me.statusCode = statusCode
        End Sub
    
        Public Function ExecuteAsync(cancellationToken As CancellationToken) As Task(Of HttpResponseMessage) Implements IHttpActionResult.ExecuteAsync
            Return Task.FromResult(Execute())
        End Function
    
        Private Function Execute() As HttpResponseMessage
            Dim response = request.CreateResponse(statusCode)
            response.Content = New StringContent(json, Encoding.UTF8, "application/json")
            
            Return response
        End Function
    
    
    End Class
