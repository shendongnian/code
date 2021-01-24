    private async sometype SomeMethodAsync()
    {
        for (int _Job = 1; _Job <= 3; _Job++)
        {
            string _Message = await DoSomeWorkAsync2(_Job);
            Console.WriteLine("Message: {0}", _Message);
        }
    }
    private async Task<string> DoSomeWorkAsync2(int _job)
    {
        string _StringToReturn = string.Empty;
        switch (_job)
        {
            case 1:
            _StringToReturn = await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Message From Task 1";
            });
            break;
            case 2:
            _StringToReturn = await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "Message From Task 2";
            });
            break;
            case 3:
            _StringToReturn = await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Message From Task 3";
            });
            break;
        }
    }
