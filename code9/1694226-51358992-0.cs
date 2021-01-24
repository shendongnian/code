    using Microsoft.AspNetCore.Authorization;
    public class DomainRequirement : IAuthorizationRequirement
    {
        public string Domain { get; }
        public DomainRequirement(string domain)
        {
            Domain = domain;
        }
    }
