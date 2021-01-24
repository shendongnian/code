	public static class WebSocketXs
	{
		readonly static Assembly  assembly                    = typeof(WebSocket).Assembly;
		readonly static FieldInfo m_InnerStream               = assembly.GetType("System.Net.WebSockets.WebSocketBase").GetField(nameof(m_InnerStream), BindingFlags.NonPublic | BindingFlags.Instance);
		readonly static FieldInfo m_ReadTaskCompletionSource  = assembly.GetType("System.Net.WebSockets.WebSocketHttpListenerDuplexStream").GetField(nameof(m_ReadTaskCompletionSource),  BindingFlags.NonPublic | BindingFlags.Instance);
		readonly static FieldInfo m_WriteTaskCompletionSource = assembly.GetType("System.Net.WebSockets.WebSocketHttpListenerDuplexStream").GetField(nameof(m_WriteTaskCompletionSource), BindingFlags.NonPublic | BindingFlags.Instance);
		readonly static FieldInfo[] completionSourceFields    = {m_ReadTaskCompletionSource, m_WriteTaskCompletionSource };
		/// <summary>
		/// This fixes a race that happens when a <see cref="WebSocket"/> fails and aborts after failure.
		/// The <see cref="completionSourceFields"/> have an Exception that is not observed as the <see cref="WebSocket.Abort()"/>
		/// done to WebSocketBase <see cref="m_InnerStream"/> is just <see cref="TaskCompletionSource{TResult}.TrySetCanceled()"/> which
		/// does nothing with the completion source <see cref="Task.Exception"/>.
		/// That in turn raises a <see cref="TaskScheduler.UnobservedTaskException"/>.
		/// </summary>
		public static void
		CleanUpAndDispose(this WebSocket ws)
		{
			foreach(var completionSourceField in completionSourceFields) {
				m_InnerStream
					.GetValue(ws)
					.Maybe(completionSourceField.GetValue)
					.Maybe(s => s as TaskCompletionSource<object>)?
					.Task
					.Exception
					.Maybe(_ => {}) // We just need to observe any exception.
				;
			}
			ws.Dispose();
		}
	}
