    <head>
        @using System.DirectoryServices.AccountManagement;
    </head>
    
    <body>
        @{
            var context = new PrincipalContext(ContextType.Domain);
            var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
            var firstName = principal.GivenName;
            var lastName = principal.Surname;
        }
    <p class="navbar-brand"> @firstName @lastName </p>
    </body>
