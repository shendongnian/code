    await Observable
        .Range(0, requests.Count)
        .Select(i => Observable.FromAsync(async () =>
        {
            responses.Add(await client.FederalService.VerifyAsync(requests[i]));
            Console.Write(".");
        }))
        .FirstAsync()
        .Subscribe(Console.WriteLine);
    > System.Reactive.Linq.ObservableImpl.Defer`1[System.Reactive.Unit]
