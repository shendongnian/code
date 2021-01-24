    await Observable
        .Range(0, requests.Count)
        .Select(i => Observable.FromAsync(async () =>
        {
            responses.Add(await client.FederalService.VerifyAsync(requests[i]));
            Console.Write(".");
        }))
        .FirstAsync(r => /* do the check here */)
        .Subscribe(Console.WriteLine);
