    public class WorkChain
    {
        private readonly TransformBlock<string, FileInfo> stepOneGetFileInfo;
        private readonly TransformBlock<FileInfo, System.Guid?> stepTwoPostToWebApi;
        private readonly ActionBlock<System.Guid?> stepThreeDisplayIdToUser;
        public WorkChain()
        {
            stepOneGetFileInfo = new TransformBlock<string, FileInfo>(new Func<string, FileInfo>(GetFileInfo));
            stepTwoPostToWebApi = new TransformBlock<FileInfo, System.Guid?>(new Func<FileInfo, Task<Guid?>>(PostToWebApi));
            stepThreeDisplayIdToUser = new ActionBlock<System.Guid?>(new Action<Guid?>(DisplayIdToUser));
            stepOneGetFileInfo.LinkTo(stepTwoPostToWebApi, new DataflowLinkOptions() {PropagateCompletion = true});
            stepTwoPostToWebApi.LinkTo(stepThreeDisplayIdToUser, new DataflowLinkOptions() {PropagateCompletion = true});
        }
        public void PostToStepOne(string path)
        {
            bool result = stepOneGetFileInfo.Post(path);
            if (!result)
            {
                throw new InvalidOperationException("Failed to post to stepOneGetFileInfo");
            }
        }
        public void PostToStepTwo(FileInfo csv)
        {
            bool result = stepTwoPostToWebApi.Post(csv);
            if (!result)
            {
                throw new InvalidOperationException("Failed to post to stepTwoPostToWebApi");
            }
        }
        public void PostToStepThree(Guid id)
        {
            bool result = stepThreeDisplayIdToUser.Post(id);
            if (!result)
            {
                throw new InvalidOperationException("Failed to post to stepThreeDisplayIdToUser");
            }
        }
        public void CompleteAdding()
        {
            stepOneGetFileInfo.Complete();
        }
        public Task Completion { get { return stepThreeDisplayIdToUser.Completion; } }
        
        private FileInfo GetFileInfo(string path)
        {
            try
            {
                return new FileInfo(path);
            }
            catch (Exception ex)
            {
                LogGetFileInfoError(ex);
                return null;
            }
        }
        private async Task<Guid?> PostToWebApi(FileInfo csv)
        {
            if (csv == null)
                return null;
            try
            {
                dynamic task = await ApiUtils.SubmitData(csv.FullName);
                return task.guid;
            }
            catch (Exception ex)
            {
                LogPostToWebApiError(ex);
                return null;
            }
        }
        private void DisplayIdToUser(Guid? obj)
        {
            if(obj == null)
                return;
            
            Console.WriteLine(obj.Value);
        }
    }
