    // COM doesn't have constructors, so in order to create Url objects from COM clients, you need a factory
    [ComVisible(true)]
    public interface IUriFactory
    {
        IUri Create1(string uriString);
        IUri Create2(string uriString, UriKind uriKind);
        IUri Create3(IUri baseUri, string relativeUri);
        IUri Create4(IUri baseUri, IUri relativeUri);
    }
    [ComVisible(true)]
    public interface IUri
    {
        string GetComponents(UriComponents components, UriFormat format);
        string GetLeftPart(UriPartial part);
        bool IsBaseOf(IUri uri);
        bool IsWellFormedOriginalString();
        IUri MakeRelativeUri(IUri uri);
        string ToString();
        string AbsolutePath { get; }
        string AbsoluteUri { get; }
        string Authority { get; }
        string DnsSafeHost { get; }
        string Fragment { get; }
        string Host { get; }
        UriHostNameType HostNameType { get; }
        bool IsAbsoluteUri { get; }
        bool IsDefaultPort { get; }
        bool IsFile { get; }
        bool IsLoopback { get; }
        bool IsUnc { get; }
        string LocalPath { get; }
        string OriginalString { get; }
        string PathAndQuery { get; }
        int Port { get; }
        string Query { get; }
        string Scheme { get; }
        string[] Segments { get; }
        bool UserEscaped { get; }
        string UserInfo { get; }
    }
    [ComVisible(true)]
    public enum UriKind
    {
        RelativeOrAbsolute = System.UriKind.RelativeOrAbsolute,
        Absolute = System.UriKind.Absolute,
        Relative = System.UriKind.Relative,
    }
    [ComVisible(true)]
    public enum UriComponents
    {
        Scheme = System.UriComponents.Scheme,
        UserInfo = System.UriComponents.UserInfo,
        Host = System.UriComponents.Host,
        Port = System.UriComponents.Port,
        Path = System.UriComponents.Path,
        Query = System.UriComponents.Query,
        Fragment = System.UriComponents.Fragment,
        StrongPort = System.UriComponents.StrongPort,
        NormalizedHost = System.UriComponents.NormalizedHost,
        KeepDelimiter = System.UriComponents.KeepDelimiter,
        SerializationInfoString = System.UriComponents.SerializationInfoString,
        AbsoluteUri = Fragment | Query | Path | Port | Host | UserInfo | Scheme,
        HostAndPort = StrongPort | Host,
        StrongAuthority = HostAndPort | UserInfo,
        SchemeAndServer = Port | Host | Scheme,
        HttpRequestUrl = SchemeAndServer | Query | Path,
        PathAndQuery = Query | Path,
    }
    [ComVisible(true)]
    public enum UriFormat
    {
        UriEscaped = System.UriFormat.UriEscaped,
        Unescaped = System.UriFormat.Unescaped,
        SafeUnescaped = System.UriFormat.SafeUnescaped,
    }
    [ComVisible(true)]
    public enum UriPartial
    {
        Scheme = System.UriPartial.Scheme,
        Authority = System.UriPartial.Authority,
        Path = System.UriPartial.Path,
        Query = System.UriPartial.Query,
    }
    [ComVisible(true)]
    public enum UriHostNameType
    {
        Unknown = System.UriHostNameType.Unknown,
        Basic = System.UriHostNameType.Basic,
        Dns = System.UriHostNameType.Dns,
        IPv4 = System.UriHostNameType.IPv4,
        IPv6 = System.UriHostNameType.IPv6,
    }
    [ComVisible(true)]
    public class UriFactory : IUriFactory
    {
        public IUri Create1(string uriString){ return new Uri(new System.Uri(uriString)); }
        public IUri Create2(string uriString, UriKind uriKind) { return new Uri(new System.Uri(uriString, (System.UriKind) (int) uriKind)); }
        public IUri Create3(IUri baseUri, string relativeUri) { return new Uri(new System.Uri(((Uri) baseUri).Inner, relativeUri)); }
        public IUri Create4(IUri baseUri, IUri relativeUri) { return new Uri(new System.Uri(((Uri) baseUri).Inner, ((Uri) relativeUri).Inner)); }
    }
    [ComVisible(true)]
    internal class Uri : IUri
    {
        internal readonly System.Uri Inner;
        internal Uri(System.Uri inner) { Inner = inner; }
        public string GetComponents(UriComponents components, UriFormat format) => Inner.GetComponents((System.UriComponents) components, (System.UriFormat) format);
        public string GetLeftPart(UriPartial part) => Inner.GetLeftPart((System.UriPartial) part);
        public bool IsBaseOf(IUri uri) => Inner.IsBaseOf(((Uri) uri).Inner);
        public bool IsWellFormedOriginalString() => Inner.IsWellFormedOriginalString();
        public IUri MakeRelativeUri(IUri uri) => new Uri(Inner.MakeRelativeUri(((Uri) uri).Inner));
        public string AbsolutePath => Inner.AbsolutePath;
        public string AbsoluteUri => Inner.AbsoluteUri;
        public string Authority => Inner.Authority;
        public string DnsSafeHost => Inner.DnsSafeHost;
        public string Fragment => Inner.Fragment;
        public string Host => Inner.Host;
        public UriHostNameType HostNameType => (UriHostNameType) (int) Inner.HostNameType;
        public bool IsAbsoluteUri => Inner.IsAbsoluteUri;
        public bool IsDefaultPort => Inner.IsDefaultPort;
        public bool IsFile => Inner.IsFile;
        public bool IsLoopback => Inner.IsLoopback;
        public bool IsUnc => Inner.IsUnc;
        public string LocalPath => Inner.LocalPath;
        public string OriginalString => Inner.OriginalString;
        public string PathAndQuery => Inner.PathAndQuery;
        public int Port => Inner.Port;
        public string Query => Inner.Query;
        public string Scheme => Inner.Scheme;
        public string[] Segments => Inner.Segments;
        public bool UserEscaped => Inner.UserEscaped;
        public string UserInfo => Inner.UserInfo;
    }
