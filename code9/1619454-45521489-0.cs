    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileStatus filestatus = new FileStatus();
                filestatus.Load();
                DataTable pivot = filestatus.PivotTable();
            }
        }
        public class FileStatus
        {
            public static List<FileStatus> filedata = new List<FileStatus>();
            public int? Id { get; set; }
            public string filename { get; set; }
            public DateTime date { get; set; }
            public string status { get; set; }
            public void Load()
            {
                filedata = new List<FileStatus>()
                {
                    new FileStatus(){ Id = 1, filename = "file1", date = new DateTime(2016,05,12,11,30,00), status = "fail"},
                    new FileStatus(){ Id = 2, filename = "file1", date = new DateTime(2016,05,12,11,35,00), status = "success"},
                    new FileStatus(){ Id = 3, filename = "file2", date = new DateTime(2016,05,13,12,01,00), status = "success"},
                    new FileStatus(){ Id = 4, filename = "file2", date = new DateTime(2016,05,13,12,02,00), status = "fail"},
                    new FileStatus(){ Id = 5, filename = "file1", date = new DateTime(2016,05,13,12,30,00), status = "success"},
                    new FileStatus(){ Id = 6, filename = "file3", date = new DateTime(2016,05,13,12,31,00), status = "fail"}
                };
            }
            public DataTable PivotTable()
            {
                DataTable pivot = new DataTable();
                DateTime[] uniqueDates = filedata.Select(x => x.date.Date).Distinct().OrderBy(x => x).ToArray();
                pivot.Columns.Add("filename", typeof(string));
                foreach (DateTime date in uniqueDates)
                {
                    pivot.Columns.Add(date.ToString("MM-dd-yyyy"), typeof(string));
                }
                var groups = filedata.GroupBy(x => x.filename).ToList();
                foreach (var group in groups)
                {
                    DataRow newRow = pivot.Rows.Add();
                    newRow["filename"] = group.Key;
                    foreach (FileStatus filestatus in group)
                    {
                        newRow[filestatus.date.ToString("MM-dd-yyyy")] = filestatus.status;
                    }
                }
                return pivot;
            }
        }
    }
