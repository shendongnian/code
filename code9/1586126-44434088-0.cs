        var cngLightupType = typeof(EncryptedXml).Assembly.GetType("System.Security.Cryptography.CngLightup");
        var preferRsaCngField = cngLightupType.GetField("s_preferRsaCng", BindingFlags.Static | BindingFlags.NonPublic);
        var getRsaPublicKeyField = cngLightupType.GetField("s_getRsaPublicKey", BindingFlags.Static | BindingFlags.NonPublic);
        var getRsaPrivateKeyField = cngLightupType.GetField("s_getRsaPrivateKey", BindingFlags.Static | BindingFlags.NonPublic);
        preferRsaCngField.SetValue(null, new Lazy<bool>(() => false));
        getRsaPublicKeyField.SetValue(null, null);
        getRsaPrivateKeyField.SetValue(null, null);
