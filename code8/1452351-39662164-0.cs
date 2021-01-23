    /// <summary>
    /// Gets the single step KDF using Hash SHA256.
    /// NIST SP800 56Ar2 Section 5.8.1.1
    /// </summary>
    /// <param name="OtherInfo">The other information.</param>
    /// <param name="PrivateKey">The private key.</param>
    /// <param name="PublicKey">The public key.</param>
    /// <param name="DesiredKeyBitLength">Length of the desired key bit.</param>
    /// <returns>Byte[].</returns>
    private static Byte[] getSingleStepKDF_SHA256(  Byte[]  OtherInfo,
                                                    Byte[]  PrivateKey,
                                                    Byte[]  PublicKey,
                                                    Int32   DesiredKeyBitLength
                                                 )
    {
      ByteAccumulator             ba                      = null;
      Byte[]                      data                    = null;
      Byte[]                      secret                  = null;
      int                         keyDataLenInBits        = 0;
      int                         keyLenInBytes           = 0;
      uint                        reps                    = 0;
      uint                        cntr                    = 0;
    
      secret = getSharedSecret( PrivateKey, PublicKey );
    
      if( secret != null )
      {
        #region Single-Step KDF
        keyDataLenInBits  = DesiredKeyBitLength;
        keyLenInBytes     = ( int )( DesiredKeyBitLength / 8 );
    
        reps = ( uint )( keyDataLenInBits / 128 ); //  Our hash length is 128 bytes
    
        if( reps > ( UInt32.MaxValue - 1 ) )
          new Exception( "reps too large" );
    
        cntr = 1;
    
        if( ( 4 + ( secret.Length * 8 ) + ( OtherInfo.Length * 8 ) ) > 256 )
          new Exception( "data is too large" );
    
        ba = new ByteAccumulator();
        ba.IsBigEndian = true;
    
        data = General.CatArray<Byte>( BitConverter.GetBytes( cntr ).Reverse().ToArray(),
                                        secret,
                                        OtherInfo );
    
        for( int i = 1; i <= reps; i++ )
        {
          ba.AddBlock( SecureHashAlgorithm.GetSha256_BouncyCastle( data ), 32 );
    
          //  Increment counter modulo 2^32
          cntr = ( uint )( cntr++ % 32 );
    
          data = General.CatArray<Byte>( BitConverter.GetBytes( cntr ).Reverse().ToArray(),
                                          secret,
                                          OtherInfo );
        }
    
        return ba.ToArray().Take( keyLenInBytes ).ToArray();
        #endregion Single-Step KDF
      }
      else
        return null;
    }
    
    /// <summary>
    /// Gets the shared secret.
    /// </summary>
    /// <param name="PrivateKeyIn">The private key in.</param>
    /// <param name="PublicKeyIn">The public key in.</param>
    /// <returns>Byte[].</returns>
    private static Byte[] getSharedSecret( Byte[] PrivateKeyIn, Byte[] PublicKeyIn )
    {
      ECDHCBasicAgreement         agreement             = new ECDHCBasicAgreement();
      X9ECParameters              curve                 = null;
      ECDomainParameters          ecParam               = null;
      ECPrivateKeyParameters      privKey               = null;
      ECPublicKeyParameters       pubKey                = null;
      ECPoint                     point                 = null;
    
      curve     = NistNamedCurves.GetByName( "P-256" );
      ecParam   = new ECDomainParameters( curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed() );
      privKey   = new ECPrivateKeyParameters( new BigInteger( PrivateKeyIn ), ecParam );
      point     = ecParam.Curve.DecodePoint( PublicKeyIn );
      pubKey    = new ECPublicKeyParameters( point, ecParam );
    
      agreement.Init( privKey );
    
      BigInteger secret = agreement.CalculateAgreement( pubKey );
    
      return secret.ToByteArrayUnsigned();
    }
