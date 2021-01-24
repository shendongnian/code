    Imports System.Linq.Expressions
    
    Public Class ProjectMvcViewPage(Of T)
    	Inherits WebViewPage(Of T)
    
    
    	Public Overrides Sub InitHelpers()
    
    		MyBase.InitHelpers()
    
    		Framework = New FrameworkHelper(Of T)(MyBase.ViewContext, Me)
    
    	End Sub
    
    
    
    	Public Overrides Sub Execute()
    
    	End Sub
    
    
    
    	Public Overloads Property Framework As FrameworkHelper(Of T)
    
    
    End Class
    
    Public Class ProjectMvcViewPage
    	Inherits ProjectMvcViewPage(Of Object)
    
    End Class
    
    
    
    
    Public Class FrameworkHelper(Of T)
    	Inherits HtmlHelper(Of T)
    
    	Public Sub New(ByVal viewContext As ViewContext, ByVal viewDataContainer As IViewDataContainer)
    		MyBase.New(viewContext, viewDataContainer)
    	End Sub
    
    	Public Sub New(ByVal viewContext As ViewContext, ByVal viewDataContainer As IViewDataContainer, ByVal routeCollection As RouteCollection)
    		MyBase.New(viewContext, viewDataContainer, routeCollection)
    	End Sub
    
    
    
    	'	TODO:	Framework-specific methods
    
    End Class
    
    Public Class FrameworkHelper
    	Inherits AkcHtmlHelper(Of Object)
    
    	Public Sub New(ByVal viewContext As ViewContext, ByVal viewDataContainer As IViewDataContainer)
    		MyBase.New(viewContext, viewDataContainer)
    	End Sub
    
    	Public Sub New(ByVal viewContext As ViewContext, ByVal viewDataContainer As IViewDataContainer, ByVal routeCollection As RouteCollection)
    		MyBase.New(viewContext, viewDataContainer, routeCollection)
    	End Sub
    
    End Class
