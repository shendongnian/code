    namespace PostFinder
    {
        class HistorySaver
    {
        public static void Save(string item, string path)
        {
            File.AppendAllText(path, item + Environment.NewLine);
        }
    }
}
