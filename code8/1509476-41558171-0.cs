public void Init(HttpApplication app) {
            // authentication is an app level setting only
            // so we can read app config early on in an attempt to try and
            // skip wiring up event delegates
            if (!_fAuthChecked) {
                _fAuthRequired = (AuthenticationConfig.Mode == AuthenticationMode.Forms);
                _fAuthChecked = true;
            }
                        if (_fAuthRequired) {
                // initialize if mode is forms auth
                 **FormsAuthentication.Initialize();**
                 app.AuthenticateRequest += new EventHandler(this.OnEnter);
                app.EndRequest          += new EventHandler(this.OnLeave);
            }
        }
