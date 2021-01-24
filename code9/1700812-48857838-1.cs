    var ct = new CancellationTokenSource(TimeSpan.FromSeconds(sec)).Token;
    await Task.Run(() => TrySomething(ct), ct);
    public bool TrySomething(CancellationToken ct)
    {
        var valueToReturne=false;
        while (!ct.IsCancellationRequested)
        {
            if (!MyCondition)
                        continue;
            else
                        valueToReturne = true;
        }
        return valueToReturne;
    }
