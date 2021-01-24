	using System;
	using System.Runtime.InteropServices;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace WinFormsYield
	{
		static class Program
		{
			// a long-running operation on the UI thread
			private static async Task LongRunningTaskAsync(Action<string> deliverText, CancellationToken token)
			{
				for (int i = 0; i < 10000; i++)
				{
					token.ThrowIfCancellationRequested();
					await InputYield(token);
					deliverText(await ReadLineAsync(token));
				}
			}
			[STAThread]
			static void Main()
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				// create some UI
				var form = new Form { Text = "Test", Width = 800, Height = 600 };
				var panel = new FlowLayoutPanel
				{
					Dock = DockStyle.Fill,
					FlowDirection = FlowDirection.TopDown,
					WrapContents = true
				};
				form.Controls.Add(panel);
				var button = new Button { Text = "Start", AutoSize = true };
				panel.Controls.Add(button);
				var inputBox = new TextBox
				{
					Text = "You still can type here while we're loading the file",
					Width = 640
				};
				panel.Controls.Add(inputBox);
				var textBox = new TextBox
				{
					Width = 640,
					Height = 480,
					Multiline = true,
					ReadOnly = false,
					AcceptsReturn = true,
					ScrollBars = ScrollBars.Vertical
				};
				panel.Controls.Add(textBox);
				// handle Button click to "load" some text
				button.Click += async delegate
				{
					button.Enabled = false;
					textBox.Enabled = false;
					inputBox.Focus();
					try
					{
						await LongRunningTaskAsync(text =>
							textBox.AppendText(text + Environment.NewLine),
							CancellationToken.None);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					finally
					{
						button.Enabled = true;
						textBox.Enabled = true;
					}
				};
				Application.Run(form);
			}
			// simulate TextReader.ReadLineAsync
			private static async Task<string> ReadLineAsync(CancellationToken token)
			{
				return await Task.Run(() =>
				{
					Thread.Sleep(10); // simulate some CPU-bound work
					return "Line " + Environment.TickCount;
				}, token);
			}
			//
			// helpers
			//
			private static async Task TimerYield(int delay, CancellationToken token)
			{
				// yield to the message loop via a low-priority WM_TIMER message (used by System.Windows.Forms.Timer)
				// https://web.archive.org/web/20130627005845/http://support.microsoft.com/kb/96006 
				var tcs = new TaskCompletionSource<bool>();
				using (var timer = new System.Windows.Forms.Timer())
				using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false))
				{
					timer.Interval = delay;
					timer.Tick += (s, e) => tcs.TrySetResult(true);
					timer.Enabled = true;
					await tcs.Task;
					timer.Enabled = false;
				}
			}
			private static async Task InputYield(CancellationToken token)
			{
				while (AnyInputMessage())
				{
					await TimerYield((int)NativeMethods.USER_TIMER_MINIMUM, token);
				}
			}
			private static bool AnyInputMessage()
			{
				var status = NativeMethods.GetQueueStatus(NativeMethods.QS_INPUT | NativeMethods.QS_POSTMESSAGE);
				// the high-order word of the return value indicates the types of messages currently in the queue. 
				return status >> 16 != 0;
			}
			private static class NativeMethods
			{
				public const uint USER_TIMER_MINIMUM = 0x0000000A;
				public const uint QS_KEY = 0x0001;
				public const uint QS_MOUSEMOVE = 0x0002;
				public const uint QS_MOUSEBUTTON = 0x0004;
				public const uint QS_POSTMESSAGE = 0x0008;
				public const uint QS_TIMER = 0x0010;
				public const uint QS_PAINT = 0x0020;
				public const uint QS_SENDMESSAGE = 0x0040;
				public const uint QS_HOTKEY = 0x0080;
				public const uint QS_ALLPOSTMESSAGE = 0x0100;
				public const uint QS_RAWINPUT = 0x0400;
				public const uint QS_MOUSE = (QS_MOUSEMOVE | QS_MOUSEBUTTON);
				public const uint QS_INPUT = (QS_MOUSE | QS_KEY | QS_RAWINPUT);
				[DllImport("user32.dll")]
				public static extern uint GetQueueStatus(uint flags);
			}
		}
	}
