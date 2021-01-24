    [HttpPost]
    public ActionResult Motors(MotorInput collection)// MotorInput is the class where CatId is set as int.(Model class)
               {
                 MotorInput obj = new MotorInput
                           {
                               CatID = collection.CatID,
                           };
                        return View(collection);
              }
