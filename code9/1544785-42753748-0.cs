        login.Click += async delegate 
        {
            activityIndicator.Visibility = Android.Views.ViewStates.Visible;
            
            var auth = new UsersAuthentication();
            var result = await auth.UsersAuthenTask(email.Text,password.Text, StartActivity, new Intent(this, typeof(IndMassActivity)));
            if (!result) {
              AuthorizationFailed();
            }
        };
