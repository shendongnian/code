    [Route("save")]
    [HttpPost]
    public async Task<IHttpActionResult> Save([ModelBinder(typeof (GenericModelBinder<MyModel>))] MyModel model)
    {
        try
        {
            //do some stuff with model (validate it, etc)
            await Task.CompletedTask;
            DbContext.SaveResult(model.my_to, model.my_from, model.my_date);
            return Content(HttpStatusCode.OK, "OK", new TextMediaTypeFormatter(), "text/plain");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            Logger.Error(e, "Error saving to DB");
            return InternalServerError();
        }
    }
