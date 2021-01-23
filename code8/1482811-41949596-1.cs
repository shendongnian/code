    protected override void OnCreate(Bundle savedInstanceState)
    {
                base.OnCreate(savedInstanceState);
    
                
    #if DEBUG
                if (!IsMyServiceRunning("FCMRegistrationService"))
                {
                    var intent = new Intent(this, typeof(FCMRegistrationService));
                    StartService(intent);
                }
    
                // For debug mode only - will accept the HTTPS certificate of Test/Dev server, as the HTTPS certificate is invalid /not trusted
                ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
    #endif
    
    }
