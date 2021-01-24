            public override void WillSendRequestForAuthenticationChallenge(NSUrlConnection connection, NSUrlAuthenticationChallenge challenge)
        {
            Console.WriteLine(challenge.ProtectionSpace);
            if (challenge.PreviousFailureCount == 0 )
            {
                NSUrlCredential cred = new NSUrlCredential(this.myUserName, this.myPass, NSUrlCredentialPersistence.None);
                challenge.Sender.UseCredential(cred, challenge);
            }
       
        }
              
