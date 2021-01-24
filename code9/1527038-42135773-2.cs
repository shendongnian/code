    public class ExcelFileCreator
    {
        /// <summary>
        /// Generates a FileStreamResult containing a Excel file in it
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the Excel file</param>
        /// <param name="fileName">The file name of the Excel</param>
        /// <returns>FileStreamResult</returns>
        public FileStreamResult CreateExcelFileFileStreamResult<T>(IEnumerable<T> objectList, string fileName)
        {
            var ms = new MemoryStream();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            try
            {
                ExcelPackage excelPackage = new ExcelPackage(ms);
                excelPackage.Compression = OfficeOpenXml.CompressionLevel.BestCompression;
                var workSheet1 = excelPackage.Workbook.Worksheets.Add("Sheet1");
                workSheet1.Cells["A1"].LoadFromCollection<T>(objectList, true);
                var firstRow = workSheet1.Row(1);
                if(firstRow != null)
                    firstRow.Style.Font.Bold = true;
                excelPackage.SaveAs(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var fsr = new FileStreamResult(ms, contentType);
                fsr.FileDownloadName = fileName;
                return fsr;
            }
            catch (Exception ex)
            {
                if (ms != null)
                {
                    ms.Dispose();
                }
                throw;
            }
        }
        /// <summary>
        /// Generates a FileStreamResult containing a zip file with the EXCEL file in it
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the EXCEL file</param>
        /// <param name="fileName">The file name of the EXCEL</param>
        /// <returns>FileStreamResult</returns>        
        public FileContentResult CreateZipFileFileContentResult<T>(IEnumerable<T> objectList, string fileName)
        {
            var contentType = System.Net.Mime.MediaTypeNames.Application.Zip;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        var workSheet1 = package.Workbook.Worksheets.Add("Sheet1");
                        workSheet1.Cells["A1"].LoadFromCollection<T>(objectList, true);
                        var firstRow = workSheet1.Row(1);
                        if (firstRow != null)
                            firstRow.Style.Font.Bold = true;
                        zip.AddEntry(fileName, package.GetAsByteArray());
                        zip.Save(memoryStream);
                        var fcr = new FileContentResult(memoryStream.ToArray(), contentType); //NOTE: Using a File Stream Result will not work.
                        fcr.FileDownloadName = fileName + ".zip";
                        return fcr;
                    }
                }
            }
        }
        /// <summary>
        /// Generates a HttpResponseMessage containing a Excel file in it
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the Excel file</param>
        /// <param name="fileName">The file name of the Excel</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage CreateExcelFileHttpResponseMessage<T>(IEnumerable<T> objectList, string fileName)
        {
            using (var ms = new MemoryStream())
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                using (ExcelPackage excelPackage = new ExcelPackage(ms))
                {
                    var workSheet1 = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    workSheet1.Cells["A1"].LoadFromCollection<T>(objectList, true);
                }
                result.Content = new ByteArrayContent(ms.GetBuffer());
                result.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                return result;
            }
        }
        /// <summary>
        /// Generates a HttpResponseMessage containing a zip file with the EXCEL file in it
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the EXCEL file</param>
        /// <param name="fileName">The file name of the EXCEL</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage CreateZipFileHttpResponseMessage<T>(IEnumerable<T> objectList, string fileName)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            using (var ms = new MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(ms, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    var newEntry = archive.CreateEntry(fileName, System.IO.Compression.CompressionLevel.Fastest);
                    using (var newEntryStream = newEntry.Open())
                    using (ExcelPackage excelPackage = new ExcelPackage(ms))
                    {
                        var workSheet1 = excelPackage.Workbook.Worksheets.Add("Sheet1");
                        workSheet1.Cells["A1"].LoadFromCollection<T>(objectList, true);
                    }
                }
                ms.Seek(0, SeekOrigin.Begin);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName + ".zip"
                };
                return result;
            }
        }
    }
