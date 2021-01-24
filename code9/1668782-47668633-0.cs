    public class XenImageUploader : IDisposable
    {
        public static XenImageUploader Create(Session session, IComponentLogger parentComponentLogger)
        {
            var logger = new ComponentLogger(parentComponentLogger, typeof(XenImageUploader));
            
            var taskHandler = new XenTaskHandler(
                taskReference: session.RegisterNewTask(UploadTaskName, logger),
                currentSession: session);
            return new XenImageUploader(session, taskHandler, logger);
        }
        private XenImageUploader(Session session, XenTaskHandler xenTaskHandler, IComponentLogger logger)
        {
            _session = session;
            _xenTaskHandler = xenTaskHandler;
            _logger = logger;
            _imageUploadingHasFinishedEvent = new AutoResetEvent(initialState: false);
            _xenApiUploadCancellationReactionTime = new TimeSpan();
        }
        public Maybe<string> Upload(
            string imageFilePath,
            XenStorage destinationStorage,
            ProgressToken progressToken,
            JobCancellationToken cancellationToken)
        {
            _logger.WriteDebug("Image uploading has started.");
            var imageUploadingThread = new Thread(() =>
                UploadImageOfVirtualMachine(
                    imageFilePath: imageFilePath,
                    storageReference: destinationStorage.GetReference(),
                    isTaskCancelled: () => cancellationToken.IsCancellationRequested));
            imageUploadingThread.Start();
            using (new Timer(
                callback: _ => WatchForImageUploadingState(imageUploadingThread, progressToken, cancellationToken),
                state: null,
                dueTime: TimeSpan.Zero,
                period: TaskStatusUpdateTime))
            {
                _imageUploadingHasFinishedEvent.WaitOne(MaxTimeToUploadSvm);
            }
            cancellationToken.PerformCancellationIfRequested();
            return _xenTaskHandler.TaskIsSucceded
                ? new Maybe<string>(((string) _xenTaskHandler.Result).GetOpaqueReferenceFromResult())
                : new Maybe<string>();
        }
        public void Dispose()
        {
            _imageUploadingHasFinishedEvent.Dispose();
        }
        private void UploadImageOfVirtualMachine(string imageFilePath, XenRef<SR> storageReference, Func<bool> isTaskCancelled)
        {
            try
            {
                _logger.WriteDebug("Uploading thread has started.");
                HTTP_actions.put_import(
                    progressDelegate: progress => { },
                    cancellingDelegate: () => isTaskCancelled(),
                    timeout_ms: -1,
                    hostname: new Uri(_session.Url).Host,
                    proxy: null,
                    path: imageFilePath,
                    task_id: _xenTaskHandler.TaskReference,
                    session_id: _session.uuid,
                    restore: false,
                    force: false,
                    sr_id: storageReference);
                _xenTaskHandler.WaitCompletion();
                _logger.WriteDebug("Uploading thread has finished.");
            }
            catch (HTTP.CancelledException exception)
            {
                _logger.WriteInfo("Image uploading has been cancelled.");
                _logger.WriteInfo(exception.ToDetailedString());
            }
            _imageUploadingHasFinishedEvent.Set();
        }
        private void WatchForImageUploadingState(Thread imageUploadingThread, ProgressToken progressToken, JobCancellationToken cancellationToken)
        {
            progressToken.Progress = _xenTaskHandler.Progress;
            if (!cancellationToken.IsCancellationRequested)
            {
                return;
            }
            _xenApiUploadCancellationReactionTime += TaskStatusUpdateTime;
            if (_xenApiUploadCancellationReactionTime >= TimeForXenApiToReactOnCancel)
            {
                _logger.WriteWarning($"XenApi didn't cancel for {_xenApiUploadCancellationReactionTime}.");
                if (imageUploadingThread.IsAlive)
                {
                    try
                    {
                        _logger.WriteWarning("Trying to forcefully abort uploading thread.");
                        imageUploadingThread.Abort();
                    }
                    catch (Exception exception)
                    {
                        _logger.WriteError(exception.ToDetailedString());
                    }
                }
                _imageUploadingHasFinishedEvent.Set();
            }
        }
        private const string UploadTaskName = "Xen image uploading";
        private static readonly TimeSpan TaskStatusUpdateTime = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan TimeForXenApiToReactOnCancel = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan MaxTimeToUploadSvm = TimeSpan.FromMinutes(20);
        private readonly Session _session;
        private readonly XenTaskHandler _xenTaskHandler;
        private readonly IComponentLogger _logger;
        private readonly AutoResetEvent _imageUploadingHasFinishedEvent;
        private TimeSpan _xenApiUploadCancellationReactionTime;
    }
