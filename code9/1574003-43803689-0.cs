    [HttpPost]
    public async Task<ActionResult> Test()
    {
        Debug.WriteLine("Test was loaded");
        Manager instance = new Manager();
        var client = await instance.StartMyTask();
        return Content("Caption: " + client.Description.Captions[0].Text);
    }
