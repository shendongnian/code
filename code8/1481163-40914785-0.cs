         public static AuthenticationProperties CreateProperties(User user)
                {
    //get only roles ids
    //to do: retrieve user roles names 
                    var roles = string.Join(",", user.Roles.Select(t => t.RoleId).ToArray());
    //expose phone in response
                    var phone = user.PhoneNumber;
                    IDictionary<string, string> data = new Dictionary<string, string>
                    {
                        { "userName", user.UserName },
                        { "userId", user.Id },
                        { "roles", roles},
                        { "phone", phone}
                    };
                    return new AuthenticationProperties(data);
                }
