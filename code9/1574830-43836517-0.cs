    if (request.Password != null)
                {
                    var valid = await new PasswordValidator<User>().ValidateAsync(_userManager, user, request.Password);
    
                    if (!valid.Succeeded)
                    {
                        return StatusCode((int)HttpStatusCode.Conflict, new ErrorResponse
                        {
                            ErrorMessage = string.Join(Environment.NewLine, valid.Errors.Select(x => x.Description))
                        });
                    }
    
                    var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
                    user.PasswordHash = hashedPassword;
                }
