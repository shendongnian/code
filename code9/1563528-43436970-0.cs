    [HttpPost]
    public void ApproveOrRejectAll([FromBody]ApproveOrRejectAllModel model) {
        List<int> Ids = model.Ids;
        string Status = model.Status;
        //..other code
    }
