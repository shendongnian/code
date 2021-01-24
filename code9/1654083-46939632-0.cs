    using System;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Crypto.Encodings;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;
    
    namespace RsaSha256OaepDecrypt
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var encryptedValue = "CthOUMzRdtSwo+4twgtjCA674G3UosWypUZv5E7uxG7GqYPiIJ+E+Uq7vbElp/bahB1fJrgq1qbdMrUZnSypVqBwYnccSxwablO15OOXl9Rn1e7w9V9fuMxtUqvhn+YZezk1623Qd7f5XTYjf6POwixtrgfZtdA+qh00ktKiVBpQKNG/bxhV94fK9+hb+qnzPmXilr9QF5rSQTd4hYHmYcR2ljVCDDZMV3tCVUTecWjS5HbOA1254ve/q3ulBLoPQTE58g7FwDQUZnd7XBdRSwYnrBWTJh8nmJ0PDfn+mCTGEI86S7HtoFYsE+Hezd24Z523phGEVrdMC9Ob1LlXEA==";
                var encryptedData = Convert.FromBase64String(encryptedValue);
                var rsaPrivate = GetPrivateKey();
                IAsymmetricBlockCipher cipher0 = new RsaBlindedEngine();
                cipher0 = new OaepEncoding(cipher0, new Sha256Digest(), new Sha256Digest(), null);
                BufferedAsymmetricBlockCipher cipher = new BufferedAsymmetricBlockCipher(cipher0);
                cipher.Init(false, rsaPrivate);
                cipher.ProcessBytes(encryptedData, 0, encryptedData.Length);
                var decryptedData = cipher.DoFinal();
                var decryptedText = Encoding.UTF8.GetString(decryptedData);
                Console.WriteLine(decryptedText);
            }
    
            private static BigInteger makeBigInt(String b64Url)
            {
                var bytes = Base64UrlDecode(b64Url);
                if ((sbyte)bytes[0] < 0)
                {
                    // prepend a zero byte to make it positive.
                    var bytes1 = new byte[bytes.Length + 1];
                    bytes1[0] = 0;
                    bytes.CopyTo(bytes1, 1);
                    bytes = bytes1;
                }
    
                return new BigInteger(bytes);
            }
            private static AsymmetricKeyParameter GetPrivateKey()
            {
                //RSAParameters RSAparams = new RSAParameters();
                var Modulus = makeBigInt("oQeTwOlTc6rIb2kddwIOc0Ywslc7YzJSRZd_PegW7T3nO3DqCI5kp5EJmnGP8JJ9sbyVYyAHFLZQtMP69UspZFn__fBk2LTp2QdqBSMHbObENcSiG2FH-pZSwCaj3Pvy-qvTjnkxxN-3OE6oB8EcX5ekZwCZzAxazbVXctY_hCcaTWG7ugwc_ZyvhsdE7wa3pnTfXYHWXcDDT8FTpYl62aqWsEIUAJSkgmQ9zce0RiDUjBJyJEM9P0ihp1Ab8BD88pEM22-PXfiOesRzp5yOsjzI3kdr5KPsshstneJEGHYae5GZXLUpnVMRY1TCFFLbkPwK6oVkRaVU1RvK9ssO3Q");
                var Exponent = makeBigInt("AQAB");
                var D = makeBigInt("E4KDwgxy7jFrqeXqKjxPTGOdbEoZ2aWj5qcZhUJcnr9Qh_jg_grkgpHVwEbQifTxsipXTiR3_ygspI4XFoeV-wDVfWqWCVR3_bHChF9PW8Ak1x_dBSS28BMs8PdthI1pDbpqPhmMcF4riHCtNo1M1v8cLdeaiqiXitNVBkaTePsDiucfwOy1rgxwBqAL1CNJhP8oRiYkxD-gfE_EapWuXY9-wF9O-lXPLSTKWgMmmVxSmhUP-Uqk7cJ24UH9C7W7hnSQU4pkfD5XHx3_2WO2GMKKZcqz39wJUrQzrIO7539SYsQ3rEe4aMJyL4U-Ib4_purzVS0DRjzGxK8chT2guQ");
                var P = makeBigInt("2TTEToB4AuPIPPpg3yTyBlGb_m-f4r-TxpU96ConV2p696_4QI6jlPWwgcC9Vdma_Da43AGuyLzIptgkzF8nSjV80VwwDKQ1YkFPc6ZqB2isvExuieSP6_jLlB-fCyCLqtTxpPm2VcK16Pqm0s5T0QGH6cQjjm1r2Ww1wuaiQbk");
                var Q = makeBigInt("vcpFwkZKZ3hx3FpHgy3ScuuTRSPO2ge8TE8UMJdCrEnpftAeYuVYrJqnxfzKgyl02OijAUi1eozJxj_lM5McxrKZEEAvo6e8wtzl2hnkUh-KWoBJ8ii0VJcu6U5vs4pcv-lYBPFC6fzoGnUw8LNWMxb5ejgYbLUWp10BbfkWGEU");
                var DP = makeBigInt("kibhWHk1R6yBlhZbjIrNl9beAkyV5vtFsj_F0ixbIITzjSqI_td71sWjKQvJ2rR7hu5DYTZ4p3XwBeQ2jpYQV-y5uh4v7rGngh-0GHuHqMiUQnejgYGcHgng4iCM4e3aTO7QUlP8jqRfxw6xpfNTjrVbAL8LtdCG21vmqOiLkXE");
                var DQ = makeBigInt("qLF9x-zKfaXlLsNgBQ1ZnaQexrnJRqrRh9JSU85fCNy5mmpKWAUbCHB-59CGAId8wMAnAyEpjcBOKNTqWSlNzp84xeUHcyPI-Dt4Yp_Y_dXjGAYntALSJs4qeF2rk55MSpiSD_KSU4DknX_E_G2rFMY7AZOSwi1D8YcNmj5okTE");
                var InverseQ = makeBigInt("Mza7JYleki7BvmD3dX5CO2nkD3mBGz4_0P_aoWyHEkWu4p5XWillaRVWyLnQEubLvAduUCr-lhfNmzdUhHecpE438_LQNtKRyOq9zkvjsMOGDmbkKpZ7-aTSshax6KNlYOWdOkadjuLtRExCmwbzu5lgI4NwacxSs5MfjHMrTCo");
                var rsa = new RsaPrivateCrtKeyParameters(Modulus, Exponent, D, P, Q, DP, DQ, InverseQ);
                return rsa;
            }
    
            // From the PDF here: https://www.rfc-editor.org/info/rfc7515
            // Also see: https://auth0.com/docs/jwks
    
            public static byte[] Base64UrlDecode(string arg)
            {
                string s = arg;
                s = s.Replace('-', '+'); // 62nd char of encoding
                s = s.Replace('_', '/'); // 63rd char of encoding
                switch (s.Length % 4) // Pad with trailing '='s
                {
                    case 0: break; // No pad chars in this case
                    case 2: s += "=="; break; // Two pad chars
                    case 3: s += "="; break; // One pad char
                    default:
                        throw new System.Exception(
                    "Illegal base64url string!");
                }
                return Convert.FromBase64String(s); // Standard base64 decoder
            }
        }
    }
