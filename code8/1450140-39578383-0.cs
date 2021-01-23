        public static bool IsWritable(string path)
        {
            Func<string, bool> canBeWrittenTo = p => true;// (details omitted)
            return System.IO.File.Exists(path) && canBeWrittenTo(path);
        }
