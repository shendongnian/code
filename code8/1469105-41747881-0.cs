    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    
    namespace HQ.Util.General
    {
    	public class ProcessExecutionWithOutputCapture
    	{
    		// ************************************************************************
    		public class ProcessWithOutputCaptureResult
    		{
    			public string Error { get; internal set; }
    
    			public string Output { get; internal set; }
    
    			public string ExecutionError
    			{
    				get
    				{
    					if (String.IsNullOrEmpty(Error))
    					{
    						return Error;
    					}
    					
    					return Exception?.ToString();
    				}
    			}
    
    			public bool HasTimeout { get; internal set; }
    
    			/// <summary>
    			/// Can be cancel through the eventCancel which will cancel the wait (and if set, will kill the process)
    			/// </summary>
    			public bool HasBeenCanceled { get; internal set; }
    
    			public int ExitCode { get; internal set; }
    
    			public Exception Exception { get; internal set; }
    
    			public bool HasSucceded => !HasTimeout && Exception == null;
    		}
    
    		// ************************************************************************
    		private StringBuilder _sbOutput = new StringBuilder();
    		private StringBuilder _sbError = new StringBuilder();
    
    		private AutoResetEvent _outputWaitHandle = null;
    		private AutoResetEvent _errorWaitHandle = null;
    		
    		// Could be usefull when user want to exit to not wait for process to end and kill it (if wanted)
    		public EventWaitHandle AdditionalConditionToStopWaitingProcess { get; set; }
    		public bool IsAdditionalConditionToStopWaitingProcessShouldAlsoKill { get; set; }
    
    		public ProcessWindowStyle ProcessWindowStyle { get; set; } = ProcessWindowStyle.Hidden;
    		public bool CreateWindow { get; set; } = false;
    
    		public static ProcessWithOutputCaptureResult ExecuteWith(string executablePath, string arguments, int timeout = Timeout.Infinite, ProcessWindowStyle processWindowStyle = ProcessWindowStyle.Hidden, bool createWindow = false)
    		{
    			var p = new ProcessExecutionWithOutputCapture();
    			return p.Execute(executablePath, arguments, timeout);
    		}
    
    		// ************************************************************************
    		/// <summary>
    		/// Only support existing exectuable (no association or dos command which have no executable like 'dir').
    		/// But accept full path, partial path or no path where it will use regular system/user path.
    		/// </summary>
    		/// <param name="executablePath"></param>
    		/// <param name="arguments"></param>
    		/// <param name="timeout"></param>
    		/// <returns></returns>
    		private ProcessWithOutputCaptureResult Execute(string executablePath, string arguments = null, int timeout = Timeout.Infinite)
    		{
    			ProcessWithOutputCaptureResult processWithOutputCaptureResult = null;
    
    			using (Process process = new Process())
    			{
    				process.StartInfo.FileName = executablePath;
    				process.StartInfo.Arguments = arguments;
    				process.StartInfo.UseShellExecute = false; // required to redirect output to appropriate (output or error) process stream
    
    				process.StartInfo.WindowStyle = ProcessWindowStyle;
    				process.StartInfo.CreateNoWindow = CreateWindow;
    
    				process.StartInfo.RedirectStandardOutput = true;
    				process.StartInfo.RedirectStandardError = true;
    
    				_outputWaitHandle = new AutoResetEvent(false);
    				_errorWaitHandle = new AutoResetEvent(false);
    
    				bool asyncReadStarted = false;
    
    				try
    				{
    					process.OutputDataReceived += ProcessOnOutputDataReceived;
    					process.ErrorDataReceived += ProcessOnErrorDataReceived;
    
    					process.Start();
    
    					// Here there is a race condition. See: https://connect.microsoft.com/VisualStudio/feedback/details/3119134/race-condition-in-process-asynchronous-output-stream-read
    					
    					process.BeginOutputReadLine();
    					process.BeginErrorReadLine();
    
    					asyncReadStarted = true;
    
    					// See: ProcessStartInfo.RedirectStandardOutput Property:
    					//		https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k(System.Diagnostics.ProcessStartInfo.RedirectStandardOutput);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-csharp)&rd=true
    					// All 4 next lines should only be called when not using asynchronous read (process.BeginOutputReadLine() and process.BeginErrorReadLine())
    					//_sbOutput.AppendLine(process.StandardOutput.ReadToEnd());
    					//_sbError.AppendLine(process.StandardError.ReadToEnd());
    					//_sbOutput.AppendLine(process.StandardOutput.ReadToEnd());
    					//_sbError.AppendLine(process.StandardError.ReadToEnd());
    
    					var waitHandles = new WaitHandle[1 + (AdditionalConditionToStopWaitingProcess == null ? 0 : 1)];
    
    					waitHandles[0] = new ProcessWaitHandle(process);
    					if (AdditionalConditionToStopWaitingProcess != null)
    					{
    						waitHandles[1] = AdditionalConditionToStopWaitingProcess;
    					}
    
    					bool hasSucceded = false;
    					int waitResult = WaitHandle.WaitAny(waitHandles, timeout);
    					if (waitResult == 1) // The wait has been interrrupted by an external event
    					{
    						if (IsAdditionalConditionToStopWaitingProcessShouldAlsoKill)
    						{
    							process.Kill();
    						}
    					}
    					else if (waitResult == 0) // Process has completed normally, no timeout or external event
    					{
    						// Ensure internal process code has completed like ensure to wait until stdout et stderr had been fully completed
    						hasSucceded = process.WaitForExit(timeout);
    						
    						if (_outputWaitHandle.WaitOne(timeout) && _errorWaitHandle.WaitOne(timeout))
    						{
    							processWithOutputCaptureResult = new ProcessWithOutputCaptureResult();
    							processWithOutputCaptureResult.ExitCode = process.ExitCode;
    							processWithOutputCaptureResult.Output = _sbOutput.ToString();
    							processWithOutputCaptureResult.Error = _sbError.ToString();
    						}
    					}
    					else // Process timeout
    					{
    						processWithOutputCaptureResult = new ProcessWithOutputCaptureResult();
    						processWithOutputCaptureResult.HasTimeout = true;
    					}
    				}
    				catch (Exception ex)
    				{
    					if (ex.HResult == -2147467259)
    					{
    						processWithOutputCaptureResult = new ProcessWithOutputCaptureResult();
    						processWithOutputCaptureResult.Exception = new FileNotFoundException("File not found: " + executablePath, ex);
    					}
    					else
    					{
    						processWithOutputCaptureResult = new ProcessWithOutputCaptureResult();
    						processWithOutputCaptureResult.Exception = ex;
    					}
    				}
    				finally
    				{
    					if (asyncReadStarted)
    					{
    						process.CancelOutputRead();
    						process.CancelErrorRead();
    					}
    
    					process.OutputDataReceived -= ProcessOnOutputDataReceived;
    					process.ErrorDataReceived -= ProcessOnOutputDataReceived;
    
    					_outputWaitHandle.Close();
    					_outputWaitHandle.Dispose();
    
    					_errorWaitHandle.Close();
    					_errorWaitHandle.Dispose();
    				}
    			}
    
    			return processWithOutputCaptureResult;
    		}
    
    		// ************************************************************************
    		private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e)
    		{
    			if (e.Data == null)
    			{
    				_outputWaitHandle.Set();
    			}
    			else
    			{
    				_sbOutput.AppendLine(e.Data);
    			}
    		}
    
    		// ************************************************************************
    		private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e)
    		{
    			if (e.Data == null)
    			{
    				_errorWaitHandle.Set();
    			}
    			else
    			{
    				_sbError.AppendLine(e.Data);
    			}
    		}
    
    		// ************************************************************************
    	}
    }
