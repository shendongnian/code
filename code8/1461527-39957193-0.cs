    void OnEmailFrameTapped(object sender, EventArgs args)
        {
            Frame f = (Frame)sender;
            string emailstring = string.Empty;
            
            var fcontent = f.Content;
            var myStacklayout = fcontent.GetType();
            if (myStacklayout == typeof (StackLayout))
            {
               StackLayout fStacklayout = (StackLayout)fcontent;
                var listChildren = fStacklayout.Children;
                var reqLabel = listChildren[1];
                var theLabel = reqLabel.GetType();
                if (theLabel == typeof(Label))
                {
                   Label emailLabel = (Label)reqLabel;
                    emailstring = emailLabel.Text;
                }
            }
            
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail(emailstring,
                    "Test Sender",
                    "Hello from message");
            }
        }
