    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    
    namespace ClaimsIdentityExample
    {
        public class Program
        {
            class ClaimDTO
            {
                public string Issuer { get; set; }
                public string OriginalIssuer { get; set; }
                public string Type { get; set; }
                public string Value { get; set; }
                public string ValueType { get; set; }
            }
            class ClaimsIdentityDTO
            {
                public string Name { get; set; }
                public string AuthenticationType { get; set; }
                public bool IsAuthenticated { get; set; }
                public string NameClaimType { get; set; }
                public string RoleClaimType { get; set; }
                public string Label { get; set; }
    
                public List<ClaimDTO> Claims { get; set; }
    
                public ClaimsIdentityDTO()
                {
                    Claims = new List<ClaimDTO>();
                }
            }
            static ClaimsIdentityDTO CreateFrom(ClaimsIdentity ci)
            {
                ClaimsIdentityDTO ciDTO = new ClaimsIdentityDTO() {
                    Name = ci.Name,
                    AuthenticationType = ci.AuthenticationType,
                    IsAuthenticated = ci.IsAuthenticated,
                    Label = ci.Label,
                    NameClaimType = ci.NameClaimType,
                    RoleClaimType = ci.RoleClaimType
                };
                foreach (var claim in ci.Claims)
                {
                    var claimDTO = new ClaimDTO() {
                        Issuer = claim.Issuer,
                        OriginalIssuer = claim.OriginalIssuer,
                        Type = claim.Type,
                        Value = claim.Value,
                        ValueType = claim.ValueType
                    };
                    ciDTO.Claims.Add(claimDTO);
                }
                return ciDTO;
            }
            public static void Main(string[] args)
            {
                // Just for test in Console Application
                Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                ClaimsIdentity ci = new ClaimsIdentity(((WindowsPrincipal)Thread.CurrentPrincipal).Identity);
                // Create DTO object
                var ciDTO = CreateFrom(ci);
                // Serialize it to json
                var json = JsonConvert.SerializeObject(ciDTO, Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
