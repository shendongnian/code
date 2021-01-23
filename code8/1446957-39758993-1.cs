    Imports Microsoft.AspNet.Identity
    Imports Microsoft.Owin
    Imports Microsoft.Owin.Security.Cookies
    Imports Owin
    Imports myApp.Users.Infrastructure
    Imports Microsoft.Owin.Security.Google
    Imports Microsoft.AspNet.SignalR
    Imports Microsoft.Owin.Cors
    Imports Microsoft.AspNet.SignalR.ServiceBus
    
    Namespace Users
        Public Class IdentityConfig
            Public Sub Configuration(app As IAppBuilder)
                app.CreatePerOwinContext(Of AppIdentityDbContext)(AddressOf AppIdentityDbContext.Create)
                app.CreatePerOwinContext(Of AppUserManager)(AddressOf AppUserManager.Create)
                app.CreatePerOwinContext(Of AppRoleManager)(AddressOf AppRoleManager.Create)
    
                app.UseCookieAuthentication(New CookieAuthenticationOptions() With { _
                    .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, _
                    .LoginPath = New PathString("/Account/Login") _
                })
    
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)
                app.MapSignalR()
            End Sub
        End Class
    End Namespace
