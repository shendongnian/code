        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject;
            var requestedClaimTypes = context.RequestedClaimTypes;
            var user = await _userProvider.FindByIdAsync(subject.GetSubjectId());
            if (user == null) throw new ArgumentException("Invalid user id");
            var claims = GetClaimsFromUser(user);
            if (requestedClaimTypes != null && requestedClaimTypes.Any()) claims = claims.Where(m => requestedClaimTypes.Contains(m.Type));
            context.IssuedClaims = claims;
        }
        private IEnumerable<Claim> GetClaimsFromUser(User model)
        {
            var claims = model.Claims.Select(ModelFactory.Create).ToList();
            if (model.EmailConfirmed) claims.Add(new Claim(Constants.ClaimTypes.EmailVerified, model.EmailConfirmed ? "true": "false"));
            return claims;
        }
