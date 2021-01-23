    public ActionResult ViewName(int param) {
        if (!CheckIfParamIsValid(Id)) {
            // Do the thing you want to do, if the value is not valid, e.g. throw a page not found/404.
            return new HttpNotFoundResult("No data found for param " + param);
        }
        var model = /*Go get your data using the param, knowing that it's now safe */
        return View(model);
    }
    /// <summary>
    /// Function to check if your param is a value you expect to receive or not
    /// </summary>
    /// <param name="param">the value you are testing, hopefully called something more descriptive than 'param')</param>
    private bool CheckIfParamIsValid(int param) { 
        //Example logic for checking if the param's between 1-5
        return Enumerable.Range(1,5).Contains(param);
    }
