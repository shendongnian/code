    <Authorize(Roles:="Administrator, Guest")>
    Public Class GuestController
    Inherits Controller
        <ClaimsAuthorize("GuestClaim")>
                Public Function GetCustomers() As ActionResult
                    Dim guestClaim As Integer = UserManager.GetClaims(User.Identity.GetUserId()).Where(Function(f) f.Type = "GuestClaim").Select(Function(t) t.Value).FirstOrDefault()
        
                    Dim list = _customerService.GetCustomers(guestClaim)
        
                    Return Json(list, JsonRequestBehavior.AllowGet)
                End Function
    
    End Class
