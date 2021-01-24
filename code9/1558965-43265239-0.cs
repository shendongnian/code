    public async Task ShoudListVms()
    {
        var testCase = new BotTestCase()
        {
            Action = "list vms",
            ExpectedReply = "Available VMs are",
        };
        await TestRunner.RunTestCase(testCase);
    }
