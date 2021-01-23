    using System.Security.Principal;
    ...
    GenericPrincipal genericPrincipal = GetGenericPrincipal();
    GenericIdentity principalIdentity = (GenericIdentity)genericPrincipal.Identity;
    string fullName = principalIdentity.Name;
