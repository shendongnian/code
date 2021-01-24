    protected IEnumerator downloadObject(string target_file, string target_path, int item_index)
    {
        if (target_file != "")
        {
            FirebaseStorage storage = FirebaseStorage.DefaultInstance;
            string local_url = target_path.Replace("\\", "/").Replace("//", "/");
            StorageReference storage_ref =
                storage.GetReferenceFromUrl(FB_Conf.gsURL + target_file);
            Task task = null;
            try
            {
                task = storage_ref.GetFileAsync(local_url,
                    new Firebase.Storage.StorageProgress<DownloadState>((DownloadState state) =>
                {
                // called periodically during the download
                    long tbyte = state.TotalByteCount;
                    file_progress = (float)state.BytesTransferred / (float)tbyte;
                }), CancellationToken.None);
            }
            catch (Exception exc)
            {                
                Debug.Log("Get file async error: " + exc.Message);
            }
            if (task != null)
            {
                yield return new WaitUntil(() => task.IsCompleted);
                task.ContinueWith((resultTask) =>
                {
                    if ((resultTask.IsFaulted) || (resultTask.IsCanceled))
                    {
                        error_count++;
                        string msg = (resultTask.IsCanceled) ? "Download error." : "";
                        if ((resultTask.Exception != null) &&
                            (resultTask.Exception.InnerExceptions.Count > 0) &&
                            (resultTask.Exception.InnerExceptions[0] is Firebase.Storage.StorageException))
                            msg = ((Firebase.Storage.StorageException)resultTask.Exception.InnerExceptions[0]).HttpResultCode.ToString();
                        else if (resultTask.Exception != null)
                            msg = resultTask.Exception.Message;                        
                    }
                });
            }
            else
            {
                error_count++;
            }
        }
    }
