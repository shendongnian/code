    // SubjectPublicKeyInfo
    30 59  // SEQUENCE, 0x59 == 89 bytes of payload
       // AlgorithmIdentifier
       30 13  // SEQUENCE, 0x13 == 19 bytes of payload
          // AlgorithmIdentifier.algorithm
          06 07 2A 86 48 CE 3D 02 01  // OBJECT ID 1.2.840.10045.2.1 (id-ecPublicKey)
          // AlgorithmIdentifier.parameters
          06 08 2A 86 48 CE 3D 03 01 07 // OBJECT ID 1.2.840.10045.3.1.7 (secp256r1)
       // SubjectPublicKeyInfo.publicKey
       03 42 00  // BIT STRING, 0x42 == 66 (65) payload bytes, 0 unused bits
          // "the public key"
          04
          92F809EAC73630CD000055096D5383FE2DF860927C8A77AA4CDF83323A48E6AE
          DF40D3C4BFDCB6CFF79C3E5F2A3EEB3C7E54B888B38EC5DC06A05D6653D9707C
