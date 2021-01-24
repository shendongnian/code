    OpenAccount(person);
    var principle = new GenericPrincipal( new GenericIdentity($"{person.FirstName} {person.LastName}"), new string[] {"All"});
    var data = Konstants.Serialize(principle);
    var ticket = new FormsAuthenticationTicket(1, principle.Identity.Name, DateTime.Now, DateTime.Now.AddMinutes(30), true, data);
    var encryptedTicket = FormsAuthentication.Encrypt(ticket);
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
    Response.SetCookie(cookie);
    Response.RedirectToRoute("Default");
