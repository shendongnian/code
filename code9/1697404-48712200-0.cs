    public async Task<HttpStatusCode> GetResult()
    {
        var response = ValidateRegistrationStep3(accountModel);
        var result = await response.ExecuteAsync(new CancellationToken());
        var statusCode = result.StatusCode;
        return statusCode;
    }
