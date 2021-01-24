    public KeyValuePair<int, string> SendMail (my values) {
        int StatusCode;
        string StatusMessage;
        // ===== standard message building code =====
        try {
            // ===== smtp client setup code =====
            smtp.Send(mail);
            StatusCode = 250;                      // Standard SMTP OK
            StatusMessage = "Message Sent";
        }
        catch (SmtpFailedRecipientException rx) {
            LogExceptionSMTP(rx, message.To);
            StatusCode = (int)rx.StatusCode;
            StatusMessage = rx.Message;
        }
        catch (SmtpException sx) {
            LogExceptionSMTP(sx, message.To);
            StatusCode = (int)sx.StatusCode;
            StatusMessage = sx.Message;
        }
        catch (Exception ex) {
            ex.Data.Add( "SendMail_Recipient", message.To );
            LogException(ex);
            StatusCode = 500;                      // Standard App Error Code
            StatusMessage = ex.Message;
        }
