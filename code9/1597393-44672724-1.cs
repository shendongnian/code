    loginBtn.Click += (object sender, EventArgs e) =>
            {
                user = username.Text.ToString();
                pass = password.Text.ToString();
                Toast.MakeText(this, user + " : " + pass, ToastLength.Long).Show();
            };
