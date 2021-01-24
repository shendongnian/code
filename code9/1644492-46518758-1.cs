    public void AttemptLogin()
    {
        Client client = _model.GetClient(_view.Email, _view.Password);
        if (client != null)
        {
            client.LoginRedirect(_view);
        }
        else
        {
            _view.Message = "Login Failed";
        }
    }
