       [Authorize]
        public ActionResult EditClient(string id)
        {
            editClientValidator.Validate(id);
        var user= new Token(this.User.Identity.Name);
        //user.id
        //user.accountId
    
        //So does this Client belong to the same account as the user is in?
        //We know the client and user both belong to an account(id)
        //Are we allowed to return the below?
        var client = _clientService.GetClient(id);
        //client.id
        //client.accountId
        }
