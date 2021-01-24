    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;
    
    namespace RsaTest
    {
      class Program
      {
        static void Main(string[] args)
        {
          var signature = new byte[]
          {
            193, 185, 118, 187, 54, 28, 71, 173, 185, 255, 213, 61, 254, 51, 86, 168, 224, 11, 113, 23, 81, 123, 89,
            31, 89, 183, 142, 194, 7, 250, 194, 165, 230, 254, 74, 61, 15, 12, 137, 246, 151, 61, 83, 107, 112, 178,
            98, 183, 234, 247, 56, 11, 246, 179, 183, 74, 27, 190, 17, 99, 161, 31, 209, 178, 81, 41, 56, 214, 184, 165,
            232, 20, 125, 155, 25, 102, 104, 193, 1, 101, 143, 209, 192, 145, 47, 215, 190, 95, 196, 164, 69, 203, 206, 69,
            142, 18, 196, 155, 221, 8, 31, 179, 5, 165, 143, 29, 34, 148, 218, 177, 94, 31, 174, 218, 153, 52, 85, 156, 67,
            2, 157, 29, 111, 95, 231, 249, 212, 39, 123, 229, 75, 2, 18, 238, 44, 94, 181, 181, 98, 156, 150, 44, 219, 208,
            161, 18, 250, 117, 91, 146, 133, 233, 210, 161, 133, 233, 228, 111, 124, 107, 96, 134, 123, 148, 88, 238, 193,
            50, 216, 187, 42, 131, 51, 28, 52, 55, 150, 31, 49, 95, 63, 245, 58, 212, 205, 26, 223, 32, 124, 233, 20, 148,
            107, 33, 162, 47, 107, 221, 238, 221, 200, 89, 199, 52, 164, 114, 177, 254, 146, 60, 118, 1, 78, 73, 231, 138,
            136, 201, 242, 26, 100, 57, 237, 135, 181, 44, 193, 143, 191, 155, 93, 66, 142, 69, 203, 57, 22, 147, 120, 161,
            117, 167, 54, 16, 200, 6, 27, 160, 187, 15, 197, 138, 201, 114, 52, 202
          };
    
          var inlinePem = @"
    -----BEGIN PUBLIC KEY-----
    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1I++ulXUpZUopjSe7M74
    PJpj0D9JbbpV3MChYvqnu1m9+Rnd5fr1FUg7xQu+EI0XN+YIi9CbZl4tGtxjela0
    0MidM2dd1BI/5W2Zl4DHnPPmvfZoybBquK6dwkkTe5AhCCZegYD4TsNhKWGqea8D
    fSiCAvTeG0uiXbQGPD6lWei3IoVcOQ0cuz3LheCl440Bbmg2BVMUrZO81r6yH1Nz
    0ypYnBfx26Mo7379ngHc3yjxi8vjDF/is4wqOgWj34R3gbbf9EZ5OWS+DpItPpFZ
    Ykh82DrNHNCPSyvD0XvmcPhJ6O7yrloAPSiTUP9+u7w1zBpg50Srcp+afUcGODYm
    KQIDAQAB
    -----END PUBLIC KEY-----
          ";
    
          var pemr = new PemReader(new StringReader(inlinePem.Trim()));
          var pem = pemr.ReadObject();
          
          var keyParams = (RsaKeyParameters) (AsymmetricKeyParameter) pem;
          var sig = SignerUtilities.GetSigner("SHA-256withRSA");
          sig.Init(false, keyParams);
          var infoBytes = Encoding.ASCII.GetBytes("Test123");
          sig.BlockUpdate(infoBytes, 0, infoBytes.Length);
          
          Console.WriteLine($"{sig.VerifySignature(signature)}");
        }
      }
    }
