      public class FileFetchManager
    {
        public const string DEFAULT_FILE_TYPE = "txt";
        public static readonly string[] IMAGE_TYPES = { "bmp", "jpg", "jpeg", "png", "gif", "tiff", "tif" };
        public static string GetFileFetchUrl(string TableName, string FieldName, string FileNameFieldName, string PrimaryKeyValue)
        {
            return GetFileFetchUrl(TableName, FieldName, FileNameFieldName, PrimaryKeyValue, null);
        }
        public static string GetFileFetchUrl(string TableName, string FieldName, string FileNameFieldName, string PrimaryKeyValue, int? thumbnailImageSize)
        {
            return QueryStringCoder.CodeUrl("~/UserControl/JcoDataGrid/DBFileFetch.aspx?t=" + TableName + "&f=" + FieldName + "&fnf=" + FileNameFieldName + "&i=" + PrimaryKeyValue + (thumbnailImageSize == null ? "" : "&s=" + thumbnailImageSize));
        }
        public static string GetFileFetchUrl(string fileBytesSessionName, string fileName)
        {
            return GetFileFetchUrl(fileBytesSessionName, fileName, null);
        }
        public static string GetFileFetchUrl(string fileBytesSessionName, string fileName, int? thumbnailImageSize)
        {
            return QueryStringCoder.CodeUrl("~/UserControl/JcoDataGrid/MemoryFileFetch.aspx?sn=" + fileBytesSessionName + "&fn=" + fileName + (thumbnailImageSize == null ? "" : "&s=" + thumbnailImageSize));
        }
        public static string GetFileType(string fileName)
        {
            if (fileName.IsNullOrWhiteSpace())
                return DEFAULT_FILE_TYPE;
            return fileName.Substring(fileName.IndexOf(".") + 1);
        }
        public static bool IsImage(string fileName)
        {
            string fileType = fileName.Substring(fileName.LastIndexOf(".") + 1);
            bool isImage = FileFetchManager.IMAGE_TYPES.Contains(fileType, StringComparison.OrdinalIgnoreCase, true);
            return isImage;
        }
        public static byte[] GetThumbnailImage(string fileName, byte[] imageBytes, int size)
        {
            if (size <= 0)
                throw new Exception("ErrorCode : 1390/10/23-22:04 : " + QueryStringCoder.Code("اندازه درخواستي جهت تامبنيل تصوير(" + size + ") مجاز نمي باشد!"));
            ImageFormat imageType = ConvertFileExtensionToImageFormat(GetFileType(fileName));
            MemoryStream ms = new MemoryStream(imageBytes);
            ms.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            int width;
            int height;
            if (img.Height > img.Width)
            {
                height = size.ToInt();
                width = img.Width * size.ToInt() / img.Height;
            }
            else //if (img.height <= img.width)
            {
                width = size.ToInt();
                height = img.Height * size.ToInt() / img.Width;
            }
            if (imageType == ImageFormat.Png || imageType == ImageFormat.Gif)
            {                
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                img = img.GetThumbnailImage(width, height, myCallback, IntPtr.Zero);
                imageType = ImageFormat.Png;
            }
            else
                img = ImageResizer.ConstrainProportions(img, height, Dimensions.Height);
            MemoryStream thumbnailImageStream = new MemoryStream();
            thumbnailImageStream.Position = 0;
            img.Save(thumbnailImageStream, imageType);
            return thumbnailImageStream.ToArray();
        }
        public static bool ThumbnailCallback()
        {
            return false;
        }
        public static ImageFormat ConvertFileExtensionToImageFormat(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case "jpeg":
                case "jpg":
                    return ImageFormat.Jpeg;
                case "bitmap":
                case "bmp":
                    return ImageFormat.Bmp;
                case "gif":
                    return ImageFormat.Gif;
                case "icon":
                case "ico":
                    return ImageFormat.Icon;
                case "png":
                    return ImageFormat.Png;
                case "tiff":
                case "tif":
                    return ImageFormat.Tiff;
                default:
                    throw new NotImplementedException();
                //break;
            }
        }
        public static void SetResposeContentType(string fileName)
        {
            string fileType = fileName.Substring(fileName.LastIndexOf(".") + 1);
            if (FileFetchManager.IMAGE_TYPES.Contains(fileType, StringComparison.OrdinalIgnoreCase, true))
                HttpContext.Current.Response.ContentType = "image/" + FileFetchManager.ConvertFileExtensionToImageFormat(fileType).ToString();
            else
                HttpContext.Current.Response.ContentType = "application/" + fileType;
        }
    }
