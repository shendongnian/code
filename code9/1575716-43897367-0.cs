    SubjectPublicKeyInfo ::= SEQUENCE {
      algorithm AlgorithmIdentifier {{ECPKAlgorithms}} (WITH COMPONENTS {algorithm, parameters}),
      subjectPublicKey BIT STRING
    }
    ECPKAlgorithms ALGORITHM ::= {
      ecPublicKeyType |
      ecPublicKeyTypeRestricted |
      ecPublicKeyTypeSupplemented |
      {OID ecdh PARMS ECDomainParameters {{SECGCurveNames}}} |
      {OID ecmqv PARMS ECDomainParameters {{SECGCurveNames}}},
      ...
    }
    ecPublicKeyType ALGORITHM ::= {
      OID id-ecPublicKey PARMS ECDomainParameters {{SECGCurveNames}}
    }
    ECDomainParameters{ECDOMAIN:IOSet} ::= CHOICE {
      specified SpecifiedECDomain,
      named ECDOMAIN.&id({IOSet}),
      implicitCA NULL
    }
    An elliptic curve point itself is represented by the following type
      ECPoint ::= OCTET STRING
    whose value is the octet string obtained from the conversion routines given in Section 2.3.3.
