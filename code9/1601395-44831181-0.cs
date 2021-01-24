        public async Task<Member> GetMemberByOrganizationId(string organizationId)
        {
            var task =
                await
                    // ReSharper disable once UseStringInterpolation
                    _httpClient.GetAsync(string.Format("mdm/rest/api/members/member?accountId={0}", organizationId)).ConfigureAwait(false);
            task.EnsureSuccessStatusCode();
            var payload = task.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Member>(await payload.ConfigureAwait(false),
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
