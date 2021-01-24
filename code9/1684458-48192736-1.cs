             MyPage.SignupEmail(email, acctType);
 	  		<add key="LocalFilePath" value="C:\\MyPath" />
			using System;
			using System.Configuration;
			using System.IO;
			using TestFramework;
			namespace Tests
			{
				internal class SignupAccounts
				{
					public static void SignupEmail(string email, string acctType)
					{
						if (!Directory.Exists(ConfigurationManager.AppSettings["LocalFilePath"]))
						{
							Directory.CreateDirectory(ConfigurationManager.AppSettings["LocalFilePath"]);
						}
						using (
							StreamWriter writer =
								File.AppendText(String.Format(ConfigurationManager.AppSettings["LocalFilePath"] + "\\file_{0}.txt",
									Browser.GetCurrentTimestamp())))
						{
							writer.WriteLine(String.Format("{0}, {1}", "Applicant Email", @email));
							writer.WriteLine(String.Format("{0}, {1}", "Applicant Acct Type", @acctType));
							writer.WriteLine("Password: MyPass123");
						}
					}
				}
			}
