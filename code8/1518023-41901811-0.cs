    public class MyCustomAppender : RollingFileAppender
    {
        bool firstRun  = true;
        string fileNamePattern = null;
        protected override void Append(LoggingEvent loggingEvent)
        {
            CloseFile();
            File = fileNamePattern.Replace("__filename__", ThreadContext.Properties["PropertyName"].ToString());
            LockingModel.OpenFile(File, true, Encoding.UTF8);
            LockingModel.AcquireLock();
            OpenFile(File, true);
            
            base.Append(loggingEvent);
            DoAppend(loggingEvent);
        }
        public override string File
        {
            get
            {
                if (firstRun)
                {
                    firstRun = false;
                    fileNamePattern = base.File;
                }
                return base.File;
            }
            set
            {
                base.File = value;               
            }
        }
    }
