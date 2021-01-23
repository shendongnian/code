    using System;
	using System.Net;
	using System.Threading;
	using SIPSorcery.SIP;
	using SIPSorcery.SIP.App;
	using SIPSorcery.Sys;
	using SIPSorcery.Sys.Net;
	namespace SipSendNotify
	{
		class Program
		{
			private const int _defaultSIPUdpPort = SIPConstants.DEFAULT_SIP_PORT;             // The default UDP SIP port.
			private static SIPTransport _sipTransport;
			static void Main(string[] args)
			{
				try
				{
					// Configure the SIP transport layer.
					_sipTransport = new SIPTransport(SIPDNSManager.ResolveSIPService, new SIPTransactionEngine());
					// Use default options to set up a SIP channel.
					var localIP = LocalIPConfig.GetDefaultIPv4Address(); // Set this manually if needed.
					int port = FreePort.FindNextAvailableUDPPort(_defaultSIPUdpPort);
					var sipChannel = new SIPUDPChannel(new IPEndPoint(localIP, port));
					_sipTransport.AddSIPChannel(sipChannel);
					SIPCallDescriptor callDescriptor = new SIPCallDescriptor("test", null, "sip:500@67.222.131.147", "sip:you@somewhere.com", null, null, null, null, SIPCallDirection.Out, null, null, null);
					SIPNonInviteClientUserAgent notifyUac = new SIPNonInviteClientUserAgent(_sipTransport, null, callDescriptor, null, null, (monitorEvent) => { Console.WriteLine("Debug: " + monitorEvent.Message); });
					notifyUac.ResponseReceived += (resp) => { Console.WriteLine(resp.ToString()); };
					notifyUac.SendRequest(SIPMethodsEnum.NOTIFY);
					ManualResetEvent mre = new ManualResetEvent(false);
					mre.WaitOne();
				}
				catch (Exception excp)
				{
					Console.WriteLine("Exception Main. " + excp);
				}
				finally
				{
					Console.WriteLine("Press any key to exit...");
					Console.ReadLine();
				}
			}
		}
	}
