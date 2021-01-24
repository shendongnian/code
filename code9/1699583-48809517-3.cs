    public static List<String[]> SplitFile(String filePath, Encoding textEncoding, Char separator)
    {
        String fileContents = File.ReadAllText(filePath, textEncoding);
        List<String[]> splitLines = new List<String[]>();
        try
        {
            using (StringReader sr = new StringReader(fileContents))
            using (TextFieldParser tfp = new TextFieldParser(sr))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.Delimiters = new String[] { separator.ToString() };
                while (true)
                {
                    String[] curLine = tfp.ReadFields();
                    if (curLine == null)
                        break;
                    splitLines.Add(curLine);
                }
            }
            return splitLines;
        }
        catch (MalformedLineException mfle)
        {
            throw new FormatException(String.Format("Could not parse line {0} in file {1}!", mfle.LineNumber, filePath));
        }
    }
