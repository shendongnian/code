        public static Expression<Func<ApplicationRole, ApplicationRoleDto>> SelectProperties = (role) => new ApplicationRoleDto
        {
            Id = role.Id,
            Name = role.Name.Substring(0, role.Name.Length - role.TenantId.Length),
            Description = role.Description,
            // another projection on Claims navigation property
            Claims = role.Claims.Select(claim => claim.ClaimValue).ToList(),
        };
