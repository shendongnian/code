    public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
            {
                		
                     await UserManager.SendEmailAsync(user.Id, "Reset Password", *"Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>"*);
                    
                }
