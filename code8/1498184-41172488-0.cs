    using (StringReader rowData = new StringReader(reader[0].ToString()))
    {
        string line;
        while ((line = rowData.ReadLine()) != null)
        {
            startVal = 0;
            while (line.IndexOf("Javascript:TermDef", startVal) > -1)
            {
                startVal = line.IndexOf("Javascript:TermDef", startVal);
                endVal = line.IndexOf(">", startVal);
                value = line.Substring(startVal, endVal - startVal - 1);
                Console.WriteLine(value);
                startVal = endVal;
            }
        }
    }
