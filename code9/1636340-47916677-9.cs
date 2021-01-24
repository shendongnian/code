            if (IsInteractive(activationArgs))
            {
                var defaultHandler = new DefaultLaunchActivationHandler(_defaultNavItem);
                if (defaultHandler.CanHandle(activationArgs))
                {
                    await defaultHandler.HandleAsync(activationArgs);
                }
                if (((IActivatedEventArgs)activationArgs).Kind == ActivationKind.Protocol)
                {
                    var protocolEventArgs = activationArgs as ProtocolActivatedEventArgs;
                    App.KPMPClient.ResumeWithURL(protocolEventArgs.Uri);
                }
                // Ensure the current window is active
                Window.Current.Activate();
                // Tasks after activation
                await StartupAsync();
            }
