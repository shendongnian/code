        public static bool Verify(byte[] payment, byte[] signature)
        {
            var pub = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDSiXzUuH9ePZgSLYrzZ0qhta25HCb+WG48wIKUl+cQNC/Fl/KZG2cSwRXdo8KZLVWWO5qwzplfTWEylg4IqRA48rYYf/b+Y7QhORKeAws4pttLZJBbh1mIbZ9HXfQ+zBjP+zfJZ1YjSFs2uZdwSt1itUcJ/GQFct8GoUevNELG7wIDAQAB";
            
            byte[] raw = Convert.FromBase64String(pub);
            AsymmetricKeyParameter aKey = PublicKeyFactory.CreateKey(raw);
            RsaKeyParameters rKey = (RsaKeyParameters)aKey;
            PssSigner pss = new PssSigner(new RsaEngine(), new Sha1Digest(), 20);
            pss.Init(false, rKey);
            pss.BlockUpdate(payment, 0, payment.Length);
            var res = pss.VerifySignature(signature);
            return res;
        }
