    public class MapAllClaimsAction : ClaimAction
        {
            public MapAllClaimsAction() : base(string.Empty, string.Empty)
            {
            }
     
            public override void Run(JObject userData, ClaimsIdentity identity, string issuer)
            {
                foreach (var claim in identity.Claims)
                {
                    // If this claimType is mapped by the JwtSeurityTokenHandler, then this property will be set
                    var shortClaimTypeName = claim.Properties.ContainsKey(JwtSecurityTokenHandler.ShortClaimTypeProperty) ?
                        claim.Properties[JwtSecurityTokenHandler.ShortClaimTypeProperty] : string.Empty;
     
                    // checking if claim in the identity (generated from id_token) has the same type as a claim retrieved from userinfo endpoint
                    JToken value;
                    var isClaimIncluded = userData.TryGetValue(claim.Type, out value) || userData.TryGetValue(shortClaimTypeName, out value);
     
                    // if a same claim exists (matching both type and value) both in id_token identity and userinfo response, remove the json entry from the userinfo response
                    if (isClaimIncluded && claim.Value.Equals(value.ToString(), StringComparison.Ordinal))
                    {
                        if (!userData.Remove(claim.Type))
                        {
                            userData.Remove(shortClaimTypeName);
                        }
                    }
                }
     
                // adding remaining unique claims from userinfo endpoint to the identity
                foreach (var pair in userData)
                {
                    JToken value;
                    var claimValue = userData.TryGetValue(pair.Key, out value) ? value.ToString() : null;
                    identity.AddClaim(new Claim(pair.Key, claimValue, ClaimValueTypes.String, issuer));
                }
            }
        }
