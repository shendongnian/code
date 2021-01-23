    public interface IDirectoryEntryManager
    {
        DirectoryEntry GetDirectoryEntry(string domain, string baseDn);
    }
    public interface ICredentialProvider
    {
        Credential GetCredential(string domain);
    }
    public class Credential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class DirectoryEntryManager : IDirectoryEntryManager, IDisposable
    {
        private class DomainConnectionInfo
        {
            internal DomainConnectionInfo(string server, Credential credential)
	        {
                Server = server;
                Credential = credential;
	        }
            internal string Server { get; private set; }
            internal Credential Credential { get; private set; }
        }
        private bool disposed;
        ICredentialProvider _credentialProvider;
        Dictionary<string, DomainConnectionInfo> connectionsInfo = new Dictionary<string, DomainConnectionInfo>(StringComparer.OrdinalIgnoreCase);
        Dictionary<string, DirectoryEntry> connections = new Dictionary<string, DirectoryEntry>(StringComparer.OrdinalIgnoreCase);
        public DirectoryEntryManager(ICredentialProvider credentialProvider)
        {
            _credentialProvider = credentialProvider;
        }
        public DirectoryEntry GetDirectoryEntry(string domain, string baseDn)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
            return GetOrCreateConnection(domain, baseDn);
        }
        public void Dispose()
        {
            if (!disposed)
            {
                foreach (var connection in connections)
                {
                    connection.Value.Dispose();
                }
                connections.Clear();
                disposed = true;
            }
        }
        private DirectoryEntry GetOrCreateConnection(string domain, string baseDn)
        {
            DomainConnectionInfo info;
            if (!connectionsInfo.TryGetValue(domain, out info))
            {
                var credential = _credentialProvider.GetCredential(domain);
                var dc = DomainController.FindOne(new DirectoryContext(DirectoryContextType.Domain, credential.UserName, credential.Password));
                info = new DomainConnectionInfo(dc.Name, credential);
                // maintaining a connection to rootDse object to make all LDAP queries use this single connection under the hood. Increasing performance
                var entry = new DirectoryEntry(string.Format("LDAP://{0}/RootDSE", dc.Name));
                entry.RefreshCache();
                connections.Add(domain, entry);
                connectionsInfo.Add(domain, info);
            }
            return new DirectoryEntry(string.Format("LDAP://{0}/{1}", info.Server, baseDn), info.Credential.UserName, info.Credential.Password);
        }
    }
