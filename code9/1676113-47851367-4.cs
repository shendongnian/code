    public partial class CLRTest
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString TestApi(SqlString url)
        {
            IgnoreBadCertificates();
            Uri uri = new Uri(url.ToString());
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                using (Stream receive = response.GetResponseStream())
                using (StreamReader stream = new StreamReader(receive, Encoding.UTF8))
                {
                    return stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static void IgnoreBadCertificates()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
        }
        private static bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
