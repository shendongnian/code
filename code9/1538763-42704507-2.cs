    Public Class UnityConfig
    Public Shared Sub RegisterTypes(container As IUnityContainer)
        container.RegisterType(Of AccountController)(New InjectionConstructor(New ResolvedParameter(Of IDataContextAsync)))
    End Sub
    End Class
