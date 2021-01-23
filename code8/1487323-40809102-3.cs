    using System.Security.Principal;
    public interface IPrincipalProvider
    {
        IPrincipal User { get; }
    }
