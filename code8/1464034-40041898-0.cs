    public class ValidateNote : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity) {
                Entity note = (Entity)context.InputParameters["Target"];
                // you can also use "subject" instead of "description"
                if (string.IsNullOrEmpty(note.GetAttributeValue<string>("description")) || string.IsNullOrEmpty(note.GetAttributeValue<string>("filename")))
                {
                    throw new InvalidPluginExecutionException("Please add an attachment and description");
                }
            }
        }
    }
