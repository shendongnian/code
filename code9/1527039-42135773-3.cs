    /// <summary>
    /// Enumerator for the CSV file separator
    /// </summary>
    public enum CsvFileSeparatorType
    {
        /// <summary>
        /// Values will be separated by a comma: ", "
        /// </summary>
        Comma
        ,
        /// <summary>
        /// Values will be separated by a tab delimiter: "\t "
        /// </summary>
        Tab
        ,
        /// <summary>
        /// Values will be separated by a semicolon: "; "
        /// </summary>
        Semicolon
    }
    /// <summary>
    /// This class helps create a CSV file
    /// </summary>
    public class CsvFileCreator
    {
        public CsvFileSeparatorType CsvFileSeparatorType
        {
            get
            {
                CsvFileSeparatorType csvFileSeparatorType = CsvFileSeparatorType.Tab;
                switch (ConfigurationManager.AppSettings["CsvFileSeparatorType"])
                {
                    case "Comma":
                        csvFileSeparatorType = CsvFileSeparatorType.Comma;
                        break;
                    case "Tab":
                        csvFileSeparatorType = CsvFileSeparatorType.Tab;
                        break;
                    case "Semicolon":
                        csvFileSeparatorType = CsvFileSeparatorType.Semicolon;
                        break;
                    default:
                        csvFileSeparatorType = CsvFileSeparatorType.Tab;
                        break;
                }
                return csvFileSeparatorType;
            }
        }
        /// <summary>
        /// Generates a HttpResponseMessage containing a zip file with the CSV file in it
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the CSV file</param>
        /// <param name="fileName">The file name of the CSV</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage CreateZipFileHttpResponseMessage<T>(IEnumerable<T> objectList, string fileName)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var csvEnumerable = CreateCsvEnumerable<T>(objectList, CsvFileSeparatorType);
                    var newEntry = archive.CreateEntry(fileName, CompressionLevel.Fastest);
                    using (var newEntryStream = newEntry.Open())
                    using (var streamWriter = new StreamWriter(newEntryStream))
                    {
                        foreach (var csvLine in csvEnumerable)
                        {
                            streamWriter.WriteLine(csvLine);
                        }
                        streamWriter.Flush();
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
        /// <summary>
        /// Generates a HttpResponseMessage containing a CSV file in it
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the CSV file</param>
        /// <param name="fileName">The file name of the CSV</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage CreateCsvFileHttpResponseMessage<T>(IEnumerable<T> objectList, string fileName)
        {
            using (var ms = new MemoryStream())
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                using (var streamWriter = new StreamWriter(ms))
                {
                    var csvEnumerable = CreateCsvEnumerable<T>(objectList, CsvFileSeparatorType);
                    foreach (var csvLine in csvEnumerable)
                    {
                        streamWriter.WriteLine(csvLine);
                    }
                    streamWriter.Flush();
                }
                result.Content = new ByteArrayContent(ms.GetBuffer());
                result.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                return result;
            }
        }
        /// <summary>
        /// Generates an Enumerable containing the CSV data in it. First row contains the headers
        /// </summary>
        /// <typeparam name="T">Type of object in the object list parameter</typeparam>
        /// <param name="objectList">The object list enumerable. This contains the data for the CSV file</param>
        /// <param name="separatorType">Enumerator for the CSV file separator</param>
        /// <returns>IEnumerable</returns>
        private IEnumerable<string> CreateCsvEnumerable<T>(IEnumerable<T> objectlist, CsvFileSeparatorType separatorType)
        {
            string separator = ", ";
            switch (separatorType)
            {
                case CsvFileSeparatorType.Comma:
                    separator = ", ";
                    break;
                case CsvFileSeparatorType.Semicolon:
                    separator = "; ";
                    break;
                case CsvFileSeparatorType.Tab:
                    separator = "\t ";
                    break;
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            yield return "\"" + String.Join(separator, properties.Select(f => f.Name).ToArray()) + "\"";
            foreach (var o in objectlist)
            {
                yield return "\"" + HttpUtility.HtmlDecode(string.Join(separator, properties.Select(f => (f.GetValue(o) ?? "").ToString()).ToArray())) + "\"";
            }
        }
    }
