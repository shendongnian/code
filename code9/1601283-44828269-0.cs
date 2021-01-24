    public ActionResult Test(YourModel model)
    {
        if(!model.IsValid){
            var isDateValid = ModelState.IsValidField("Date");
            .... // your code here
        }
        ...... // your code here
    }
