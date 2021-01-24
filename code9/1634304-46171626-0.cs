    class Alice
    {
        public static void Main(string[] args)
        {
            Bob bob = new Bob();
            using (ECDsaCng dsa = new ECDsaCng())
            {
                dsa.HashAlgorithm = CngAlgorithm.Sha256;
                bob.key = dsa.Key.Export(CngKeyBlobFormat.EccPublicBlob);
                byte[] data = new byte[] { 21, 5, 8, 12, 207 };
                byte[] signature = dsa.SignData(data);
                bob.Receive(data, signature);
            }
        }
    }
    public class Bob
    {
        public byte[] key;
        public void Receive(byte[] data, byte[] signature)
        {
            using (ECDsaCng ecsdKey = new ECDsaCng(CngKey.Import(key, CngKeyBlobFormat.EccPublicBlob)))
            {
                // set hash algorithm manually here
                ecsdKey.HashAlgorithm = CngAlgorithm.Sha256;
                if (ecsdKey.VerifyData(data, signature))
                    Console.WriteLine("Data is good");
                else
                    Console.WriteLine("Data is bad");
            }
        }
    }
