    static void Main(string[] args)
    {
        string parseDirectory = ConfigurationManager.AppSettings["ParseDirectory"];
        string archiveDirectory = ConfigurationManager.AppSettings["ArchiveDirectory"];
        string parseSearchPattern = ConfigurationManager.AppSettings["ParseSearchPattern"];
        foreach (string fileName in Directory.GetFiles(parseDirectory,parseSearchPattern))
        {
            var json = System.IO.File.ReadAllText(fileName);
            var fi = new FileInfo(fileName);
            object obj = JArray.Parse(json);
            var messageList = JsonConvert.DeserializeObject<List<RootObject>>(obj.ToString());
            DataTable dt = ConvertToDataTable(messageList);
            SaveToExcel(dt, Path.GetFileNameWithoutExtension(fileName));
            MoveTo(fi, parseDirectory, archiveDirectory);
        }
    }
    static void SaveToExcel(DataTable dt, string fileName)
    {
        foreach (DataRow dr in dt.Rows)
        {
            string date = dt.Rows[0]["date"].ToString();
            string message = dt.Rows[0]["message"].ToString();
            string file = dt.Rows[0]["file"].ToString();
            string from = dt.Rows[0]["from"].ToString();
            string name = ((JSON_Reader.Program.From)(dr.ItemArray[1])).name.ToString();
            string userId = ((JSON_Reader.Program.From)(dr.ItemArray[1])).user_id.ToString();
        }         
    }
    private static void MoveTo(FileInfo fi, string sourceDirectory, string targetDirectory)
    {
        string targetFilename = string.Format("{0}{1}", targetDirectory, fi.FullName.Replace(sourceDirectory, ""));
        FileInfo targetFile = new FileInfo(targetFilename);
        try
        {
            if (!targetFile.Directory.Exists)
            {
                targetFile.Directory.Create();
            }
            fi.MoveTo(targetFilename);
        }
        catch (Exception exc2)
        {
            Trace.TraceError("Error moving {0} to {1}: {2}\n{3}", fi.FullName, targetFilename, exc2.Message, exc2.StackTrace);
        }
    }
    public class From
    {
        public string name { get; set; }
        public int user_id { get; set; }
    }
    public class File
    {
        public string name { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class RootObject
    {
        public string date { get; set; }
        public From from { get; set; }
        public string message { get; set; }
        public File file { get; set; }
    }
    public static DataTable ConvertToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties =
           TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;
    }
    }
