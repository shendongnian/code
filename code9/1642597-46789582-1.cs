        public class Pkcs11SignerProvider : ISignerProvider
    {
        private string _thumbprint;
        public string DllPath { get; set; }
        public string TokenSerial { get; set; }
        public string TokenPin { get; set; }
        public string PrivateKeyLabel { get; set; }
        
        public Pkcs11SignerProvider(string dllPath, string tokenSerial, string tokenPin, string privateKeyLabel)
        {
            DllPath = dllPath;
            TokenSerial = tokenSerial;
            TokenPin = tokenPin;
            PrivateKeyLabel = privateKeyLabel;
        }
        public byte[] Sign(byte[] data)
        {
            using (var pkcs11 = new Pkcs11(DllPath, AppType.SingleThreaded))
            {
                var slots = pkcs11.GetSlotList(SlotsType.WithTokenPresent);
                var slot = slots.FirstOrDefault(slot1 => slot1.GetTokenInfo().SerialNumber == TokenSerial);
                if (slot == null)
                    throw new Exception("there is no token with serial " + TokenSerial);
                using (var session = slot.OpenSession(SessionType.ReadOnly))
                {
                    session.Login(CKU.CKU_USER, TokenPin);
                    var searchTemplate = new List<ObjectAttribute>
                    {
                        new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_PRIVATE_KEY),
                        new ObjectAttribute(CKA.CKA_KEY_TYPE, CKK.CKK_RSA)
                    };
                    if (!string.IsNullOrEmpty(PrivateKeyLabel))
                        searchTemplate.Add(new ObjectAttribute(CKA.CKA_LABEL, PrivateKeyLabel));
                    var foundObjects = session.FindAllObjects(searchTemplate);
                    var privateKey = foundObjects.FirstOrDefault();
                    using (var mechanism = new Mechanism(CKM.CKM_RSA_PKCS))
                    {
                        return session.Sign(mechanism, privateKey, data);
                    }
                }
            }
        }
    }
