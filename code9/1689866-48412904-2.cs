    public interface IHasErrors
    {
        List<Error> Errors { get; }
    }
    Policy<THasErrors> CreateExceptionPolicy<THasErrors>() where THasErrors:IHasErrors
    {
        return Policy.HandleResult<THasErrors>(
                result => result.Errors.ContainsExceptionMessage())
            .Or<Exception>()
            .Retry();
    }
