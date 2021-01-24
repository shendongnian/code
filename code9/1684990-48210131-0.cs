    public class UserServices : IUserServices {
        GraphServiceClient GetAuthenticatedClient() {
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        string accessToken = await SampleAuthProvider.Instance.GetAccessTokenAsync();
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
                        requestMessage.Headers.Add("Prefer", "outlook.timezone=\"" + TimeZoneInfo.Local.Id + "\"");
                    }));
            return graphClient;
        }
        public Task<IGroupMembersCollectionWithReferencesPage> GetGroupMembers(string groupID) {
            var graphClient = GetAuthenticatedClient();
            return graphClient.Groups[groupID].Members.Request().GetAsync();
        }
    }
