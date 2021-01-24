    <Export(GetType(IComponent))>
    Public Class DependencyResolver
        Implements IComponent
        Public Sub SetUp(registerComponent As IRegisterComponent) Implements IComponent.SetUp
            'General
            registerComponent.RegisterType(Of IDataContextAsync, dbEcommEntities)()  
    
            'DomainLogic
            registerComponent.RegisterType(Of IUserDomainLogic, MfrUserDomainLogic)()
    
            'Services
            registerComponent.RegisterType(Of ICompanyService, CompanyService)()
           
        End Sub
    
    End Class
