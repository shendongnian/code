     public async Task<bool>  ComposeEmail(string email, string subject)
            {
                var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
                emailMessage.Body = String.Empty;
    
               
                    var emailRecipient = new  Email.EmailRecipient(email);
                        emailMessage.To.Add(emailRecipient);
                        emailMessage.Subject = subject;
                
                 var x = (EmailManager.ShowComposeNewEmailAsync(emailMessage));
    
                await x; 
                return x.Status == AsyncStatus.Completed;
            }
    
