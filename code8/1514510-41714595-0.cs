    using System;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;
    
    namespace TestGame
    {
        public class AesEnDecryption
        {
    
            private string AES_Key = "MYLiSQ864FhDevJOeMs9EVp5RmfC7OuH";
            private string AES_IV = "FoL5Tyd9sZclVn5A";
            private IBuffer m_iv = null;
            private CryptographicKey m_key;
    
            public AesEnDecryption()
            {
    
                IBuffer key = Convert.FromBase64String(AES_Key).AsBuffer();
                m_iv = Convert.FromBase64String(AES_IV).AsBuffer();
                SymmetricKeyAlgorithmProvider provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);
                m_key = provider.CreateSymmetricKey(key);
            }
    
            public byte[] Encrypt(byte[] input)
            {
    
                IBuffer bufferMsg = CryptographicBuffer.ConvertStringToBinary(Encoding.ASCII.GetString(input), BinaryStringEncoding.Utf8);
                IBuffer bufferEncrypt = CryptographicEngine.Encrypt(m_key, bufferMsg, m_iv);
                return bufferEncrypt.ToArray();
            }
    
            public byte[] Decrypt(byte[] input)
            {
                IBuffer bufferDecrypt = CryptographicEngine.Decrypt(m_key, input.AsBuffer(), m_iv);
                return bufferDecrypt.ToArray();
            }
        }
    }
