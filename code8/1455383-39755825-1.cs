        If Request.IsAuthenticated Then
            Dim ident As FormsIdentity = CType(User.Identity, FormsIdentity)
            If ident IsNot Nothing Then
                Dim ticket As FormsAuthenticationTicket = ident.Ticket
                Dim userDataString As String = ticket.UserData
                Select Case ticket.UserData
                    Case "Member"
                        m_MemberLoggedIn = ident.Name
                    Case Else
                        Response.Redirect("~/members/login/", True)
                End Select
            Else
                Response.Redirect("~/members/login/", True)
            End If
