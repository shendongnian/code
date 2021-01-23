    Option Infer On
    Imports System.IO
    Imports System.Web
    Imports System.Web.Services
    
    ''' <summary>
    ''' Return a pdf document.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DownloadDoc
    	Implements System.Web.IHttpHandler
    
    	Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    
    		Dim srcDir As String = "~/pdfs"
    		Dim fileType As String = ".pdf"
    
    		Dim fname = context.Request.QueryString("name")
    		Dim actualFile = Path.Combine(context.Server.MapPath(srcDir), fname & suffix) & fileType
    
    		If File.Exists(actualFile) Then
    			context.Response.ContentType = "application/octet-stream"
    			context.Response.AddHeader("Content-Disposition", "attachment; filename=""" & Path.GetFileName(actualFile) & """")
    			context.Response.TransmitFile(actualFile)
    
    		Else
    			context.Response.Clear()
    			context.Response.TrySkipIisCustomErrors = True
    			context.Response.StatusCode = 404
    			context.Response.Status = "404 Not Found"
    			context.Response.Write("<html><head><title>404 - File not found</title><style>body {font-family: sans-serif;}</style></head><body><h1>404 - File not found</h1><p>Sorry, that file is not available for download.</p></body></html>")
    			context.Response.End()
    
    		End If
    
    	End Sub
    
    	ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
    		Get
    			Return False
    		End Get
    	End Property
    
    End Class
