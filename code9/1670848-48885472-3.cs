    public async Task<GenericResponse> ConfirmEmail(SetPasswordBindingModel model)
        {
            var response = new GenericResponse();
            if (model != null)
            {
                try
                {
                    var user = await _aspNetUserService.GetByEmail(model.Email);
                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(model.VerificationCode))
                        {
                            //if time difference is less than 5 minutes then proceed
                            var originalKey = Utility.Decrypt(model.VerificationCode);
                            if (user.Email == originalKey)
                            {
                                var emailConfirmationCode = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                                var result = await UserManager.ConfirmEmailAsync(user.Id, emailConfirmationCode);
                                if (result.Succeeded)
                                {
                                    var status = await _aspNetUserService.ResetVerificationCode(model.Email);
                                    if (status)
                                    {
                                        response.Message = AppConstants.EmailConfirmed;
                                        response.IsSuccess = true;
                                    }
                                }
                                else
                                {
                                    response.Message = AppConstants.Error;
                                    response.IsSuccess = false;
                                }
                            }
                            else
                            {
                                response.Message = AppConstants.InvalidVerificationCode;
                                response.IsSuccess = false;
                            }
                        }
                        else
                        {
                            response.Message = AppConstants.InvalidVerificationCode;
                            response.IsSuccess = false;
                        }
                    }
                    else
                    {
                        response.Message = AppConstants.NoUserFound;
                        response.IsSuccess = false;
                    }
                }
                catch (Exception ex)
                {
                    //response.Message = AppConstants.Error;
                    response.Message = ex.Message;
                }
            }
            return response;
        }
