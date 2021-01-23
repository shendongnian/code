    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Function Login(model As LoginModel) As ActionResult
        If (ModelState.IsValid) Then
            Dim userValid = Membership.ValidateUser(model.Email, model.Password)
            If (userValid) Then
                FormsAuthentication.SetAuthCookie(model.Email, False)
                Dim membershipProvider = New Program.Security.MoleculeraMembershipProvider()
                Dim redirectUrl = FormsAuthentication.GetRedirectUrl(model.Email, False)
                If redirectUrl.Contains("sales") Then
                    Return RedirectToAction("SalesPortal")
                Else
                    Return RedirectToAction("AdminPortal")
                End If
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If
        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function
