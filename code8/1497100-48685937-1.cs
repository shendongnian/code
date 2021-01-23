    			public static void CheckSignature()
				{
					STAApartment apt = new STAApartment();
					var result = apt.Invoke(() =>
					{
						return VerifySignature(@".\signedjsfile.js", false);
					});
					Console.WriteLine(result);
				}
				private static WinVerifyTrustResult VerifySignature(string filePath, bool verifySignatureOnly)
				{
					using (var wtd = new WinTrustData(new WinTrustFileInfo(filePath))
					{
						dwUIChoice = WintrustUIChoice.WTD_UI_NONE,
						dwUIContext = WinTrustDataUIContext.WTD_DATA_UI_EXECUTE,
						fdwRevocationChecks = WinTrustDataRevocationChecks.WTD_REVOCATION_CHECK_WHOLECHAIN,
						dwStateAction = WintrustAction.WTD_STATEACTION_IGNORE,
						dwProvFlags = verifySignatureOnly ? WintrustProviderFlags.WTD_HASH_ONLY_FLAG : WintrustProviderFlags.WTD_REVOCATION_CHECK_CHAIN
					})
					{
						var result = WinTrust.WinVerifyTrust(
							WinTrust.INVALID_HANDLE_VALUE, new Guid(WinTrust.WINTRUST_ACTION_GENERIC_VERIFY_V2), wtd
						);
						return result;
					}
				}
				public class STAApartment
				{
					public T Invoke<T>(Func<T> func)
					{
						var tcs = new TaskCompletionSource<T>();
						Thread thread = new Thread(() =>
						{
							try
							{
								tcs.SetResult(func());
							}
							catch (Exception e)
							{
								tcs.SetException(e);
							}
						});
						thread.SetApartmentState(ApartmentState.STA);
						thread.Start();                
						return tcs.Task.Result;
					}
				}
