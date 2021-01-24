    private void CopyFromFileToFile(string inputFileDest, string outputFileDest)
    {
        string[] lines;
        lines = System.IO.File.ReadAllLines(inputFileDest);
        System.IO.File.WriteAllLines(outputFileDest, lines);
    }
