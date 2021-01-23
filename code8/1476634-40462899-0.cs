    public interface IPDFBuilder
    {
        void CreatePDF(string templatefilepath, string templatefilename,
            Dictionary<string, string> dict);
    }
