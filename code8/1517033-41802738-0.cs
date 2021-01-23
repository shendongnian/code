    public static Tuple<TResponse, ResponseStatus, ResponseErrorType> GetResponse<TRequest, TResponse>(Func<TRequest, TResponse> action, TRequest request)
    {
        var status = ResponseStatus.Fail;
        var errorType = ResponseErrorType.None;
        var response = default(TResponse);
        try
        {
            response = action(request);
            status = ResponseStatus.Success;
        }
        catch (CustomException ex)
        {
            errorType = ResponseErrorType.CustomError;
        }
        catch (TimeoutException ex)
        {
            errorType = ResponseErrorType.Timeout;
        }
        catch (Exception ex)
        {
            errorType = ResponseErrorType.GeneralFailure;
        }
        return new Tuple<TResponse, ResponseStatus, ResponseErrorType>(response, status, errorType);
    }
