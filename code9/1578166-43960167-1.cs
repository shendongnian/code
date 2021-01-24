	private void Client_ValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
	{
		if (e.PolicyErrors == SslPolicyErrors.None || e.Certificate.GetRawCertDataString() == TrustedRawCertData)
		{
			e.Accept = true;
		}
		else
		{
			throw new Exception($"{e.PolicyErrors}{Environment.NewLine}{GetCertificateDetails(e.Certificate)}");
		}
	}
