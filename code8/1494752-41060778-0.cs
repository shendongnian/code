    [HttpPost]
    public ActionResult Edit(FormCollection formCollection)
    {
        foreach(var key in formCollection.AllKeys)
        {
            var value = formCollection[key];
        }
    }
