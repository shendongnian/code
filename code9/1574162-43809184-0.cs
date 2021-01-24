    private static bool Save<T, T2>(XDocument xdoc, 
            int importID, SqlConnection cn, SqlTransaction tran, String elementName)
        where T : IImportListBase<T2>, IImportListDatabaseCalls<T2>
    {
        try
        {
            var SourceInfo = xdoc.Root.Element(elementName).ToString();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(SourceInfo))
            {
                T Listresult = (T)serializer.Deserialize(reader);
                foreach (T2 lim in Listresult.ImportItems)
                {
                    Listresult.SaveImportToDatabase(lim, importID, cn, tran);
                }
                return true;
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
        return false;
    }
