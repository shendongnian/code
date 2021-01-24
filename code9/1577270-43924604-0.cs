        public SHA256Managed()
        {
    #if FEATURE_CRYPTO
            if (CryptoConfig.AllowOnlyFipsAlgorithms)
                throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
            Contract.EndContractBlock();
    #endif // FEATURE_CRYPTO
 
            _stateSHA256 = new UInt32[8];
            _buffer = new byte[64];
            _W = new UInt32[64];
 
            InitializeState();
        }
