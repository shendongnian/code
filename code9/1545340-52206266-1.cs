                 public async Task<IHttpActionResult> ChangeEmail(ChangeEmailModel model) 
                 {
                       try
                       {
                    HttpUtility.UrlEncode(model.Code);                   
                    if ( !UserManager.VerifyUserToken(model.UserId, "ChangeEmail", model.Code)) //to verify the code
                    {
                        _logger.Error($"token expired");
                        return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new KeyValuePair<String, String>(Messages.ExpiredLink, CommonMessages.ExpiredLink)));
                    }
                    else
                    {
                        UserDetailsManager userDetailsManager = new UserDetailsManager();
                        string Email = userDetailsManager.GetNewEmail(model.UserId);//get the new email from the temporary table
                        var user = await UserManager.FindByIdAsync(model.UserId);
                        user.Email = Email;//change the email
                        user.UserName = Email;
                        result = await UserManager.UpdateAsync(user);
                        if (!result.Succeeded)
                        {
                            foreach (var item in result.Errors)
                            {
                                if (item.Contains("already"))
                                {
                                    _logger.Info("In ChangeEmail user already exists");
                                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, new KeyValuePair<String, String>(Messages.EmailUserExist, CommonMessages.EmailUserExist)));
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                _logger.Error($"In ChangeEmail Error - {ex.Message} return {HttpStatusCode.InternalServerError}");
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new KeyValuePair<String, String>(Messages.InternalServerError, CommonMessages.InternalServerError)));
            }
            _logger.Info($"ChangeEmail end status {HttpStatusCode.OK} ");
            return Ok("Success");
        }`
