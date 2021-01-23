    namespace MyTests
    {
        using System;
        using System.Security.Cryptography.X509Certificates;
        public class MyTests
        {
            // Copy and paste the string from TestCert.txt here.
            private const string CertText = "<text>";
            // Use the password you created in steps 1 and 2 here.
            private const string Password = "p4ssw0rd";
            // Create the certificate object.
            private readonly X509Certificate2 TestCert = new X509Certificate2(
                Convert.FromBase64String(MyTests.CertText),
                MyTests.Password);
        }
    }
