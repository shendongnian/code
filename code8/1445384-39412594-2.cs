    public class UploadUtil
    {
    
        public static Task<string> UploadBase64Async(string bucket,string filelocation)
        {
           var tcs = new TaskCompletionSource();
           qiniu.Config.InitFromAppConfig();
    
            string qiniuKey = Guid.NewGuid().ToString();
    
            // I think there is an issue here : jpeg is never used
            jpegToBase64 jpeg = new jpegToBase64(filelocation);
            QiniuFile qfile = new QiniuFile(bucket, qiniuKey);
            qfile.UploadCompleted += (sender, e) => {
                var returnUrl = e.RawString;
                Console.Write(returnUrl);
                tcs.SetResult(returnUrl);    
            };
            qfile.UploadFailed += (sender, e) => {
                QiniuWebException qe = (QiniuWebException)e.Error;
                Console.WriteLine(qe.Error.ToString());
                tcs.SetException(qe);  
            };
            qfile.UploadString((int)jpeg.Filesize, "image/png", jpeg.Base64Content);
            return tcs.Task;    
        }
    
    }
