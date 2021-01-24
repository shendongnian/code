    [HttpPost]
    public IHttpActionResult LoadById(String id)
    {
       using (var mng = new UserManager())
       {         
          var domainUser = mng.LoadById(String id);
          var apiUser = new MyUserViewModel
          {
              // Map visible properties ...
              Name = domainUser.UserName,
              // Change the shape
              Address = domainUser.Address.Postal,
              ...
              // Hide fields that shouldn't be externally accessed
          };
          return Ok(apiUser);
       }
    }
