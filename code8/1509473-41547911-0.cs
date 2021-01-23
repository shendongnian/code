    public class CSVExportViewModel
    {
        public long Id { get; set; }
        public string StudentNo { get; set; }
        public string StudentIdNumber { get; set; }
        public string StudentName { get; set; }
        public string Parent1IdNumber { get; set; }
        public string Parent1Name { get; set; }
        public string Parent2IdNumber { get; set; }
        public string Parent2Name { get; set; }
        /* etc... */
        public String[] ToArray()
        {
            List<string> arr = new List<string>();
            foreach (var prop in typeof(CSVExportViewModel).GetProperties())
            {
                string value = "";
                if (prop.GetValue(this, null) != null)
                {
                    value = prop.GetValue(this, null).ToString();
                }
                arr.Add(value);
            }
            return arr.ToArray();
        }
    }
