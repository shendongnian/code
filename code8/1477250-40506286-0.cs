    public class MessagesController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity, CancellationToken token)
        {
            if (activity != null)
            {
                switch (activity.GetActivityType())
                {
                    case ActivityTypes.Message:
                        var container = WebApiApplication.FindContainer();
                        using (var scope = DialogModule.BeginLifetimeScope(container, activity))
                        {
                            await Conversation.SendAsync(activity, () => scope.Resolve<IDialog<object>>(), token);
                        }
                        break;
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
