    public sealed class Watcher
        {
            int eventCount = 0;
    
            #region Private Members
            /// <summary>
            /// File system watcher variable.
            /// </summary>
            private FileSystemWatcher fsw = null;
            /// <summary>
            /// Destination path to use.
            /// </summary>
            private string destination = @"c:\temp\doc2\";
            /// <summary>
            /// Source path to monitor.
            /// </summary>
            private string source = @"c:\temp\doc\";
            /// <summary>
            /// Default filter type is all files.
            /// </summary>
            private string filter = "*.bmp";
            /// <summary>
            /// Monitor all sub directories in the source folder.
            /// </summary>
            private bool includeSubdirectories = true;
            /// <summary>
            /// Background worker which will Move files.
            /// </summary>
            private BackgroundWorker bgWorker = null;
            /// <summary>
            /// Toggle flag to enable copying files and vice versa.
            /// </summary>
            private bool enableCopyingFiles = false;
            /// <summary>
            /// File System watcher lock.
            /// </summary>
            private object fswLock = new object();
    
            private static Watcher watcherInstance;
            #endregion
    
            #region Public Properties
            public static Watcher WatcherInstance
            {
                get
                {
                    if (watcherInstance == null)
                    {
                        watcherInstance = new Watcher();
                    }
                    return watcherInstance;
                }
            }
    
    
    
            public string Source
            {
                get
                {
                    return source;
                }
                set
                {
                    source = value;
                }
            }
    
            public string Destination
            {
                get
                {
                    return destination;
                }
                set
                {
                    destination = value;
                }
            }
    
            public string Filter
            {
                get
                {
                    return filter;
                }
                set
                {
                    filter = value;
                }
            }
    
            public bool MonitorSubDirectories
            {
                get
                {
                    return includeSubdirectories;
                }
                set
                {
                    includeSubdirectories = value;
                }
            }
    
            public bool EnableCopyingFiles
            {
                get
                {
                    return enableCopyingFiles;
                }
                set
                {
                    enableCopyingFiles = value;
                }
            }
    
            public FileSystemWatcher FSW
            {
                get
                {
                    return fsw;
                }
                set
                {
                    fsw = value;
                }
            }
            #endregion
    
            #region Construction
            /// <summary>
            /// Constructor.
            /// </summary>
            public Watcher()
            {
                // Intentionally left blank.
    
            }
            #endregion
    
            #region Public Methods
            /// <summary>
            /// Method which will initialise the required 
            /// file system watcher objects to starting watching.
            /// </summary>
            public void InitialiseFSW()
            {
                fsw = new FileSystemWatcher();
                bgWorker = new BackgroundWorker();
            }
    
            /// <summary>
            /// Method which will start watching.
            /// </summary>
            public void StartWatch()
            {
                if (fsw != null)
                {
                    fsw.Path = source;
                    fsw.Filter = filter;
                    fsw.IncludeSubdirectories = includeSubdirectories;
                    fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastAccess;
    
                    // Setup events.
                    fsw.Created += fsw_Created;
                    // Important to set the below otherwise no events will be raised.
                    fsw.EnableRaisingEvents = enableCopyingFiles;
                    bgWorker.DoWork += bgWorker_DoWork;
                }
                else
                {
                    Trace.WriteLine("File System Watcher is not initialised. Setting ISS Fault Alarm Bit");
                    //CommonActions.SetAlarmBit(ApplicationConstants.tag_AlarmTag, ApplicationConstants.bit_ISSFault);
                }
            }
    
            /// <summary>
            /// Method to stop watch.
            /// </summary>
            public void StopWatch()
            {
                // Stop Watcher.
                if (bgWorker != null)
                {
                    bgWorker.DoWork -= bgWorker_DoWork;
                }
                if (fsw != null)
                {
                    fsw.Created -= fsw_Created;
                }
            }
            #endregion
    
    
            #region Private Methods
            /// <summary>
            /// Method which will do the work on the background thread.
            /// Currently Move files from source to destination and 
            /// monitor disk capacity.
            /// </summary>
            /// <param name="sender">Object Sender</param>
            /// <param name="e">Event Arguments</param>
            private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
            {
              
            }
    
            private void PerformFileActions(string sourcePath)
            {
                string extractedFileName = Path.GetFileName(sourcePath);
                string newFileName = string.Empty;
    
                newFileName = "BatchCode" + "_" + extractedFileName;
    
                // We should now have the fully formed filename now. 
                // Move the file to the new location 
                string destPath = destination + @"\" + newFileName;
    
                var fi = new FileInfo(sourcePath);
    
    
                // TODO Check if the file exist. 
                if (File.Exists(Path.Combine(Source, extractedFileName)))
                {
    
                    // Check if the file is accessiable.
                    if (IsAccessible(fi, FileMode.Open, FileAccess.Read))
                    {
                        if (!File.Exists(destPath))
                        {
                            try
                            {
                                File.Copy(sourcePath, destPath);
                                File.SetAttributes(destPath, FileAttributes.ReadOnly);
    
                                // Wait before checking for the file exists at destination.
                                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["ExistsAtDestination"]));
                                // Check if the file has actually been moved to dest.
                                if (!File.Exists(destPath))
                                {
                                    // TODO Raise alarms here.
                                    Trace.WriteLine("Failed to Move. File does not exist in destination. Setting ISS Fault Alarm bit");
    
                                    //CommonActions.SetAlarmBit(ApplicationConstants.tag_AlarmTag, ApplicationConstants.bit_ISSFault);
                                    // Notify HMI about the error type.
                                    Trace.WriteLine("Failed to Move. File does not exist in destination.  Setting ISS File Move Fault Alarm bit");
                                }
                            }
                            catch (Exception ex)
                            {
                                // TODO log the exception and Raise alarm?
                                Trace.WriteLine("Failed to Move or set attributes on file. Setting ISS Fault Alarm bit");
    
    
                                //CommonActions.SetAlarmBit(ApplicationConstants.tag_AlarmTag, ApplicationConstants.bit_ISSFault);
                                // Notify HMI about the error type.
                                Trace.WriteLine("Failed to Move or set attributes on file. Setting ISS File Move Fault Alarm bit");
                            }
    
                        }
                        else
                        {
                            Trace.WriteLine("File Move failed as the file: " + newFileName + " already exists in the destination folder");
                        }
                    }
                    else
                    {
                        Trace.WriteLine("File Move failed. File is not accessible");
                    }
                }
            }
    
            /// <summary>
            /// Event which is raised when a file is created in the folder which is being watched.
            /// </summary>
            /// <param name="sender">Object sender</param>
            /// <param name="e">Event arguments</param>
            private void fsw_Created(object sender, FileSystemEventArgs e)
            {
                lock (fswLock)
                {
                    DateTime lastRead = DateTime.MinValue;
                   
                    DateTime lastWriteTime = File.GetCreationTime(e.FullPath);
                    if (lastWriteTime != lastRead)
                    {
                        eventCount++;
    
                        // Start a new task and forget.
                        Task.Factory.StartNew(() => {
                            PerformFileActions(e.FullPath);
                        });
    
                        lastRead = lastWriteTime;
                    }
                    
                }
            }
    
            /// <summary>
            /// Extension method to check if a file is accessible.
            /// </summary>
            /// <param name="fi">File Info</param>
            /// <param name="mode">File Mode</param>
            /// <param name="access">File Access</param>
            /// <returns>Attempts three times. True if the file is accessible</returns>
            private bool IsAccessible(FileInfo fi, FileMode mode, FileAccess access)
            {
                bool hasAccess = false;
                int i = 0;
                while (!hasAccess)
                {
                    try
                    {
                        using (var fileStream = File.Open(fi.FullName, mode, access))
                        {
    
                        }
    
                        hasAccess = true;
    
                        i = 1;
                        break;
                    }
                    catch (Exception ex)
                    {
    
                        if (i < 4)
                        {
                            // We will swallow the exception, wait and try again.
                            Thread.Sleep(500);
                            // Explicitly set hasaccess flag.
                            hasAccess = false;
                            i++;
                        }
                        else
                        {
                            i = 0;
                            Trace.WriteLine("Failed to Move. File is not accessable. " + ex.ToString());
                            // Notify HMI
                            Trace.WriteLine("Failed to Move. File is not accessable.. Setting ISS Fault Alarm bit");
    
                            
                            //CommonActions.SetAlarmBit(ApplicationConstants.tag_AlarmTag, ApplicationConstants.bit_ISSFault);
                            // Notify HMI about the error type.
                            Trace.WriteLine("Failed to Move. File is not accessable.. Setting ISS File Move Fault Alarm bit");
                            //CommonActions.SetAlarmBit(ApplicationConstants.tag_AlarmTag, ApplicationConstants.bit_ISSFileCopyFault);
                            // Explicitly set hasaccess flag.
                            hasAccess = false;
                            break;
                        }
                    }
                }
    
                // return hasAccess;
                return true;
            }
            #endregion
    
        }
