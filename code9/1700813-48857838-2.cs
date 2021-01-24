    var ct = new CancellationTokenSource(TimeSpan.FromSeconds(sec)).Token;
    await TrySomething(ct);
    public async Task<bool> TrySomethingAsync(CancellationToken ct)
    {
        var valueToReturne=false;
        while (!ct.IsCancellationRequested)
        {
            if (!await MyConditionAsync(ct))
                        continue;
            else
                        valueToReturne = true;
        }
        return valueToReturne;
    }
