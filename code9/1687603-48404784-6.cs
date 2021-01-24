    public class MyTaskResults
    {
        public int TaskID { get; set; }
        public string TextDirPath { get; set; }
        public string ImagesDirPath { get; set; }
        public string NativesDirPath { get; set; }
        public List<string> TextDirPathResult { get; set; }
        public List<string> ImagesDirPathResult { get; set; }
        public List<string> NativesDirPathResult { get; set; }
    }
    //List of MyTaskResults Class, used to store all Tasks run and their results
    List<MyTaskResults> _ListOfTasks = new List<MyTaskResults>();
    int _TasksCounter = 0;
