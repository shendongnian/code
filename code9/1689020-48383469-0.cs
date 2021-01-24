    [HttpPost]
    public HttpResponseMessage GetUserRequestsByStatuses([FromBody] DataRequest model)
    {
        DataResponse<AngKendoGridDashboard> response = 
            BusinessAccess.GetUserRequestsByStatuses(model);
        return CreateHttpResponse(response);
    }
