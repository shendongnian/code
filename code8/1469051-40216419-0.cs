	using System;
	using System.Diagnostics;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Security.AccessControl;
	using System.Security.Principal;
	using System.Threading;
	
	namespace Helpers
	{
		public static class SingleInstance
		{
			[DllImport("User32.dll")]
			private static extern bool SetForegroundWindow(IntPtr handle);
	
			[DllImport("User32.dll")]
			private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
	
			[DllImport("User32.dll")]
			private static extern bool IsIconic(IntPtr handle);
	
			private const int SW_RESTORE = 9;
	
			private static string _appGuid;
	
			private static Mutex _mutex;
	
			static SingleInstance()
			{
				_appGuid = GetAssemblyGuid(Assembly.GetExecutingAssembly());
			}
	
			public static bool IsAlreadyRunning(bool useGlobal)
			{
				//This code was taken from http://stackoverflow.com/a/229567/4631427
	
				string mutexId;
				if (useGlobal)
				{
					mutexId = String.Format("Global\\{{{0}}}", _appGuid);
				}
				else
				{
					mutexId = String.Format("{{{0}}}", _appGuid);
				}
	
				MutexAccessRule allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
				MutexSecurity securitySettings = new MutexSecurity();
				securitySettings.AddAccessRule(allowEveryoneRule);
	
				bool createdNew;
				_mutex = new Mutex(false, mutexId, out createdNew, securitySettings);
	
				bool hasHandle = false;
				try
				{
					hasHandle = _mutex.WaitOne(0, false);
					if (!hasHandle)
					{
						return true;
					}
				}
				catch (AbandonedMutexException)
				{
					hasHandle = true;
				}
	
				return false;
			}
	
			public static void ShowRunningApp()
			{
				Process current = Process.GetCurrentProcess();
				foreach (Process process in Process.GetProcesses())
				{
					if (process.Id == current.Id)
					{
						continue;
					}
	
					try
					{
						Assembly assembly = Assembly.LoadFrom(process.MainModule.FileName);
	
						string processGuid = GetAssemblyGuid(assembly);
						if (_appGuid.Equals(processGuid))
						{
							BringProcessToFront(process);
							return;
						}
					} catch { }
				}
			}
	
			private static string GetAssemblyGuid(Assembly assembly)
			{
				object[] customAttribs = assembly.GetCustomAttributes(typeof(GuidAttribute), false);
				if (customAttribs.Length < 1)
				{
					return null;
				}
	
				return ((GuidAttribute)(customAttribs.GetValue(0))).Value.ToString();
			}
	
			private static void BringProcessToFront(Process process)
			{
				IntPtr handle = process.MainWindowHandle;
				if (IsIconic(handle))
				{
					ShowWindow(handle, SW_RESTORE);
				}
	
				SetForegroundWindow(handle);
			}
		}
	}
