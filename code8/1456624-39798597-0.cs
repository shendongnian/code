    using Net.Pkcs11Interop.Common;
    using Net.Pkcs11Interop.HighLevelAPI;
    using System;
    using System.Collections.Generic;
    
    namespace ExportTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (Pkcs11 pkcs11 = new Pkcs11(@"D:\SoftHSM2\lib\softhsm2.dll", false))
                {
                    Slot slot = pkcs11.GetSlotList(true)[0];
    
                    using (Session session = slot.OpenSession(false))
                    {
                        session.Login(CKU.CKU_USER, "11111111");
    
                        // Generate exportable key
                        List<ObjectAttribute> objectAttributes = new List<ObjectAttribute>();
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_LABEL, "Generated key"));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_SECRET_KEY));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_KEY_TYPE, CKK.CKK_DES3));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_TOKEN, true));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_ENCRYPT, true));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_DECRYPT, true));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_EXTRACTABLE, true));
    
                        ObjectHandle generatedKey = null;
                        using (Mechanism mechanism = new Mechanism(CKM.CKM_DES3_KEY_GEN))
                            generatedKey = session.GenerateKey(mechanism, objectAttributes);
    
                        // Export the key
                        byte[] plainKeyValue = null;
                        List<ObjectAttribute> readAttrs = session.GetAttributeValue(generatedKey, new List<CKA>() { CKA.CKA_VALUE });
                        if (readAttrs[0].CannotBeRead)
                            throw new Exception("Key cannot be exported");
                        else
                            plainKeyValue = readAttrs[0].GetValueAsByteArray();
    
                        // Import the key
                        objectAttributes = new List<ObjectAttribute>();
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_LABEL, "Imported key"));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_SECRET_KEY));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_KEY_TYPE, CKK.CKK_DES3));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_TOKEN, true));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_ENCRYPT, true));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_DECRYPT, true));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_VALUE, plainKeyValue));
    
                        ObjectHandle importedKey = session.CreateObject(objectAttributes);
    
                        // Test encryption with generated key and decryption with imported key
                        using (Mechanism mechanism = new Mechanism(CKM.CKM_DES3_CBC, session.GenerateRandom(8)))
                        {
                            byte[] sourceData = ConvertUtils.Utf8StringToBytes("Our new password");
                            byte[] encryptedData = session.Encrypt(mechanism, generatedKey, sourceData);
                            byte[] decryptedData = session.Decrypt(mechanism, importedKey, encryptedData);
                            if (Convert.ToBase64String(sourceData) != Convert.ToBase64String(decryptedData))
                                throw new Exception("Encryption test failed");
                        }
    
                        session.Logout();
                    }
                }
            }
        }
    }
