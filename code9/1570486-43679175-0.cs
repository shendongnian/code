    class PostModel
    {
        public string DataValue1 {get; set;}
        public string DataValue2 {get; set;}
    }
    [HttpPost]
    public ActionResult prepareOpelData(PostModel model)
    {
        var dataValue1 = model.DataValue1;
        ....
    }
