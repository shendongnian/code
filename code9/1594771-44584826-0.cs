    private bool _canUsingCertificateForSignData(X509ExtensionCollection extensions)
    {
        if (extensions != null)
        {
            foreach (var ext in extensions)
            {
                if (ext.GetType().Equals(typeof(X509KeyUsageExtension)))
                {
                    if (((X509KeyUsageExtension)ext).KeyUsages.HasFlag(X509KeyUsageFlags.NonRepudiation))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
