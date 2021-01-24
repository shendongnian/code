    public async Task<ActionResult> SampleView()
    {
        Tasks ts = new Tasks();
        return View(await ts.GetDeviceCurrentLocation());
    }
