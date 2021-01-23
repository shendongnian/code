    string OcrResultsToString(OcrResult result)
    {
        return string.Join("\n",
            result.Regions.ToList().Select(region =>
                string.Join(" ", region.Lines.ToList().Select(line =>
                     string.Join(" ", line.Words.ToList().Select(word =>
                         word.Text).ToArray())).ToArray())).ToArray());
    }
