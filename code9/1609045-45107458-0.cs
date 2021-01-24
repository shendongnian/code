    // GetECDsaPublicKey returns a unique object every call,
    // so you're responsible for Disposing it (lest it end up on the Finalizer queue)
    using (ECDsa ecdsa = msCert2.GetECDsaPublicKey())
    {
        // do stuff with the public key object
    }
