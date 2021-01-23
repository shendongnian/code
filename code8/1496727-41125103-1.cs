    public class Helper
    {
        // General cover-it-all implementation that accepts an option object
        // and analyzes based on the flags that are set in it
        public static CSVStatistics AnalyzeCSV(string file, CSVAnalysisOptions options)
        {
            // define what we are analysing by reading it from the
            // from the options object and do your magic here
        }
        // Specific implementation that counts only blank lines
        public static long CountBlankLines(string file)
        {
            var analysisResult = AnalyseCSV(file, new CSVAnalysisOptions
            {
                IsCountingBlanks = true
            });
            //I'm not doing a null check here, because I'm settings the
            //flag to True and therefore I expect there to be a value
            return analysisResult.BlanksCount.Value;
        }
    }
    // Analysis options structure
    public struct CSVAnalysisOptions
    {
        public bool IsCountingBlanks { get; set; }
        public bool IsCountingDuplicates { get; set; }
        public bool IsCountingOther { get; set; }
    }
    // Analysis results structure
    public struct CSVStatistics
    {
        public long TotalLineCount { get; set; }
        public long? BlanksCount { get; set; }
        public long? DuplicatesCount { get; set; }
        
    }
