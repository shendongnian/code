    private static void PairingRequestedHandler(DeviceInformationCustomPairing sender, DevicePairingRequestedEventArgs args)
    {
        switch (args.PairingKind)
        {
            case DevicePairingKinds.ConfirmOnly:
                // Windows itself will pop the confirmation dialog as part of "consent" if this is running on Desktop or Mobile
                // If this is an App for 'Windows IoT Core' or a Desktop and Console application
                // where there is no Windows Consent UX, you may want to provide your own confirmation.
                args.Accept();
                break;
    
            case DevicePairingKinds.ProvidePin:
                // A PIN may be shown on the target device and the user needs to enter the matching PIN on 
                // this Windows device. Get a deferral so we can perform the async request to the user.
                var collectPinDeferral = args.GetDeferral();
                string pinFromUser = "952693";
                if (!string.IsNullOrEmpty(pinFromUser))
                {
                    args.Accept(pinFromUser);
                }
                collectPinDeferral.Complete();
                break;
        }
    }
