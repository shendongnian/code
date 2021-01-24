	public class SelfSignedSessionDataDelegate : NSUrlSessionDataDelegate, INSUrlSessionDelegate
	{
		const string host = "self-signed.badssl.com";
		public override void DidReceiveChallenge(NSUrlSession session, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler)
		{
			switch (challenge.ProtectionSpace.Host)
			{
				case host:
					using (var cred = NSUrlCredential.FromTrust(challenge.ProtectionSpace.ServerSecTrust))
					{
						completionHandler.Invoke(NSUrlSessionAuthChallengeDisposition.UseCredential, cred);
					}
					break;
				default:
					completionHandler.Invoke(NSUrlSessionAuthChallengeDisposition.PerformDefaultHandling, null);
					break;
			}
		}
	}
