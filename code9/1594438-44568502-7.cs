        [BotAuthentication(CredentialProviderType = typeof(MultiCredentialProvider))]
        public class MessagesController : ApiController
    {
        static MessagesController()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => ((ClaimsIdentity)HttpContext.Current.User.Identity).GetCredentialsFromClaims())
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.Update(Conversation.Container);
        }
