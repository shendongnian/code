	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Windows;
	using System.Windows.Input;
	namespace WpfApp1
	{
		public static class NativeMouseHook
		{
			private static readonly Dictionary<MouseMessages, List<MouseEventHandler>> MouseHandlers = new Dictionary<MouseMessages, List<MouseEventHandler>>();
			private static readonly Dictionary<MouseMessages, List<MouseButtonEventHandler>> MouseButtonHandlers = new Dictionary<MouseMessages, List<MouseButtonEventHandler>>();
			private static readonly Dictionary<MouseMessages, List<MouseWheelEventHandler>> MouseWheelHandlers = new Dictionary<MouseMessages, List<MouseWheelEventHandler>>();
			public static void RegisterMouseHandler(MouseMessages mouseMessage, MouseEventHandler handler)
			{
				AddHandler(mouseMessage, MouseHandlers, handler);
				Start();
			}
			public static void UnregisterMouseHandler(MouseMessages mouseMessage, MouseEventHandler handler)
			{
				RemoveHandler(mouseMessage, MouseHandlers, handler);
				CheckAndStop();
			}
			public static void RegisterMouseHandler(MouseMessages mouseMessage, MouseButtonEventHandler handler)
			{
				AddHandler(mouseMessage, MouseButtonHandlers, handler);
				Start();
			}
			public static void UnregisterMouseHandler(MouseMessages mouseMessage, MouseButtonEventHandler handler)
			{
				RemoveHandler(mouseMessage, MouseButtonHandlers, handler);
				CheckAndStop();
			}
			public static void RegisterMouseHandler(MouseMessages mouseMessage, MouseWheelEventHandler handler)
			{
				AddHandler(mouseMessage, MouseWheelHandlers, handler);
				Start();
			}
			public static void UnregisterMouseHandler(MouseMessages mouseMessage, MouseWheelEventHandler handler)
			{
				RemoveHandler(mouseMessage, MouseWheelHandlers, handler);
				CheckAndStop();
			}
			private static void AddHandler<T>(MouseMessages mouseMessage, Dictionary<MouseMessages, List<T>> targetHandlerDictionary, T handler)
			{
				if (!targetHandlerDictionary.ContainsKey(mouseMessage))
				{
					targetHandlerDictionary.Add(mouseMessage, new List<T>());
				}
				targetHandlerDictionary[mouseMessage].Add(handler);
			}
			private static void RemoveHandler<T>(MouseMessages mouseMessage, Dictionary<MouseMessages, List<T>> targetHandlerDictionary, T handler)
			{
				if (targetHandlerDictionary.ContainsKey(mouseMessage))
				{
					var handlerList = targetHandlerDictionary[mouseMessage];
					handlerList.Remove(handler);
					if (handlerList.Count == 0)
					{
						targetHandlerDictionary.Remove(mouseMessage);
					}
				}
			}
			private static void CheckAndStop()
			{
				if (MouseHandlers.Count == 0 && MouseButtonHandlers.Count == 0 && MouseWheelHandlers.Count == 0)
				{
					Stop();
				}
			}
			private static void Start()
			{
				if (_hookId == IntPtr.Zero)
				{
					_hookId = SetHook(Proc);
				}
			}
			private static void Stop()
			{
				if (_hookId != IntPtr.Zero)
				{
					UnhookWindowsHookEx(_hookId);
					_hookId = IntPtr.Zero;
				}
			}
			private static readonly LowLevelMouseProc Proc = HookCallback;
			private static IntPtr _hookId = IntPtr.Zero;
			private static IntPtr SetHook(LowLevelMouseProc proc)
			{
				using (var curProcess = Process.GetCurrentProcess())
				{
					using (var curModule = curProcess.MainModule)
					{
						return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
					}
				}
			}
			private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
			private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
			{
				if (nCode >= 0)
				{
					var hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
					switch ((MouseMessages)wParam)
					{
						case MouseMessages.WM_LBUTTONDOWN:
							CallHandler(MouseMessages.WM_LBUTTONDOWN, MouseButtonHandlers, new MouseButtonEventArgs(Mouse.PrimaryDevice, (int)hookStruct.time, MouseButton.Left));
							break;
						case MouseMessages.WM_LBUTTONUP:
							CallHandler(MouseMessages.WM_LBUTTONUP, MouseButtonHandlers, new MouseButtonEventArgs(Mouse.PrimaryDevice, (int)hookStruct.time, MouseButton.Left));
							break;
						case MouseMessages.WM_MOUSEMOVE:
							CallHandler(MouseMessages.WM_MOUSEMOVE, MouseHandlers, new MouseEventArgs(Mouse.PrimaryDevice, (int)hookStruct.time));
							break;
						case MouseMessages.WM_MOUSEWHEEL:
							CallHandler(MouseMessages.WM_MOUSEWHEEL, MouseWheelHandlers, new MouseWheelEventArgs(Mouse.PrimaryDevice, (int)hookStruct.time, 0));
							break;
						case MouseMessages.WM_RBUTTONDOWN:
							CallHandler(MouseMessages.WM_LBUTTONDOWN, MouseButtonHandlers, new MouseButtonEventArgs(Mouse.PrimaryDevice, (int)hookStruct.time, MouseButton.Right));
							break;
						case MouseMessages.WM_RBUTTONUP:
							CallHandler(MouseMessages.WM_LBUTTONUP, MouseButtonHandlers, new MouseButtonEventArgs(Mouse.PrimaryDevice, (int)hookStruct.time, MouseButton.Right));
							break;
					}
				}
				return CallNextHookEx(_hookId, nCode, wParam, lParam);
			}
			private static void CallHandler<T>(MouseMessages mouseMessage, Dictionary<MouseMessages, List<T>> targetHandlerDictionary, EventArgs args)
			{
				if (targetHandlerDictionary.ContainsKey(mouseMessage))
				{
					var handlerList = targetHandlerDictionary[mouseMessage];
					foreach (var handler in handlerList.Cast<Delegate>())
					{
						handler.DynamicInvoke(null, args);
					}
				}
			}
			private const int WH_MOUSE_LL = 14;
			public enum MouseMessages
			{
				WM_LBUTTONDOWN = 0x0201,
				WM_LBUTTONUP = 0x0202,
				WM_MOUSEMOVE = 0x0200,
				WM_MOUSEWHEEL = 0x020A,
				WM_RBUTTONDOWN = 0x0204,
				WM_RBUTTONUP = 0x0205
			}
			[StructLayout(LayoutKind.Sequential)]
			private struct POINT
			{
				public int x;
				public int y;
			}
			[StructLayout(LayoutKind.Sequential)]
			private struct MSLLHOOKSTRUCT
			{
				public POINT pt;
				public uint mouseData;
				public uint flags;
				public uint time;
				public IntPtr dwExtraInfo;
			}
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool GetCursorPos(ref Win32Point pt);
			[StructLayout(LayoutKind.Sequential)]
			internal struct Win32Point
			{
				public Int32 X;
				public Int32 Y;
			};
			public static Point GetMousePosition()
			{
				Win32Point w32Mouse = new Win32Point();
				GetCursorPos(ref w32Mouse);
				return new Point(w32Mouse.X, w32Mouse.Y);
			}
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool UnhookWindowsHookEx(IntPtr hhk);
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
			[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern IntPtr GetModuleHandle(string lpModuleName);
		}
	}
