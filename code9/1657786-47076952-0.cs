    public class Program {
        static void Main(string[] args) {
            var containerName = "MyContainer";
            var original = "MySecretData!";
            var encrypted = Encrypt(containerName, original);
            var decrypted = Decrypt(containerName, encrypted);
            Debug.Assert(decrypted == original);
            Console.ReadLine();
        }
        static string Encrypt(string containerName, string data) {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
            CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            // random key is generated and stored in new created container with provided name
            // since it does not exist yet
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp)) {
                return Convert.ToBase64String(rsa.Encrypt(dataToEncrypt, false));
            }
        }
        static string Decrypt(string containerName, string data) {
            CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            // here container already exists so key from that container is used            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp)) {
                return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(data), false));
            }
        }
    }
