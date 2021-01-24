    private static void createUserDefinedDataTypes(Database originalDB, Database destinationDB)
        {
            foreach (UserDefinedDataType dt in originalDB.UserDefinedDataTypes)
            {
                Schema schema = destinationDB.Schemas[dt.Schema];
                if (schema == null)
                {
                    schema = new Schema(destinationDB, dt.Schema);
                    schema.Create();
                }
                UserDefinedDataType t = new UserDefinedDataType(destinationDB, dt.Name);
                t.SystemType = dt.SystemType;
                t.Length = dt.Length;
                t.Schema = dt.Schema;
                try
                {
                    t.Create();
                }
                catch(Exception ex)
                {
                    throw (ex);
                }
            }
        }
    private static void createXMLSchemaCollections(Database originalDB, Database destinationDB)
        {
            foreach (XmlSchemaCollection col in originalDB.XmlSchemaCollections)
            {
                Schema schema = destinationDB.Schemas[col.Schema];
                if (schema == null)
                {
                    schema = new Schema(destinationDB, col.Schema);
                    schema.Create();
                }
                XmlSchemaCollection c = new XmlSchemaCollection(destinationDB, col.Name);
                c.Text = col.Text;
                c.Schema = col.Schema;
                try
                {
                    c.Create();
                }
                catch(Exception ex)
                {
                    throw (ex);
                }
            }
        }
