	using System;
	using PreEmptive.SoSAttributes;
	using Cassia;
	using System.Runtime.InteropServices;
	using System.Net;
	Namespace SomeNameSpace
	{
		internal static class SomeProgram
		{
			//Check if we have a virtual IP address
			TerminalSessionInfo SessionInfo = TermServicesManager.GetSessionInfo(Dns.GetHostName(), _manager.CurrentSession.SessionId);
			string LocalIPAddress = "127.0.0.1";
			if (SessionInfo.ClientAddress != null)
			{
					LocalIPAddress = SessionInfo.ClientAddress;
			}
			MessageBox.Show(LocalIPAddress);
		}
		#region Get TerminalServer info
		public class TermServicesManager
		{
			[DllImport("wtsapi32.dll")]
			static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] String pServerName);
			[DllImport("wtsapi32.dll")]
			static extern void WTSCloseServer(IntPtr hServer);
			[DllImport("Wtsapi32.dll")]
			public static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass,out System.IntPtr ppBuffer, out uint pBytesReturned);
			[DllImport("wtsapi32.dll")]
			static extern void WTSFreeMemory(IntPtr pMemory);
			[StructLayout(LayoutKind.Sequential)]
			public struct WTS_SESSION_ADDRESS
			{
				public uint AddressFamily;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
				public byte[] Address;
			}
			public enum WTS_INFO_CLASS
			{
				InitialProgram = 0,
				ApplicationName = 1,
				WorkingDirectory = 2,
				OEMId = 3,
				SessionId = 4,
				UserName = 5,
				WinStationName = 6,
				DomainName = 7,
				ConnectState = 8,
				ClientBuildNumber = 9,
				ClientName = 10,
				ClientDirectory = 11,
				ClientProductId = 12,
				ClientHardwareId = 13,
				ClientAddress = 14,
				ClientDisplay = 15,
				ClientProtocolType = 16,
				WTSIdleTime = 17,
				WTSLogonTime = 18,
				WTSIncomingBytes = 19,
				WTSOutgoingBytes = 20,
				WTSIncomingFrames = 21,
				WTSOutgoingFrames = 22,
				WTSClientInfo = 23,
				WTSSessionInfo = 24,
				WTSSessionInfoEx = 25,
				WTSConfigInfo = 26,
				WTSValidationInfo = 27,
				WTSSessionAddressV4 = 28,
				WTSIsRemoteSession = 29
			}
			private static IntPtr OpenServer(string Name)
			{
				IntPtr server = WTSOpenServer(Name);
				return server;
			}
			private static void CloseServer(IntPtr ServerHandle)
			{
				WTSCloseServer(ServerHandle);
			}
			public static TerminalSessionInfo GetSessionInfo(string ServerName, int SessionId)
			{
				IntPtr server = IntPtr.Zero;
				server = OpenServer(ServerName);
				System.IntPtr buffer = IntPtr.Zero;
				uint bytesReturned;
				TerminalSessionInfo data = new TerminalSessionInfo();
				try
				{
					bool worked = WTSQuerySessionInformation(server, SessionId,
						WTS_INFO_CLASS.WTSSessionAddressV4, out buffer, out bytesReturned);
					if (!worked)
						return data;
					WTS_SESSION_ADDRESS si = (WTS_SESSION_ADDRESS)Marshal.PtrToStructure((System.IntPtr)buffer, typeof(WTS_SESSION_ADDRESS));
					data.ClientAddress = si.Address[2] + "." +si.Address[3] + "." + si.Address[4] + "." + si.Address[5];
				}
				finally
				{
					WTSFreeMemory(buffer);
					buffer = IntPtr.Zero;
					CloseServer(server);
				}
				return data;
			}
		}
		public class TerminalSessionInfo
		{
			public string ClientAddress;
		}
	}
	#endregion
