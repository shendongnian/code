    public enum DelimitedFileHeaderOptions
    {
        IncludeHeader,
        DoNotIncludeHeader
    }
    public class DelimitedFileResult<T> : FileResult where T : class
    {
        private const String DefaultFileName = "file.csv";
        private const String DefaultContentType = "text/csv";
        private const String DefaultDelimiter = ",";
        public DelimitedFileResult(IEnumerable<T> data, DelimitedFileHeaderOptions headerOption)
            : this(data, DefaultDelimiter, DefaultFileName, DefaultContentType, headerOption) { }
        public DelimitedFileResult(IEnumerable<T> data, String delimiter = DefaultDelimiter, String fileName = DefaultFileName, String contentType = DefaultContentType,
            DelimitedFileHeaderOptions headerOption = DelimitedFileHeaderOptions.IncludeHeader)
            : base(contentType)
        {
            _data = data;
            _delimiter = delimiter;
            FileDownloadName = fileName;
            _headerOption = headerOption;
        }
        protected override void WriteFile(HttpResponseBase response)
        {
            var builder = new StringBuilder();
            var properties = (from p in typeof (T).GetProperties() select p).ToList();
            var propertyNames = (from p in properties select p.GetDisplayName()).ToList();
            if (_headerOption == DelimitedFileHeaderOptions.IncludeHeader)
                builder.AppendLine(String.Join(_delimiter, propertyNames));
            foreach (T item in _data)
            {
                foreach (var property in properties)
                {
                    builder.Append(property.GetValue(item, null));
                    builder.Append(_delimiter);
                }
                builder.AppendLine();
            }
            response.Write(builder.ToString());
        }
        private readonly IEnumerable<T> _data;
        private readonly String _delimiter;
        private readonly DelimitedFileHeaderOptions _headerOption;
    }
