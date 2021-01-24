    public class CertDetails
    {
        public string Name { get; set; }
        public string HasPrivateKey { get; set; }
        public string Location { get; set; }
        public string Issuer { get; set; }
    }
 
    // stores and they friendly names
    var stores = new Dictionary<StoreName, string>()
    {
        {StoreName.My, "Personal"},
        {StoreName.Root, "Trusted roots"},
        {StoreName.TrustedPublisher, "Trusted publishers"}
        // and so on
    }.Select(s => new {store = new X509Store(s.Key), location = s.Value}).ToArray();
    foreach (var store in stores)
        store.store.Open(OpenFlags.ReadOnly); // open each store
    var list = stores.SelectMany(s => s.store.Certificates.Cast<X509Certificate2>()
        .Select(mCert => new CertDetails
        {
            HasPrivateKey = mCert.HasPrivateKey ? "Yes" : "No",
            Name = mCert.FriendlyName,
            Location = s.location,
            Issuer = mCert.Issuer
        })).ToList();
