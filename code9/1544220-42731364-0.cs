    [HttpPost]
    [AllowAnonymous]
    [CaptchaValidation("ContactCaptchaCode", "ContactCaptcha", "Please enter the correct CAPTCHA code.")]
    public ActionResult Create(Models.Contact formContact)
    {
        if(!ModelState.IsValid)
      {
          return view(formContact);
      }
    
        //if valid do your code here
    }
