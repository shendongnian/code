     private void Form1_Load(object sender, EventArgs e)
     {
            string xml = @"<Language>
                <FileInfo NumberOfEntries=""10"" FileCreationTime=""2017-07-14 12:23:07"" />
                <Entry Key=""ABC_DEF_GHI"" CreationTime=""01.01.0001 00:00:00"" LastModifiedTime=""01.01.0001 00:00:00"">
                    <LanguageEntry>
                        <ID>1</ID>
                        <Value>Hallo</Value>
                        <Comment>
                        </Comment>
                        <Mark>
                        </Mark>
                    </LanguageEntry>
                    <LanguageEntry>
                        <ID>2</ID>
                        <Value>Hello</Value>
                        <Comment>
                        </Comment>
                        <Mark>
                        </Mark>
                    </LanguageEntry>
                    </Entry>
                    </Language>";         
            XmlSerializer serializer = new XmlSerializer(typeof(Language));
            using(TextReader reader = new StringReader(xml))
            {
                Language result = (Language)serializer.Deserialize(reader);
                GenerateColumnsAndData(result);
            }
      }
