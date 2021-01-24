    public void Test()
    {
        var dogService = SomeMockingFramework.CreateSubstituteFor<IDogService>();
        var vm = new AddDogVM(dogService);
        vm.Add(...);
        
        // Assertions
    }
