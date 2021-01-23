    ResponseStatus GetPotatoList(Action action1, Action action2, GetPotatosRequest requestParam, out GetPotatosResponse response, out ResponseErrorType errorType)
    {
        ResponseStatus status = ResponseStatus.Fail;
        response = new GetPotatosResponse();
        action1();
        try
        {
            action2();
            status = ResponseStatus.Success;
        }
        catch(CustomException ex)
        {
            errorType = ResponseErrorType.CustomError;
        }
        catch(TimeoutException ex)
        {
            errorType = ResponseErrorType.Timeout;
        }
        catch(Exception ex)
        {
            errorType = ResponseErrorType.GeneralFailure;
        }
        return status;
    }
