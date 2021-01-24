    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Threading;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Web.Configuration;
    /// <summary>
    /// Summary description for LogMessage
    /// </summary>
    public class LogMessage
    {
        static ReaderWriterLock locker = new ReaderWriterLock();
    
        private static string serviceDirectory = HttpContext.Current != null ?
            AppDomain.CurrentDomain.BaseDirectory :
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static string fullpath = serviceDirectory + "\\ActivityLog.log";
        private static readonly LogMessage instance = new LogMessage();
    
        public static LogMessage Instance
        {
            get { return instance; }
        }
    
        public void SaveLogMessage(string userName, string message, string stackTrace, bool inOut)
        {
            bool EnableActivityLogging = false;
    
            if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["EnableActivityLogging"]))
                return;
    
            EnableActivityLogging = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableActivityLogging"]);
    
            if (!EnableActivityLogging)
                return;
    
            BackgroundWorker logbw = new BackgroundWorker();
            logbw.DoWork += logbw_DoWork;
            logbw.RunWorkerCompleted += logbw_RunWorkerCompleted;
    
            List<string> paramList = new List<string>();
            paramList.Add(userName);
            paramList.Add(message);
            paramList.Add(stackTrace);
            paramList.Add(inOut.ToString());
    
            if (!logbw.IsBusy)
            {
                logbw.RunWorkerAsync(paramList);
            }
        }
    
        void logbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.Write("Log Message Background Worker is now free...");
        }
    
        void logbw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> paramList = (List<string>)e.Argument;
            string userName = paramList[0].ToString();
            string message = paramList[1].ToString();
            string stackTrace = paramList[2].ToString();
            bool inOut = bool.Parse(paramList[3].ToString());
    
            try
            {
                locker.AcquireWriterLock(int.MaxValue);
                using (StreamWriter logWriter =
                    new StreamWriter(fullpath, true))
                {
                    string logMessage = "";
                    if (!string.IsNullOrEmpty(stackTrace))
                    {
                        if (inOut)//IN
                        {
                            logMessage = string.Format("{0} U:{1} IN:{2} E:{3}", DateTime.Now.ToString(), userName, message, stackTrace);
                        }
                        else//OUT
                        {
                            logMessage = string.Format("{0} U:{1} OUT:{2} E:{3}", DateTime.Now.ToString(), userName, message, stackTrace);
                        }
                    }
                    else
                    {
                        if (inOut)//IN
                        {
                            logMessage = string.Format("{0} U:{1} IN:{2}", DateTime.Now.ToString(), userName, message);
                        }
                        else//OUT
                        {
                            logMessage = string.Format("{0} U:{1} OUT:{2}", DateTime.Now.ToString(), userName, message);
                        }
                    }
    
                    logWriter.WriteLine(logMessage);
    
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
    
    }
