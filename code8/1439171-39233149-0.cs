        public static async Task<IServicePrincipal> GetServicePrincipalAsync(string accessToken, string tenantId, string clientId)
        {
            var graphClient = NewActiveDirectoryClient(accessToken, tenantId);
            var matches = await graphClient.ServicePrincipals.Where(sp => sp.AppId == clientId).ExecuteAsync();
            return matches.CurrentPage.ToList().FirstOrDefault();
        }
        private static ActiveDirectoryClient NewActiveDirectoryClient(string accessToken, string tenantId)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            tcs.SetResult(accessToken);
            return new ActiveDirectoryClient(
                new Uri($"{GraphApiBaseUrl}{tenantId}"),
                async () => { return await tcs.Task; });
        }
