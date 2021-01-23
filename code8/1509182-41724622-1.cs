     public class DeleteTodoAuthorisationHandler : IAuthorisationHandler<DeleteTodoCommand, ICommandResult>
    {
        private IMediator _mediator;
        private IAuthorizationService _authorisationService;
        private IHttpContextAccessor _httpContextAccessor;
        public DeleteTodoAuthorisationHandler(IMediator mediator, IAuthorizationService authorisationService, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _authorisationService = authorisationService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ICommandResult> Handle(DeleteTodoCommand request)
        {
            if (await _authorisationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, "DeleteTodo"))
            {
                return new SuccessResult();
            }
            var message = "You do not have permission to delete a todo";
            _mediator.Publish(new AuthorisationFailure(message));
            return new FailureResult(message);
        }
    }
