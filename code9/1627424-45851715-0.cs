    public IObservable<IList<ExampleResponseModel>> ListExamplesRx()
    {
        var url = string.Format(Routes.Examples.List);
        return ExecuteRequestAsync<IList<ExampleResponseModel>>(url, HttpMethod.Get)
            .ToObservable();
    }
