    [HttpPost]
    public ActionResult Edit(FormDataCollection formDataCollection)
    {
        var nvc = formDataCollection.ReadAsNameValueCollection(); 
        foreach(var key in nvc)
        {
            var value = nvc[key];
        }
    }
