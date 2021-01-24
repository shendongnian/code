    Class ModifyPasswordView 
    {
        public string OldPassword {get;set;}
        public string NewPassword {get;set;}
        public bool NewPasswordConfirm {get;set;}
    }
    [HttpPost]
    public ActionResult ModifyPassword( ModifyPasswordView passwordView)
    {
         if ( ModelState.IsValid )
         {
            ...
         }
    }
