    public ActionResult MyController(string url, [ModelBinder(typeof(StringArrayModelBinder))] string[] ids)
    {
        Response.Write("<input id='url' value='" + url + "'>");
        foreach (string id in ids)
        {
            Response.Write("<input id='orderIds[" + id + "]' value='" + id + "'>");
        }
        return View();
    }
