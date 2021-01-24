	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Net.Security;
	using System.Security.Cryptography.X509Certificates;
	using System.Web.Http;
	namespace CertPinPocClient.Controllers
	{
		public class ValuesController : ApiController
		{
			// GET api/values
			public IEnumerable<string> Get()
			{
				ServicePointManager.ServerCertificateValidationCallback = new PinnedRootCaCertificate(new[]
				{
					"MIICCgKCAgEAzHYh7u+V5haaRSoGSVGm/gC4EYvZHkBR3/c/kQvTJeh1L9Bn/b7U1s7onw85SjvpZ28ohoT7p4vJRoNUBemR6hf3TM1mZmSE0tqnLGzBV9H4Nfrxx1+cubxYyYaOJ8iJfp1XslGGyZqQmUFFjWOUuU9cvOAbz4DqBIUn344JhG0xEHCf5IOF0gfuWE8yQC9vIjlveUQQ7dq/rDNZcQjqDhEb6DcF7za+1ZxjZdmtKewoYgDBPqzf66Gwi85BZsEcYFQTbjzvAhYaq4xPhJF6iPS4ihf+zjnMPxmy2oH1bm8n2fVuyxqV5JgIDU0ualx728UhfJUjcoBl57OLVsiJIdHFHpcDhN8Fn5QUGkNPgQqX27R1aw/+t2HfYTEsg6urH3aam8e7qRKUEXJs8qMKnXZ15aY0zlO7DLtfnK5tq2Cnu+HBBo4FlDhRO4kTBZOisFkvkEWI/Nj6jioOyMWsTsUvOdDK5KUpWZazpc3rwCvQy3KwBz6EyPU7ihrTm+nqqK5wiI9YwRcMjsPRBZfAur1cB0hNi+g98+2zzj+hwyR49KkOzFowp5MvXEWhnYDrY4cHSJ7zSdgMdO9HWPMke1HuKOUuUUUIpQMvPmFDAh4WQpAKqGvI/cOZeubnSwVMQra13QviYdlUeT56tFDTjgdbUNyBy0gxcFPVgTjzTj8CAwEAAQ==",
				}).Valid;
				var httpClient = new HttpClient
				{
					BaseAddress = new Uri("https://local.monitor.iontech.org")
				};
				var httpResponseMessage = httpClient.GetAsync(new Uri("https://local.monitor.iontech.org/api/status/")).Result;
				var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
				return new[] {result};
			}
		}
		public class PinnedRootCaCertificate
		{
			private readonly string[] _rootCaPublicKeys;
			public PinnedRootCaCertificate(string[] rootCaPublicKeys)
			{
				_rootCaPublicKeys = rootCaPublicKeys;
			}
			public bool Valid(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
			{
				if (sslpolicyerrors != SslPolicyErrors.None) return false;
				var rootCertificate = SelfSignedCertificate(chain);
				var publicKey = Convert.ToBase64String(rootCertificate.PublicKey.EncodedKeyValue.RawData);
				return rootCertificate.Verify() && _rootCaPublicKeys.Contains(publicKey);
			}
			private X509Certificate2 SelfSignedCertificate(X509Chain chain)
			{
				foreach (var x509ChainElement in chain.ChainElements)
				{
					if (x509ChainElement.Certificate.SubjectName.Name != x509ChainElement.Certificate.IssuerName.Name) continue;
					return x509ChainElement.Certificate;
				}
				throw new Exception("Self-signed certificate not found.");
			}
		}
	}
