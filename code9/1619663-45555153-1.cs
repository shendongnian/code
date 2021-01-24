    using System.IO;
    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Asn1.Pkcs;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
    
    namespace RSADecryptWithBouncy
    {
        class MainClass
        {
    
            private static KeyParameter Unwrap(byte [] key, AsymmetricKeyParameter privKeyParam) {
    			var wrapper = WrapperUtilities.GetWrapper("RSA/NONE/PKCS1PADDING");
                wrapper.Init(false, privKeyParam);
                var aesKeyBytes = wrapper.Unwrap(key, 0, key.Length);
                return new KeyParameter(aesKeyBytes);
    		}
    
            public static void Main(string[] args)
            {
                var privKeyBytes = File.ReadAllBytes("../../privkey.der");
                var seq = Asn1Sequence.GetInstance(privKeyBytes);
                var rsaKeyParams = PrivateKeyFactory.CreateKey(PrivateKeyInfo.GetInstance(seq));
                var wrappedKey = File.ReadAllBytes("../../wrappedKey");
                var aesKey2 = Unwrap(wrappedKey, rsaKeyParams);
            }
        }
    }
