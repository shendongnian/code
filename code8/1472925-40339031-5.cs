    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
    public class RegisterTenantCommandHandler : ICommandHandler<RegisterTenantCommand>
    {
        private readonly IHttpContext context;
        // You should really abstract this into a service/facade which hides
        // away the dependency on HttpContext
        public RegisterTenantCommandHandler(IHttpContextAccessor contextAccessor)
        {
            this.context = contextAccesspor.HttpContext;
        }
        public void Handle(RegisterTenantCommand command)
        {
            // Handle your command here
        }
    }
