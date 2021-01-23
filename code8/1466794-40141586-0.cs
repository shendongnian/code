    [HttpPost]
    public JsonResult Proj1Action(YourModelHere somedata)
    {
        //some data modification here
        ...
        SomeModel modifiedModelData = new SomeModel
        {
             name = "testname"
        }
        return JSON(modifiedModelData);
    }
