    ....
    var status = (bool)obj.SelectToken("success");
    
    if (!status)
       ModelState.AddModelError("", "Captcha entered is not valid"); 
       // This will make automatically ModelState.IsValid to false
    if (ModelState.IsValid)
    {
    ..........
