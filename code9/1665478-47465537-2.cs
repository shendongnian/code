    public class CustomTicketSerializer : IDataSerializer<AuthenticationTicket>
    {
        public const string RoleBitMaskType = "RoleBitMask";
        private readonly IDataSerializer<AuthenticationTicket> _standardSerializers = DataSerializers.Ticket;
        public static SecureDataFormat<AuthenticationTicket> CreateCustomTicketFormat(IAppBuilder app)
        {
            var tokenProtector = app.CreateDataProtector(typeof(OAuthAuthorizationServerMiddleware).Namespace, "Access_Token", "v1");
            var customTokenFormat = new SecureDataFormat<AuthenticationTicket>(new CustomTicketSerializer(), tokenProtector, TextEncodings.Base64Url);
            return customTokenFormat;
        }
        public byte[] Serialize(AuthenticationTicket ticket)
        {
            var identity = ticket.Identity;
            var otherClaims = identity.Claims.Where(c => c.Type != identity.RoleClaimType);
            var roleClaims = identity.Claims.Where(c => c.Type == identity.RoleClaimType);
            var encodedRoleClaim = new Claim(RoleBitMaskType, EncodeRoles(roleClaims.Select(rc => rc.Value)));
            var modifiedClaims = otherClaims.Concat(new Claim[] { encodedRoleClaim });
            ClaimsIdentity modifiedIdentity = new ClaimsIdentity(modifiedClaims, identity.AuthenticationType, identity.NameClaimType, identity.RoleClaimType);
            var modifiedTicket = new AuthenticationTicket(modifiedIdentity, ticket.Properties);
            return _standardSerializers.Serialize(modifiedTicket);
        }
        public AuthenticationTicket Deserialize(byte[] data)
        {
            var ticket = _standardSerializers.Deserialize(data);
            var identity = ticket.Identity;
            var otherClaims = identity.Claims.Where(c => c.Type != RoleBitMaskType);
            var encodedRoleClaim = identity.Claims.SingleOrDefault(c => c.Type == RoleBitMaskType);
            if (encodedRoleClaim == null)
                return ticket;
            var roleClaims = DecodeRoles(encodedRoleClaim.Value).Select(r => new Claim(identity.RoleClaimType, r));
            var modifiedClaims = otherClaims.Concat(roleClaims);
            var modifiedIdentity = new ClaimsIdentity(modifiedClaims, identity.AuthenticationType, identity.NameClaimType, identity.RoleClaimType);
            return new AuthenticationTicket(modifiedIdentity, ticket.Properties);
        }
    }
