     string OcrResultsToString(OcrResults results)
     {
        StringBuilder stringBuilder = new StringBuilder();
        if (results != null && results.Regions != null)
        {
            foreach (var item in results.Regions)
            {
                foreach (var line in item.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        stringBuilder.Append(word.Text);
                        stringBuilder.Append(" ");
                    }
                    stringBuilder.AppendLine();
                }
                stringBuilder.AppendLine();
            }
        }
        return stringBuilder.ToString();
    }
