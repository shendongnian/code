        public static async Task AssignRoleToPrincipalAsync(
            string accessToken, 
            string subscriptionId, 
            string scope, 
            string roleName,
            string principalObjectId)
        {
            using (var client = NewAuthorizationManagementClient(accessToken, subscriptionId))
            {
                RoleDefinition roleDef = (await FindRoleDefinitionAsync(accessToken, subscriptionId, scope, roleName)).FirstOrDefault();
                if (roleDef == null)
                    throw new Exception($"Role was not found: {roleName}");
                var props = new RoleAssignmentProperties()
                {
                    PrincipalId = principalObjectId,
                    RoleDefinitionId = roleDef.Id
                };
                await client.RoleAssignments.CreateAsync(scope, Guid.NewGuid().ToString("N"), props);
            }
        }
        private static AuthorizationManagementClient NewAuthorizationManagementClient(string accessToken, string subscriptionId)
        {
            return new AuthorizationManagementClient(new TokenCredentials(accessToken)) { SubscriptionId = subscriptionId};
        }
