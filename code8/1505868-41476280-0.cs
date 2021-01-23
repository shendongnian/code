    public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
    {
        base.PrepareForSegue(segue, sender);
        switch (segue.Identifier)
        {
            case "UserLoginSegue":
                UserLoginController loginSheet = segue.DestinationController as UserLoginController;
                var theView = loginSheet.View;
                loginSheet.Username = "";
                loginSheet.Password = "";
                loginSheet.Presentor = this;
                loginSheet.DialogAccepted += (object s, EventArgs e) => { Console.WriteLine("OK Clicked"); };
                loginSheet.DialogCanceled += (object s, EventArgs e) => { Console.WriteLine("Cancel Clicked"); };
                break;
        }
    }
