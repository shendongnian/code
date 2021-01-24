    [ResponseType(typeof(returnObject))]
    public async Task<IHttpActionResult> GetAsync()
    {      
        var t1 = Task.Run(() => service.getdata1());
        var t2 = Task.Run(() => service.getdata2());
        var t3 = Task.Run(() => service.getdata3());
        await Task.WhenAll(t1, t2, t3);
        var data = new returnObject
        {
            d1 = t1.Status == TaskStatus.RanToCompletion ? t1.Result : null,
            d2 = t2.Status == TaskStatus.RanToCompletion ? t2.Result : null,
            d3 = t3.Status == TaskStatus.RanToCompletion ? t3.Result : null
        };
       return Ok(data);
    }
