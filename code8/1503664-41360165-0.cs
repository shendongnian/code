    public ActionResult Login(bool? loggedOnOtherDevice){
        if (loggedOnOtherDevice.GetValueOrDefault()){
            // Here, add code or update your model to display the message
        }
        return View();
    }
