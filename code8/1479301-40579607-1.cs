	static bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors certificateErrors)
	{
		Console.WriteLine("CertificateValidation");
		Console.WriteLine(certificate.ToString(true));
		Console.WriteLine("Chain");
		Console.WriteLine(chain);
		Console.WriteLine("\tError(s)");
		Console.WriteLine(certificateErrors);
		Console.WriteLine();
		return true;
	}
