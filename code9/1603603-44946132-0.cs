    public void OnSuccess(Java.Lang.Object result)
            {
                 pd.Dismiss();
                string uploadId = mDatabaseImage.Push().Key;
                var snapshot = result as SnapshotBase;
                string url = ((UploadTask.TaskSnapshot)result).DownloadUrl.ToString();
                mDatabaseImage.Child(count.ToString()).Child(user.Uid).Child(phId).Child(uploadId).SetValue(new PeaceHeroImage(url).ToMap());
    
                Toast.MakeText(this, "Image Uploaded Successfully", ToastLength.Short).Show();
    
            }
