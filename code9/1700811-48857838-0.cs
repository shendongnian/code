    public bool TrySomething(int sec)
    {
        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(sec)).Token;
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
