    public class OAuthCallbackController : ApiController
    {
        [HttpGet]
        [Route("api/OAuthCallback")]
        public async Task OAuthCallback(string state, [FromUri] CancellationToken cancellationToken, [FromUri] string accessToken, [FromUri] string username)
        {
            var resumptionCookie = ResumptionCookie.GZipDeserialize(state);
            var message = resumptionCookie.GetMessage();
            message.Text = "UserIsAuthenticated";
            using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
            {
                var dataBag = scope.Resolve<IBotData>();
                await dataBag.LoadAsync(cancellationToken);
                dataBag.PrivateConversationData.SetValue("accessToken", accessToken);
                dataBag.PrivateConversationData.SetValue("username", username);
                ResumptionCookie pending;
                if (dataBag.PrivateConversationData.TryGetValue("persistedCookie", out pending))
                {
                    dataBag.PrivateConversationData.RemoveValue("persistedCookie");
                    await dataBag.FlushAsync(cancellationToken);
                }
            }
            await Conversation.ResumeAsync(resumptionCookie, message, cancellationToken);
        }
