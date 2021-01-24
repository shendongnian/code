    public static List<String[]> SplitFile(String filename, Encoding textEncoding, Char splitChar)
    {
        String[] fileLines = File.ReadAllLines(filename, textEncoding);            
        List<String[]> splitLines = new List<String[]>();
        foreach (String line in fileLines)
        {
            try
            {
                String[] splitparts;
                using (StringReader sr = new StringReader(line))
                using (TextFieldParser tfp = new TextFieldParser(sr))
                {
                    tfp.TextFieldType = FieldType.Delimited;
                    tfp.Delimiters = new String[] { splitChar.ToString() };
                    splitparts = tfp.ReadFields();
                }
                splitLines.Add(splitparts);
            }
            catch (MalformedLineException mfle)
            {
                // Handle error here
            }
        }
        return splitLines;
    }
