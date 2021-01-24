    Partial Class Error
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
                If Session("userid") <> "" Then
                    'Ho avuto una eccezione vera !
                    Dim ex As Exception = Application("errore")
                    Application("errore") = Nothing
                    If IsNothing(ex) Then
                        ex = Server.GetLastError()
                    End If
                    If Not IsNothing(ex) Then
                        Dim bex As Exception = ex.GetBaseException
                        If IsNothing(bex) Then
                            bex = ex
                        End If
                        'Show details of exception bex on page or store in DB
                        Catch exall As Exception
                        End Try
                    End If
                End If
            End If
        End If
    End Sub
    End Class
