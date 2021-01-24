    public ActionResult actionA (ViewModel_Shared modelA)
    {
            var serializedModel = JsonConvert.SerializeObject(modelA);
            return RedirectToAction("actionC", "controllerC", serializedModel);
    }
