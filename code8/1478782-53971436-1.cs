    protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);
            if (args.Kind == ActivationKind.Protocol)
            {
                ProtocolActivatedEventArgs protocolArgs = (ProtocolActivatedEventArgs)args;
                Uri uri = protocolArgs.Uri;
                Debug.WriteLine("Authorization Response: " + uri.AbsoluteUri);
                locator.AccountsService.GoogleExternalAuthWait.Set(uri.Query);
            }
        }
