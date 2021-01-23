    using System;
    
    namespace RSAKeyTests
    {
        class Demo
        {
            static void Main(string[] args)
            {
                //EXPORTED KEYS
                string importedPublicKeyBase64 = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhbVC4aUR+XRCepBcPlod69wruXqwW9yL/YJYvuaQ33QxUoAehQ0z4SuphHwEPxQp/qLqucmE6XKlEeTksFAmaGM88uuGessqMZmdu9WFhc07MWLTCifR43IRtGEeWeFSWjUI6mNRrShP3QQ3+Z6e7w+HRA2RpmgNgEhJRvECHAKpcpHvP9o5Sq6q/dIAyR6NEjRFhfud27rFtnWrLj+ZmIsScemvks4vh8V3n8EzxxRE8nzVuZYr4v4NNH+q95XgIadHZ1Y6ICXJgX2NfacNRQl9+SEv0Wo8lbmFSIO3jHqyiWuSugv7R3/rQPRXHT6HJAtw0tBiPOBitMkTzqOvIwIDAQAB";
                string importedPrivateKeyBase64 = "MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCFtULhpRH5dEJ6kFw+Wh3r3Cu5erBb3Iv9gli+5pDfdDFSgB6FDTPhK6mEfAQ/FCn+ouq5yYTpcqUR5OSwUCZoYzzy64Z6yyoxmZ271YWFzTsxYtMKJ9HjchG0YR5Z4VJaNQjqY1GtKE/dBDf5np7vD4dEDZGmaA2ASElG8QIcAqlyke8/2jlKrqr90gDJHo0SNEWF+53busW2dasuP5mYixJx6a+Szi+HxXefwTPHFETyfNW5livi/g00f6r3leAhp0dnVjogJcmBfY19pw1FCX35IS/RajyVuYVIg7eMerKJa5K6C/tHf+tA9FcdPockC3DS0GI84GK0yRPOo68jAgMBAAECggEAJ/Dalr8RnHvPM/+Vnoaa847kfNaaggZixwq96eDEHAwAg82D0Gj+O2AolkvZlOI4HTmbdn4tNvMpPiwq6EQ5BOvIFCSpGltAMmraBHcnGK4S5ZDIy/rTJuc3RLPSNjUpvYqkLCgZCOnG2ZXeBrIMdgskc/69qIDir5RoV0m9QJJYU7pfrfErWYr/eqb1t7eZtTBAg+LAjKUMUq68WoJiBSBRPbAvlyFoc6tyk0ftngsF4OPVbwZQyYC2vLmxVrr1/YQbEgjpuJwQ0bONL6G9PAH6O+h10ILk9nyJY2c9gOXU0tz+foJ47naM12wCJETEy9JGeAiN4NLz5wRKTZzZwQKBgQDCOEJGDgtmSM0bDv4vPuxbacFgGTgRAKTs6sG9E1Cf3LNBLDP9OhfRkXFc192PmQRAktaZAN89zXeGxK1tLbJ3003qKXw05K3KOksVjJ7AH4Yhurv3VWmFZB8pryUsxIp+rm/5GLf4LfptUmBO6R4+jTfJVRBtK4A9KmkbY7BjgwKBgQCwPWayTgd0fmDqJxptWfPThcUw3/cG6EWTpnx1dSOdaBHzewRwq/8/i4vs314/onLggXgZTIkPU7y8ylTmz5KcaPIQkmRSSSL0Y2yzMGcHnylj7ysgBLw23k/PVzGSsMZ6ly7lE03SNQ3tyg6u0lc3pbT8ZLHf/x913stxSSiT4QKBgQChdgnKmZRqhS1WSGGSP3pZCJNFY9HTeLijaQqFOFB3hg/Tp37VDv2MMKCQsbi0z13UnP4glrQAehbbCBixQiMzMIx+ldx3UIEWNN4E3TGAwPROiCIJnY0q4rBxg/SgwgftBvF5oU4X2YluZuQ/1ddZ4ya0jq4oQ9jJgL9+kKKsJwKBgQCndbBfPEVZK7xqwT0bKp3EHxd/mU/gAFQcN9WKxgNRTdHAyOMvLD8c4jvSl2u2i2UcbejwIQkaxzZPLPH/XrywYgegN3mbtmLAVLi0iwla9KEfk+ImSlmMyTCMkw1HlTECyySEBhOr6T2S9Kt+8d5twcZ3DDb34DLEjS5CNoGYAQKBgDCEyhrg2lwyYwrL26ohNNuzgiabC5IKCgHlMpsUQjoCid9awCSb2iROf7iZIBoDyzXqgEQWTAf2clpJxgHz0necVw2sXP8wGcJXJ+e/lXNfPaC4z2QRnQ6i2iV88jRlWLK+S403hGnK0L/SDu9LtBhHwy6r/qRGT14ourqS6x7O";
                byte[] importedPublicKeyBytes = Convert.FromBase64String(importedPublicKeyBase64);
                byte[] importedPrivateKeyBytes = Convert.FromBase64String(importedPrivateKeyBase64);
    
                //PRINT INFO
                Console.WriteLine("------   IMPORTED KEY PAIR:   ------\n");
                Console.WriteLine("PUBLIC KEY:\n"+importedPublicKeyBase64+"\n\n");
                Console.WriteLine("PRIVATE KEY:\n" + importedPrivateKeyBase64 + "\n\n");
    
                //GENERATING RSACRYPTOSERVICEPROVIDER FROM X509 PUBLIC KEY BLOB
                using (var providerFromX509pubKey = RSAKeyUtils.DecodePublicKey(importedPublicKeyBytes))
                {
                    providerFromX509pubKey.PersistKeyInCsp = false; //DO NOT STORE IN KEYSTORE
    
                    //EXPORT TO X509 PUBLIC KEY BLOB
                    byte[] x509pubKeyBytes = RSAKeyUtils.PublicKeyToX509(providerFromX509pubKey.ExportParameters(false));
    
                    //CONVERT TO BASE64
                    string x509pubKeyBase64 = Convert.ToBase64String(x509pubKeyBytes);
    
                    //PRINT INFO
                    Console.WriteLine("------   PUBLIC KEY TO EXPORT   ------");
                    Console.WriteLine("Public key to export matches imported? "+importedPublicKeyBase64.Equals(x509pubKeyBase64));
                    Console.WriteLine(x509pubKeyBase64+"\n\n");
                }
    
                //GENERATING RSACRYPTOSERVICEPROVIDER FROM PKCS8 PRIVATE KEY BLOB
                using (var providerFromPKCS8privKey = RSAKeyUtils.DecodePrivateKeyInfo(importedPrivateKeyBytes))
                {
                    providerFromPKCS8privKey.PersistKeyInCsp = false; //DO NOT STORE IN KEYSTORE
    
                    //EXPORT TO PKCS8 PRIVATE KEY BLOB
                    byte[] pkcs8privKeyBytes = RSAKeyUtils.PrivateKeyToPKCS8(providerFromPKCS1privKey.ExportParameters(true));
    
                    //CONVERT TO BASE64
                    string pkcs8privKeyBase64 = Convert.ToBase64String(pkcs8privKeyBytes);
    
                    //PRINT INFO
                    Console.WriteLine("------   PRIVATE KEY TO EXPORT   ------");
                    Console.WriteLine("Private key to export matches imported? " + importedPrivateKeyBase64.Equals(pkcs8privKeyBase64));
                    Console.WriteLine(pkcs8privKeyBase64);
                }
    
                    //PREVENTS THE PROGRAM FROM EXITING
                    Console.ReadKey();
            }
        }
    }
    
