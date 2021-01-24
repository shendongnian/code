    public ActionResult Test(YourModel model)
    {
        if(!ModelState.IsValidField("Date"))
        {
            var futureDateError = new ModelError("Future date is not allowed");
            var dataFormatError = new ModelError("Must be a Date (DD/MM/YEAR)");
            bool IsFutureDateError = ModelState["Date"].Errors.Contains(futureDateError);
            bool isFormatError     = ModelState["Date"].Errors.Contains(dataFormatError);
        }
        ...... // your code here
    }
