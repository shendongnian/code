    private static void LoadDictionarySax()
    {
        using (OpenXmlReader reader = OpenXmlReader.Create(sharedStringTablePart))
        {
            int i = 0;
            while (reader.Read())
            {
                if (reader.ElementType == typeof(SharedStringItem))
                {
                    SharedStringItem ssi = (SharedStringItem)reader.LoadCurrentElement();
                    dictionary.Add(i++, ssi.Text != null ? ssi.Text.Text : string.Empty);
                }
            }
        }
    }
