    using (RSA rsa = cert.GetRSAPrivateKey())
    {
        RSACng rsaCng = rsa as RSACng;
        RSACryptoServiceProvider rsaCsp = rsa as RSACryptoServiceProvider;
        if (rsaCng != null)
        {
            // Set the PIN, an explicit null terminator is required to this Unicode/UCS-2 string.
            byte[] propertyBytes;
            if (pin[pin.Length - 1] == '\0')
            {
                propertyBytes = Encoding.Unicode.GetBytes(pin);
            }
            else
            {
                propertyBytes = new byte[Encoding.Unicode.GetByteCount(pin) + 2];
                Encoding.Unicode.GetBytes(pin, 0, pin.Length, propertyBytes, 0);
            }
            const string NCRYPT_PIN_PROMPT_PROPERTY = "SmartCardPinPrompt";
            CngProperty pinProperty = new CngProperty(
                NCRYPT_PIN_PROMPT_PROPERTY,
                propertyBytes,
                CngPropertyOptions.None);
            rsaCng.SetProperty(pinProperty);
        }
        else if (rsaCsp != null)
        {
            // This is possible, but painful.
            // Copy out the CspKeyContainerInfo data into a new CspParameters,
            // build the KeyPassword value on CspParameters,
            // Dispose() the existing instance,
            // and open a new one to replace it.
            //
            // But if you really called GetRSAPrivateKey() and it has returned an RSACng for
            // your device once, it pretty much will forever (until the next
            // new RSA type for Windows is invented... at which point it still
            // won't return an RSACryptoServiceProvider).
        }
        else
        {
            // No other built-in RSA types support setting a PIN programmatically.
        }
        // Use the key here.
        // If you needed to return it, don't put it in a using :)
    }
