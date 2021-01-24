    public virtual async void RecordSegment(IRoadSegment segment)
    {
        _cancellationToken = new CancellationTokenSource();
        var token = _cancellationToken.Token;
        // await user clicking points on map
        await CollectPoints(token);
        // update the current segment with the collected shape.
        CurrentSegment.Shape = CurrentGeometry as Polyline;
    }
    // collect an arbitrary number of points and build a polyline.
    private async Task CollectPoints(CancellationToken token)
    {
        var points = new List<MapPoint>();
        while (!token.IsCancellationRequested)
        {
            try
            {
                // wait for a new point.
                var point = await CollectPoint(token);
                //...
            }
            catch (Exception) { }
        }
    }
    private TaskCompletionSource<MapPoint> tcs;
    protected override Task<MapPoint> CollectPoint()
    {
        tcs = new TaskCompletionSource<MapPoint>();
        //...
        return tcs.Task;
    }
    public void StopSegment()
    {
        // interrupt the CollectPoints task.
        _cancellationToken.Cancel();
        tcs.SetCanceled();
    }
