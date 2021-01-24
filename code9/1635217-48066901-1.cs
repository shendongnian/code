    public class ResponseMediator : IResponseMediator
    {
        private readonly ICqsMediator _mediator;
        public ResponseMediator(ICqsMediator mediator)
        {
            Guard.IsNotNull(mediator, nameof(mediator));
            _mediator = mediator;
        }
        public async Task<IActionResult> ExecuteAsync(
            ICommand command, CancellationToken token = default(CancellationToken)) =>
            HandleResult(await _mediator.ExecuteAsync(command, token).ConfigureAwait(false));
        public async Task<IActionResult> ExecuteAsync<TResponse>(
            ICommandQuery<TResponse> commandQuery, CancellationToken token = default(CancellationToken)) =>
            HandleResult(await _mediator.ExecuteAsync(commandQuery, token).ConfigureAwait(false));
        public async Task<IActionResult> ExecuteAsync<TResponse>(
            IQuery<TResponse> query, CancellationToken token = default(CancellationToken)) =>
            HandleResult(await _mediator.ExecuteAsync(query, token).ConfigureAwait(false));
        private IActionResult HandleResult<T>(IResult<T> result)
        {
            if (result.IsSuccessful)
            {
                return new OkObjectResult(result.Data);
            }
            return HandleResult(result);
        }
        private IActionResult HandleResult(IResult result)
        {
            if (result.IsSuccessful)
            {
                return new OkResult();
            }
            if (result.BrokenRules?.Any() == true)
            {
                return new BadRequestObjectResult(new {result.BrokenRules});
            }
            if (result.HasConcurrencyError)
            {
                return new BadRequestObjectResult(new {Message = CommonResource.Error_Concurrency});
            }
            if (result.HasNoPermissionError)
            {
                return new UnauthorizedResult();
            }
            if (result.HasNoDataFoundError)
            {
                return new NotFoundResult();
            }
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return new BadRequestObjectResult(new {Message = result.ErrorMessage});
            }
            return new BadRequestObjectResult(new {Message = CommonResource.Error_Generic});
        }
    }
