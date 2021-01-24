    public static void ReadContacts(out List<Contact> contacts)
    {
        contacts = new List<Contact>();
        using (GenericParser parser = new GenericParser())
        {
            parser.SetDataSource("S:/DEPARTMENTS/INFO_TECH/PERM/short_cuts/Addressbook.txt");
            parser.ColumnDelimiter = '\t';
            parser.FirstRowHasHeader = true;
            parser.SkipStartingDataRows = 0;
            parser.MaxRows = 15000;
            parser.TextQualifier = '\"';
            while (parser.Read())
            {
                contacts.Add(new Contact() { Name = parser["Name"], Department = parser["Department"] });
            }
        }
    }
