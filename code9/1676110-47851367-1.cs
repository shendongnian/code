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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            string result;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receive = response.GetResponseStream();
                StreamReader stream = new StreamReader(receive, Encoding.UTF8);
                result = stream.ReadToEnd();
                response.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                result = e.ToString();
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
