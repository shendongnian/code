    [HttpGet]
    public HttpResponseMessage SmsAnswerCallBack(string id)
    {
        _smsAnswerCallBackCallIndex++;
        var r = new SmsApiResult();
    
        r.SetStatus(true, _smsSendCallIndex, _smsAnswerCallBackCallIndex);
        r.DataList  = _answers;
    
        var res     = Request.CreateResponse(HttpStatusCode.OK);
        res.Content = new StringContent("<Response/>", Encoding.UTF8, "text/xml");
        return res;
    }
