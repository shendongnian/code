    if (requestCode == PickImageId)
        {
            if ((resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                Stream stream = ContentResolver.OpenInputStream(uri);
                // Set the Stream as the completion of the Task
                PickImageTaskCompletionSource.SetResult(stream);
            }
            else
            {
                PickImageTaskCompletionSource.SetResult(null);
            }
        }else
        {
          AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }
         
