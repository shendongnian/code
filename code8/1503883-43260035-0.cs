    public Guid UpgradeSolution(string solutionUniqueName, IOrganizationService service)
    {
        var request = new DeleteAndPromoteRequest
        {
            UniqueName = solutionUniqueName
        };
        var response = (DeleteAndPromoteResponse)service.Execute(request);
        return response.SolutionId;
    }
