    private async void ValidateLogin()
    {
        MainWindow mw = Window.GetWindow(this) as MainWindow;
        mw.preloaderShow();
        Task<Usuario> taskLogin = Login(tbLogin.Text, tbPassword.Password);
        await taskLogin;
        Usuario user = taskLogin.Result;
        if (user != null)
        {
            if (user.Activo == 0)
            {
                mw.preloaderHide();
                CustomMessageBox WrongLoginMessage = new CustomMessageBox("El usuario esta inactivo.");
                WrongLoginMessage.ShowDialog();
            }
            else
            {
                AppSession.Instance.SetValue("currentuser", user);
                btnProceed.Visibility = Visibility.Visible;
                mw.preloaderHide();
            }
        }
    }
    public Task<Usuario> Login(string loginText, string password)
    {
        return Task.Run(() =>
        {
            return new Usuario();
        });
    }
