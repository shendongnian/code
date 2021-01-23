        /// <devdoc>
        ///    Initializes FormsAuthentication by reading
        ///    configuration and getting the cookie values and encryption keys for the given
        ///    application.
        /// </devdoc>
        public static void Initialize() {
            if (_Initialized)
                return;
             lock(_lockObject) {
                if (_Initialized)
                    return;
                 AuthenticationSection settings = RuntimeConfig.GetAppConfig().Authentication;
                settings.ValidateAuthenticationMode();
                _FormsName = settings.Forms.Name;
                _RequireSSL = settings.Forms.RequireSSL;
                _SlidingExpiration = settings.Forms.SlidingExpiration;
                if (_FormsName == null)
                    _FormsName = CONFIG_DEFAULT_COOKIE;
                 _Protection = settings.Forms.Protection;
                _Timeout = (int) settings.Forms.Timeout.TotalMinutes;
                _FormsCookiePath = settings.Forms.Path;
                _LoginUrl = settings.Forms.LoginUrl;
                if (_LoginUrl == null)
                    _LoginUrl = "login.aspx";
                _DefaultUrl = settings.Forms.DefaultUrl;
                if (_DefaultUrl == null)
                    _DefaultUrl = "default.aspx";
                _CookieMode = settings.Forms.Cookieless;
                _CookieDomain = settings.Forms.Domain;
                _EnableCrossAppRedirects = settings.Forms.EnableCrossAppRedirects;
                _TicketCompatibilityMode = settings.Forms.TicketCompatibilityMode;
                 _Initialized = true;
            }
        }
