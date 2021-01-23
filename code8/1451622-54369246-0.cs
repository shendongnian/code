     [HttpGet]
    [Route("[controller]/ManageAccessView/{name}/{id}",Name = "ManageAccessView")]
    [Route("[controller]/ManageAccessUsers/{name}/{id}", Name = "ManageAccessUsers")]
    [Route("[controller]/ManageAccessKeys/{name}/{id}", Name = "ManageAccessKeys")]
    public async Task<IActionResult> ManageAccessView(int id, string name)
    {
      var requestedView = this.ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;
      return View(requestedView);
    }
