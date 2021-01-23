     using System;
     using System.Threading.Tasks;
     using System.IO;
     
     using Amazon.Lambda.Core;
     using Amazon.Lambda.Serialization;
     using Amazon.S3;
     using Amazon;
     using Amazon.S3.Model;
     using Pomelo.Data.MySql;
     using System.Drawing;
     using Amazon.S3.Transfer;
     //using ImageNet;
     //using ImageResizer;
     
     // Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
     [assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
     
     namespace Cropper
     {
         public class Crop
         {
             IAmazonS3 s3Client { get; set; }
             private Image orgImg;
             private MySqlConnection dbConn = new MySqlConnection();
             private MySqlCommand cmd = new MySqlCommand(); 
     
             public Crop()
             {
                 s3Client = new AmazonS3Client();
             }
     
             /*private static string s3AccessKey = Environment.GetEnvironmentVariable("S3AccessKey");
             private static string s3SecretKey = Environment.GetEnvironmentVariable("S3SecretKey");
             private static string s3Region = Environment.GetEnvironmentVariable("S3Region");
             private AmazonS3Client s3Client = new AmazonS3Client(s3AccessKey,s3SecretKey, RegionEndpoint.GetBySystemName(s3Region));
             */
     
             // public async Task<string> CropImage(string sourceBucket, string key, string destBucket, string permission)
             //public async void CropImage(string sourceBucket, string key, string destBucket, string permission)
             public async Task<string> CropImage(string input, ILambdaContext context)
             {
                 s3Client = new AmazonS3Client();
     
                 string[] arr = input.Split(',');
                 string sourceBucket = arr[0].Trim();
                 string key = arr[1].Trim();
                 string destBucket = arr[2].Trim();
                 //string size = arr[3].Trim();
                 //string crop = arr[3].Trim();
                 string permission = arr[3].Trim();
     
                 string path = Path.Combine("/tmp", key);
     
                 try
                 {
                     Console.WriteLine("Checkpoint - 0");
     
                     TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                     TransferUtilityDownloadRequest downloadRequest = new TransferUtilityDownloadRequest();
                     
                     Console.WriteLine("path - " + path);
     
                     if (File.Exists(path))
                     {
                         File.Delete(path);
                     }
                     downloadRequest.FilePath = path;
                     downloadRequest.BucketName = sourceBucket;
                     downloadRequest.Key = key;
                     fileTransferUtility.Download(downloadRequest);
     
                     Console.WriteLine("Checkpoint - file transfer");
     
                     orgImg = Image.FromFile(path);
                     orgImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                     //FluentImage.FromFile(path)
                     //   .Resize.Width(200)
                     //   .Save("/tmp/test_file.png", OutputFormat.Png);
     
     
     
                     Console.WriteLine("Checkpoint - Img creation");
     
                     TransferUtilityUploadRequest uploadRequest = new TransferUtilityUploadRequest();
                     //uploadRequest.FilePath = "/tmp/test_file.png";
                     uploadRequest.FilePath = path;
                     uploadRequest.BucketName = destBucket;
                     uploadRequest.Key = key;
                     if (permission.ToUpper() == "PUBLIC")
                     {
                         uploadRequest.CannedACL = S3CannedACL.PublicRead;
                     }
                     else if (permission.ToUpper() == "PRIVATE")
                     {
                         uploadRequest.CannedACL = S3CannedACL.Private;
                     }
                     else if (permission.ToUpper() == "NONE")
                     {
                         uploadRequest.CannedACL = S3CannedACL.NoACL;
                     }
                     fileTransferUtility.Upload(uploadRequest);
     
                     Console.WriteLine("Checkpoint - Done");
     
                     return context.AwsRequestId.ToString();
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine("ex message - " + ex.Message);
                     Console.WriteLine("ex stack - " + ex.StackTrace);
                     return ex.Message;
                     //context.Logger.LogLine(ex.Message);
                 }
                 finally
                 {
                     if (File.Exists(path))
                     {
                         File.Delete(path);
                     }
                     if (orgImg != null)
                     {
                         orgImg.Dispose();
                     }
                 }
             }
     
             //private byte[] ToArrayBytes(Stream input)
             //{
             //    byte[] buffer = new byte[16 * 1024];
             //    using (MemoryStream ms = new MemoryStream())
             //    {
             //        int read;
             //        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
             //        {
             //            ms.Write(buffer, 0, read);
             //        }
             //        return ms.ToArray();
             //    }
             //}
     
             //private byte[] ImageToByte(Image img)
             //{
             //    ImageConverter converter = new ImageConverter();
             //    return (byte[])converter.ConvertTo(img, typeof(byte[]));
             //}
         }
     }
     
