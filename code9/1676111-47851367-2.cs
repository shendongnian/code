    using System;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.IO;
    using System.Text;
    using System.Data.SqlTypes;
    public partial class CLRTest
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString TestApi(SqlString url)
        {
            IgnoreBadCertificates();
            Uri uri = new Uri(url.ToString());
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            string result;
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                using (Stream receive = response.GetResponseStream())
                using (StreamReader stream = new StreamReader(receive, Encoding.UTF8))
                {
                    result = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
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
