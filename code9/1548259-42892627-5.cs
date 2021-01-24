    public ApproveFamilyOutput ApproveFamily(ApproveFamilyInput input)
    {
        var approveService = diContainer.Get<ApproveService>(); // Or correctly injected by constructor
        var result = approveService.ApproveFamily(input);
        // Convert to ouput
    }
